import { FormGroup, FormBuilder } from '@angular/forms';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { InvoiceRegisterCommand } from '../shared/invoice.model';
import { InvoiceService } from '../shared/invoice.service';
import { Product } from './../../product/shared/product.model';

@Component({
    templateUrl: './invoice-register-form.component.html',
})
export class InvoiceRegisterFormComponent {
    public formModel: FormGroup;
    public isLoading: boolean = false;

    constructor(private fb: FormBuilder,
        private service: InvoiceService,
        private router: Router) {
        this.arrangeForm();
    }

    public onSubmit(): void {
        this.isLoading = true;
        const invoiceRegisterCommand: InvoiceRegisterCommand
            = new InvoiceRegisterCommand(this.formModel.value);
        this.service.register(invoiceRegisterCommand)
            .take(1)
            .subscribe(() => {
                this.isLoading = false;
                alert('Nota Fiscal cadastrada com sucesso.');
                this.redirect();
            });
    }

    public redirect(): void {
        this.router.navigate(['/notas-fiscais']);
    }

    public createProductSold(product: Product, quantity: Number): FormGroup {
        return this.fb.group({
            quantity: [quantity],
            product: this.fb.group({
                code: [product.code],
                description: [product.description],
                unitaryValue: [product.unitaryValue],
            }),
        });
    }

    private arrangeForm(): void {
        this.formModel = this.fb.group({
            issuerId: [''],
            shippingCompanyId: [''],
            addresseeId: [''],
            operationNature: [''],
            entryDate: [(new Date()).toISOString().split('T')[0]],
            ProductSolds: this.fb.array([
            ]),
        });
    }
}
