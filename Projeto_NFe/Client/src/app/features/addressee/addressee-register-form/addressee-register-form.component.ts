import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component } from '@angular/core';

import { AddresseeService } from './../shared/addressee.service';

@Component({
    templateUrl: './addressee-register-form.component.html',
})

export class AddresseeRegisterFormComponent {
    public form: FormGroup;
    public isLoading: boolean = false;

    constructor(private fb: FormBuilder, private service: AddresseeService, private router: Router) {
        this.form = this.fb.group({
            details: this.fb.group({
                personType: [false, Validators.required],
                businessName: ['', Validators.required],
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

    public redirect(): void {
        this.router.navigate(['/destinatarios']);
    }
}
