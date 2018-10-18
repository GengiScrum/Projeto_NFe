import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { ShippingCompany } from '../../shipping-company/shared/shipping-company.model';
import { Addressee } from './../../addressee/shared/addressee.model';
import { Issuer } from './../../issuer/shared/issuer.model';
import { IssuerService } from '../../issuer/shared/issuer.service';
import { ShippingCompanyService } from '../../shipping-company/shared/shipping-company.service';

@Component({
    selector: 'ndd-invoice-form',
    templateUrl: './invoice-form.component.html',
})
export class InvoiceFormComponent implements OnInit {
    @Input() public form: FormGroup;
    @Input() public returnRoute: string;

    public issuers: Issuer[];
    public shippingCompanies: ShippingCompany[];
    public addressees: Addressee[];

    constructor(private issuerService: IssuerService,
        private shippingCompanyService: ShippingCompanyService,
        /*private adresseService: AddresseService*/) { }

    public ngOnInit(): void {
        this.addressees = [];
        this.issuerService.getAll().take(1).subscribe((issuers: Issuer[]) => this.issuers = issuers);
        this.shippingCompanyService.getAll().take(1).subscribe((shippingCompanies: ShippingCompany[]) => this.shippingCompanies = shippingCompanies);
    }

    public getFormError(formControlName: string): boolean {
        return this.form.get(formControlName).errors && this.form.get(formControlName).touched;
    }
}
