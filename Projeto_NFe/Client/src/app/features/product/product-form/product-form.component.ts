import { FormGroup } from '@angular/forms';
import { Component, Input } from '@angular/core';

@Component({
    selector: 'ndd-product-form',
    templateUrl: './product-form.component.html',
})

export class ProductFormComponent {
    @Input() public form: FormGroup;
    @Input() public returnRoute: string;

    public getFormError(formControlName: string): boolean {
        return this.form.get(formControlName).errors && this.form.get(formControlName).touched;
    }

    public getTaxFormError(formControlName: string): boolean {
        return this.form.get('tax').get(formControlName).errors && this.form.get('tax').get(formControlName).touched;
    }
}
