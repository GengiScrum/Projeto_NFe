import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';

import { Invoice, InvoiceUpdateCommand } from '../../shared/invoice.model';
import { InvoiceService, InvoiceResolveService } from '../../shared/invoice.service';

@Component({
    templateUrl: './invoice-edit-form.component.html',
})
export class InvoiceEditFormComponent implements OnInit, OnDestroy {
    public invoice: Invoice;
    public isLoading: boolean = false;
    public formModel: FormGroup;
    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private fb: FormBuilder,
        private service: InvoiceService,
        private router: Router,
        private route: ActivatedRoute,
        private resolver: InvoiceResolveService) {
        this.arrangeForm();
    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((invoice: Invoice) => {
                this.isLoading = false;
                this.invoice = Object.assign(new Invoice(), invoice);
                this.populateForm();
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public onSubmit(): void {
        this.isLoading = true;
        const invoiceUpdateCommand: InvoiceUpdateCommand =
            new InvoiceUpdateCommand(this.formModel.value, this.invoice.id);
        this.service.update(invoiceUpdateCommand)
            .take(1)
            .subscribe(() => {
                this.isLoading = false;
                this.resolver.resolveFromRouteAndNotify();
                alert('Nota Fiscal editada com sucesso.');
                this.redirect();
            });
    }

    public redirect(): void {
        this.router.navigate(['../'], { relativeTo: this.route });
    }

    private arrangeForm(): void {
        this.formModel = this.fb.group({
            issuerId: [''],
            shippingCompanyId: [''],
            addresseeId: [''],
            operationNature: [''],
            entryDate: [(new Date()).toISOString().split('T')[0]],
        });
    }

    private populateForm(): void {
        this.formModel.patchValue({
            issuerId: this.invoice.issuerId,
            shippingCompanyId: this.invoice.shippingCompanyId,
            addresseeId: this.invoice.addresseeId,
            operationNature: this.invoice.operationNature,
            entryDate: (new Date(this.invoice.entryDate)).toISOString().split('T')[0],
        });
    }
}
