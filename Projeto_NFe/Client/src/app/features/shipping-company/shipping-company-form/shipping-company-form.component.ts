import { FormGroup } from '@angular/forms';
import { Component, Input } from '@angular/core';

@Component({
    selector: 'ndd-shipping-company-form',
    templateUrl: './shipping-company-form.component.html',
})

export class ShippingCompanyFormComponent {
    @Input() public form: FormGroup;
    @Input() public returnRoute: string;

    public cnpjMask: (string | RegExp)[] = [/[0-9]/, /[0-9]/, '.', /[0-9]/, /[0-9]/, /[0-9]/, '.', /[0-9]/,
        /[0-9]/, /[0-9]/, '/', /[0-9]/, /[0-9]/, /[0-9]/, /[0-9]/, '-', /[0-9]/, /[0-9]/];
    public cpfMask: (string | RegExp)[] = [/[0-9]/, /[0-9]/, /[0-9]/, '.', /[0-9]/, /[0-9]/, /[0-9]/,
        '.', /[0-9]/, /[0-9]/, /[0-9]/, '-', /[0-9]/, /[0-9]/];

    public getFormError(formControlName: string): boolean {
        return this.form.get(formControlName).errors && this.form.get(formControlName).touched;
    }

    public clearDocumentField(personType: number): void {
        const corporatePerson: number = 2;
        if (personType === corporatePerson) {
            this.form.patchValue({
                cpf: '',
            });
        } else {
            this.form.patchValue({
                cnpj: '',
                corporateName: '',
                stateRegistration: '',
            });
        }
        this.form.get('cpf').markAsUntouched();
        this.form.get('cnpj').markAsUntouched();
        this.form.get('stateRegistration').markAsUntouched();
        this.form.get('corporateName').markAsUntouched();
    }
}
