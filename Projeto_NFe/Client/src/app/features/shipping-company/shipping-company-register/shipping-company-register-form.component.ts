import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { ShippingCompanyRegisterCommand } from '../shared/shipping-company.model';
import { ShippingCompanyService } from '../shared/shipping-company.service';

@Component({
    templateUrl: './shipping-company-register-form.component.html',
})
export class ShippingCompanyRegisterFormComponent {
    public formModel: FormGroup;
    public person: FormGroup = this.fb.group({
        cpf: ['', Validators.required],
    });

    public enterprise: FormGroup = this.fb.group({
        cnpj: ['', Validators.required],
        corporateName: ['', Validators.required],
        stateRegistration: ['', Validators.required],
    });
    public isLoading: boolean = false;

    constructor(private fb: FormBuilder,
        private service: ShippingCompanyService,
        private router: Router) {
        this.arrangeForm();
    }

    public onSubmit(): void {
        this.isLoading = true;
        const shippingCompanyRegisterCommand: ShippingCompanyRegisterCommand
            = new ShippingCompanyRegisterCommand(this.formModel.value);
        this.service.register(shippingCompanyRegisterCommand)
            .take(1)
            .subscribe(() => {
                this.isLoading = false;
                alert('Cadastrado com sucesso');
                this.redirect();
            });
    }

    public redirect(): void {
        this.router.navigate(['/transportadores']);
    }

    private arrangeForm(): void {
        this.formModel = this.fb.group({
            businessName: ['', Validators.required],
            personType: ['1', Validators.required],
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
