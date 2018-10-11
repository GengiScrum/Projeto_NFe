import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component } from '@angular/core';

import { AddresseeService } from './../shared/addressee.service';

@Component({
    templateUrl: './addressee-register-form.component.html',
})

export class AddresseeRegisterFormComponent {
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
        private service: AddresseeService,
        private router: Router) {
        this.arrangeForm();
    }

    public redirect(): void {
        this.router.navigate(['/destinatarios']);
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
