import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';

import { ShippingCompany, ShippingCompanyUpdateCommand } from './../../shared/shipping-company.model';
import { ShippingCompanyService, ShippingCompanyResolveService } from './../../shared/shipping-company.service';

@Component({
    templateUrl: './shipping-company-edit-form.component.html',
})
export class ShippingCompanyEditFormComponent implements OnInit, OnDestroy {
    public shippingCompany: ShippingCompany;
    public isLoading: boolean = false;
    public form: FormGroup;
    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private fb: FormBuilder,
        private service: ShippingCompanyService,
        private router: Router,
        private route: ActivatedRoute,
        private resolver: ShippingCompanyResolveService) {
        this.form = this.fb.group({
            details: this.fb.group({
                businessName: ['', Validators.required],
                corporateName: ['', Validators.required],
                cnpj: [''],
                cpf: [''],
                personType: ['1', Validators.required],
                stateRegistration: ['', Validators.required],
            }),
            address: this.fb.group({
                streetName: ['', Validators.required],
                number: ['', Validators.required],
                neighborhood: ['', Validators.required],
                city: ['', Validators.required],
                state: ['', Validators.required],
                country: ['', Validators.required],
            }),
        });
    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((shippingCompany: ShippingCompany) => {
                this.isLoading = false;
                this.shippingCompany = Object.assign(new ShippingCompany(), shippingCompany);
                this.populateForm();
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public onSubmit(): void {
        this.isLoading = true;
        const shippingCompanyUpdateCommand: ShippingCompanyUpdateCommand =
            new ShippingCompanyUpdateCommand(this.form.get('details').value, this.form.get('address').value, this.shippingCompany.id);
        this.service.update(shippingCompanyUpdateCommand)
            .take(1)
            .subscribe(() => {
                this.isLoading = false;
                this.resolver.resolveFromRouteAndNotify();
                this.redirect();
            });
    }

    public redirect(): void {
        this.router.navigate(['../'], { relativeTo: this.route });
    }

    private populateForm(): void {
        this.form.patchValue({
            details: {
                businessName: this.shippingCompany.businessName,
                corporateName: this.shippingCompany.corporateName,
                cnpj: this.shippingCompany.cnpj,
                stateRegistration: this.shippingCompany.stateRegistration,
                cpf: this.shippingCompany.cpf,
                personType: this.shippingCompany.personType.toString(),
            },
            address: {
                streetName: this.shippingCompany.streetName,
                number: this.shippingCompany.number,
                neighborhood: this.shippingCompany.neighborhood,
                city: this.shippingCompany.city,
                state: this.shippingCompany.state,
                country: this.shippingCompany.country,
            },
        });
    }
}
