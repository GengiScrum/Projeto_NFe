import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { ShippingCompanyRegisterCommand } from '../shared/shipping-company.model';
import { ShippingCompanyService } from '../shared/shipping-company.service';

@Component({
    templateUrl: './shipping-company-register-form.component.html',
})
export class ShippingCompanyRegisterFormComponent {
    public form: FormGroup;
    public isLoading: boolean = false;

    constructor(private fb: FormBuilder,
        private service: ShippingCompanyService,
        private router: Router) {
        this.arrangeForm();
    }

    public onSubmit(): void {
        this.isLoading = true;
        const shippingCompanyRegisterCommand: ShippingCompanyRegisterCommand
            = new ShippingCompanyRegisterCommand(this.form.get('details').value, this.form.get('address').value);
        this.service.register(shippingCompanyRegisterCommand)
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
                businessName: ['', Validators.required],
                corporateName: ['', Validators.required],
                cnpj: [''],
                cpf: [''],
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
