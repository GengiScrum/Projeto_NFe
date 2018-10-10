import { FormGroup } from '@angular/forms';
import { Component, Input } from '@angular/core';

@Component({
    templateUrl: './addressee-form.component.html',
    selector: 'ndd-addressee-form',
})

export class AddresseeFormComponent {
    @Input() public form: FormGroup;
    @Input() public returnRoute: string;

    public cnpjMask: (string | RegExp)[] = [/[0-9]/, /[0-9]/, '.', /[0-9]/, /[0-9]/, /[0-9]/, '.', /[0-9]/,
    /[0-9]/, /[0-9]/, '/', /[0-9]/, /[0-9]/, /[0-9]/, /[0-9]/, '-', /[0-9]/, /[0-9]/];
    public cpfMask: (string | RegExp)[] = [/[0-9]/, /[0-9]/, /[0-9]/, '.', /[0-9]/, /[0-9]/, /[0-9]/,
    '.', /[0-9]/, /[0-9]/, /[0-9]/, '-', /[0-9]/, /[0-9]/];

    public getFormError(formControlName: string): boolean {
        return this.form.get(formControlName).errors && this.form.get(formControlName).touched;
    }
}
