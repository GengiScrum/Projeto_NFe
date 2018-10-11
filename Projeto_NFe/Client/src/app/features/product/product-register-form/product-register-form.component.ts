import { Router } from '@angular/router';
import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ProductRegisterCommand } from './../shared/product.model';
import { ProductService } from './../shared/product.service';

@Component({
    templateUrl: './product-register-form.component.html',
})

export class ProductRegisterFormComponent {
    public form: FormGroup;
    public isLoading: boolean = false;
    public returnRoute: string = '/produtos';

    constructor(private fb: FormBuilder, private service: ProductService, private router: Router) {
        this.form = this.fb.group({
            code: ['', Validators.required],
            description: ['', Validators.required],
            unitaryValue: ['', Validators.required],
        });
    }

    public onRegister(): void {
        this.isLoading = true;
        const productRegisterCommand: ProductRegisterCommand
            = new ProductRegisterCommand(this.form.value);
        this.service.register(productRegisterCommand).take(1).subscribe(() => {
            this.isLoading = false;
            this.redirect();
        });
    }

    public redirect(): void {
        this.router.navigate(['/produtos']);
    }
}
