import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs/Subject';

import { ShippingCompany } from './../shared/shipping-company.model';
import { ShippingCompanyResolveService } from './../shared/shipping-company.service';

@Component({
    templateUrl: './shipping-company-view.component.html',
})

export class ShippingCompanyViewComponent implements OnInit, OnDestroy {
    public shippingCompany: ShippingCompany;
    public title: String;
    public infoItems: object[];

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: ShippingCompanyResolveService) {}

    public ngOnInit(): void {
        this.resolver.onChanges
        .takeUntil(this.ngUnsubscribe)
        .subscribe((shippingCompany: ShippingCompany) => {
            this.shippingCompany = shippingCompany;
            this.createProperty();
        });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    private createProperty(): void {
        this.title = this.shippingCompany.businessName;
        const docDescription: string = (this.shippingCompany.cnpj) ?
            ('CNPJ: ' + this.shippingCompany.cnpj) : ('CPF: ' + this.shippingCompany.cpf);
        const stateRegistrationDescription: string = 'Inscrição Estadual: ' + this.shippingCompany.stateRegistration;
        const corporateNameDescription: string = 'Razão Social: ' + this.shippingCompany.corporateName;
        this.infoItems = [
            {
                value: docDescription,
                description: docDescription,
            },
            {
                value: stateRegistrationDescription,
                description: stateRegistrationDescription,
            },
            {
                value: corporateNameDescription,
                description: corporateNameDescription,
            },
        ];
    }
}
