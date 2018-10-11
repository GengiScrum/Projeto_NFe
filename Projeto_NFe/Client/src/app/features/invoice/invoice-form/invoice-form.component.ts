import { Issuer } from './../../issuer/shared/issuer.model';
import { Component, OnInit } from '@angular/core';

@Component({
    templateUrl: './invoice-form.component.html',
})
export class InvoiceFormComponent implements OnInit {
    public issuersList: Issuer[];

    public ngOnInit(): void {

    }
}
