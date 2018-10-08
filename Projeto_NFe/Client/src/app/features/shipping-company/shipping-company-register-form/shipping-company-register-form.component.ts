import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component } from '@angular/core';

import { ShippingCompanyService } from './../shared/shipping-company.service';
import { ShippingCompanyRegisterCommand } from './../shared/shipping-company.model';

@Component({
    templateUrl: './shipping-company-register-form.component.html',
})
export class ShippingCompanyRegisterFormComponent {
    public form: FormGroup;
    public title: string = 'Criar Transportadora';
    public isLoading: boolean = false;

    constructor(private fb: FormBuilder,
        private productService: ShippingCompanyService,
        private router: Router) {
            this.arrangeForm();
        }

    public onSubmit(): void {
        this.isLoading = true;
        const shippingCompany: ShippingCompanyRegisterCommand =
            new ShippingCompanyRegisterCommand(this.form.controls.details.value, this.form.controls.address.value);
        this.productService.post(shippingCompany)
            .take(1)
            .subscribe(() => {
                this.isLoading = false;
                alert('Cadastrado com sucesso');
                this.form.reset();
            });
    }

    public redirect(): void {
        this.router.navigate(['/transportadores']);
    }

    private arrangeForm(): void {
        this.form = this.fb.group({
            details: this.fb.group({
                corporateName: ['', Validators.required],
                businessName: ['', Validators.required],
                cnpj: ['', Validators.required],
                cpf: ['', Validators.required],
                stateRegistration: ['', Validators.required],
                personType: ['1', Validators.required],
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
}
