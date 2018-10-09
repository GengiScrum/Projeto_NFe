import { PersonType } from './../shared/person-type.enum';
import { Component, OnInit, OnDestroy } from '@angular/core';
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
        this.title = this.shippingCompany.name;
        const cnpjDescription: string = (this.shippingCompany.personType === PersonType.COMPANY) ?
            ('CNPJ: ' + this.shippingCompany.cnpj) : ('CPF: ' + this.shippingCompany.cpf);
        this.infoItems = [
            {
                value: cnpjDescription,
                description: cnpjDescription,
            },
        ];
    }
}
