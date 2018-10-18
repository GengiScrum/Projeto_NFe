import { Subject } from 'rxjs/Subject';
import { Component, OnInit, OnDestroy } from '@angular/core';

import { Invoice } from './../shared/invoice.model';
import { InvoiceResolveService } from './../shared/invoice.service';

@Component({
    templateUrl: './invoice-view.component.html',
})

export class InvoiceViewComponent implements OnInit, OnDestroy{
    public invoice: Invoice;
    public infoItems: object[];
    public title: string;
    public returnRoute: string = '/notas-fiscais';

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: InvoiceResolveService) {

    }

    public ngOnInit(): void {
        this.resolver.onChanges.takeUntil(this.ngUnsubscribe).subscribe((invoice: Invoice) => {
            this.invoice = invoice; this.createProperty(); });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    private createProperty(): void {
        this.title = this.invoice.operationNature;
        const addressee: string = 'Destinatário: ' + this.invoice.addresseeBusinessName;
        const issuer: string = 'Emitente: ' + this.invoice.issuerBusinessName;
        const shippingCompany: string = 'Transportador: ' + this.invoice.shippingCompanyBusinessName;

        this.infoItems = [
            {
                value: addressee,
                description: addressee,
            },
            {
                value: issuer,
                description: issuer,
            },
            {
                value: shippingCompany,
                description: shippingCompany,
            },
        ];
    }
}
