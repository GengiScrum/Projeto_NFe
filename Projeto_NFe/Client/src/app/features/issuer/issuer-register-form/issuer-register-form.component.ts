import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component } from '@angular/core';
import { IssuerService } from './../shared/issuer.service';
import { IssuerRegisterCommand } from './../shared/issuer.model';

@Component({
    templateUrl: './issuer-register-form.component.html',
})
export class IssuerRegisterFormComponent {
    public form: FormGroup;
    public isLoading: boolean = false;

    constructor(private fb: FormBuilder, private service: IssuerService, private router: Router) {
        this.form = this.fb.group({
            details: this.fb.group({
                businessName: ['', Validators.required],
                corporateName: ['', Validators.required],
                cnpj: ['', Validators.required],
                stateRegistration: ['', Validators.required],
                municipalRegistration: ['', Validators.required],
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

    public onRegister(): void {
        this.isLoading = true;
        const issuerRegisterCommand: IssuerRegisterCommand
            = new IssuerRegisterCommand(this.form.get('details').value, this.form.get('address').value);
        this.service.register(issuerRegisterCommand).take(1).subscribe(() => { this.isLoading = false; this.redirect(); });
    }

    public redirect(): void {
        this.router.navigate(['/emitentes']);
    }
}
