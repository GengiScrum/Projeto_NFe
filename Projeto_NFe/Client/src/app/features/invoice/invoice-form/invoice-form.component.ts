import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { ShippingCompany } from '../../shipping-company/shared/shipping-company.model';
import { Addressee } from './../../addressee/shared/addressee.model';
import { Issuer } from './../../issuer/shared/issuer.model';
import { IssuerService } from '../../issuer/shared/issuer.service';
import { ShippingCompanyService } from '../../shipping-company/shared/shipping-company.service';
import { AddresseeService } from '../../addressee/shared/addressee.service';
import { Product } from './../../product/shared/product.model';
import { ProductService } from './../../product/shared/product.service';
import { ProductSold } from './../shared/invoice.model';

@Component({
    selector: 'ndd-invoice-form',
    templateUrl: './invoice-form.component.html',
})
export class InvoiceFormComponent implements OnInit {
    @Input() public form: FormGroup;
    @Input() public returnRoute: string;
    @Output() public addProduct: EventEmitter<ProductSold> = new EventEmitter<ProductSold>();
    @Output() public removeProduct: EventEmitter<number> = new EventEmitter<number>();

    public issuers: Issuer[];
    public shippingCompanies: ShippingCompany[];
    public addressees: Addressee[];
    public products: Product[];

    constructor(private issuerService: IssuerService,
        private shippingCompanyService: ShippingCompanyService,
        private adresseeService: AddresseeService,
        private productService: ProductService) { }

    public ngOnInit(): void {
        this.adresseeService.getAll().take(1)
            .subscribe((addressees: Addressee[]) => {
                this.addressees = addressees;
                this.issuerService.getAll().take(1)
                    .subscribe((issuers: Issuer[]) => {
                        this.issuers = issuers;
                        this.shippingCompanyService.getAll().take(1)
                            .subscribe((shippingCompanies: ShippingCompany[]) => {
                                this.shippingCompanies = shippingCompanies;
                                this.productService.getAll().take(1)
                                    .subscribe((products: Product[]) => this.products = products);
                            });
                    });
            });
    }

    public getFormError(formControlName: string): boolean {
        return this.form.get(formControlName).errors && this.form.get(formControlName).touched;
    }

    public add(product: Product, quantity: number): void {
        //
    }
}
