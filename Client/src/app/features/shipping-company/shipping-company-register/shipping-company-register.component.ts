import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component } from '@angular/core';

@Component({
    templateUrl: './shipping-company-register.component.html',
})
export class ShippingCompanyRegisterComponent {
    public form: FormGroup;

    constructor(private fb: FormBuilder) {
        this.form = this.fb.group({
            details: this.fb.group({
                businessName: ['', Validators.required],
                corporateName: ['', Validators.required],
                cnpj: ['', Validators.required],
                cpf: ['', Validators.required],
                stateRegistration: ['', Validators.required],
                personType: ['1', Validators.required],
            }),
            address: this.fb.group({
                streetname: ['', Validators.required],
                number: ['', Validators.required],
                neighborhood: ['', Validators.required],
                city: ['', Validators.required],
                state: ['', Validators.required],
                country: ['', Validators.required],
            }),
        });
    }
}
