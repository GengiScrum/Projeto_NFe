import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';

import { Invoice } from '../../shared/invoice.model';
import { InvoiceResolveService } from '../../shared/invoice.service';
import { Addressee } from './../../../addressee/shared/addressee.model';
import { ShippingCompany } from './../../../shipping-company/shared/shipping-company.model';
import { Issuer } from './../../../issuer/shared/issuer.model';
import { AddresseeService } from './../../../addressee/shared/addressee.service';
import { ShippingCompanyService } from './../../../shipping-company/shared/shipping-company.service';
import { IssuerService } from './../../../issuer/shared/issuer.service';

@Component({
    templateUrl: './invoice-detail.component.html',
})

export class InvoiceDetailComponent implements OnInit, OnDestroy {
    public invoice: Invoice;
    public addressee: Addressee;
    public shippingCompany: ShippingCompany;
    public issuer: Issuer;
    public availabilityText: string = '';
    public isLoading: boolean = false;
    public documentTypeAddressee: string;
    public documentNumberAddressee: string;
    public documentTypeShippingCompany: string;
    public documentNumberShippingCompany: string;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: InvoiceResolveService,
        private router: Router,
        private route: ActivatedRoute,
        private issuerService: IssuerService,
        private shippingCompanyService: ShippingCompanyService,
        private addresseeService: AddresseeService) { }

    public ngOnInit(): void {
        this.isLoading = true;
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((invoice: Invoice) => {
                this.invoice = Object.assign(new Invoice(), invoice);
                this.isLoading = false;
                this.issuerService.get(this.invoice.issuerId).take(1).subscribe((issuer: Issuer) => {
                    this.issuer = issuer;
                    this.shippingCompanyService.get(this.invoice.shippingCompanyId).take(1).subscribe((shippingCompany: ShippingCompany) => {
                        this.shippingCompany = shippingCompany;
                        this.setDocumentShippingCompany();
                        this.addresseeService.get(this.invoice.addresseeId).take(1).subscribe((addressee: Addressee) => {
                            this.addressee = addressee;
                            this.setDocumentAddressee();
                        });
                    });
                });
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public redirect(): void {
        this.router.navigate(['/notas-fiscais']);
    }

    public onEdit(): void {
        this.router.navigate(['editar'], { relativeTo: this.route, skipLocationChange: true });
    }

    private setDocumentAddressee(): void {
        if (this.addressee.cpf) {
            this.documentNumberAddressee = this.addressee.cpf;
            this.documentTypeAddressee = 'CPF';
        } else {
            this.documentNumberAddressee = this.addressee.cnpj;
            this.documentTypeAddressee = 'CNPJ';
        }
    }

    private setDocumentShippingCompany(): void {
        if (this.shippingCompany.cpf) {
            this.documentNumberShippingCompany = this.shippingCompany.cpf;
            this.documentTypeShippingCompany = 'CPF';
        } else {
            this.documentNumberShippingCompany = this.shippingCompany.cnpj;
            this.documentTypeShippingCompany = 'CNPJ';
        }
    }
}
