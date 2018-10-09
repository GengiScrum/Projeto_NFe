import { Address } from './../../../address/address.model';
import { Router } from '@angular/router';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';

import { ShippingCompany } from './../../shared/shipping-company.model';
import { ShippingCompanyResolveService } from './../../shared/shipping-company.service';

@Component({
    templateUrl: './shipping-company-detail.component.html',
})

export class ShippingCompanyDetailComponent implements OnInit, OnDestroy {
    public shippingCompany: ShippingCompany;
    public availabilityText: string = '';
    public isLoading: boolean = false;
    public address: Address;
    public documentNumber: string;
    public documentType: string;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: ShippingCompanyResolveService,
        private router: Router) { }

    public ngOnInit(): void {
        this.isLoading = true;
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((shippingCompany: ShippingCompany) => {
                this.shippingCompany = Object.assign(new ShippingCompany(), shippingCompany);
                this.isLoading = false;
                this.address = new Address(this.shippingCompany);
                this.setDocument();
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public redirect(): void {
        this.router.navigate(['/transportadores']);
    }

    private setDocument(): void {
        if (this.shippingCompany.personType === 1) {
            this.documentNumber = this.shippingCompany.cpf;
            this.documentType = 'CPF';
        } else {
            this.documentNumber = this.shippingCompany.cnpj;
            this.documentType = 'CNPJ';
        }
    }
}
