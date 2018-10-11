import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Component, Input, OnInit } from '@angular/core';

@Component({
    templateUrl: './addressee-form.component.html',
    selector: 'ndd-addressee-form',
})

export class AddresseeFormComponent implements OnInit{
    @Input() public form: FormGroup;
    @Input() public returnRoute: string;
    public cnpjMask: (string | RegExp)[] = [/[0-9]/, /[0-9]/, '.', /[0-9]/, /[0-9]/, /[0-9]/, '.', /[0-9]/,
        /[0-9]/, /[0-9]/, '/', /[0-9]/, /[0-9]/, /[0-9]/, /[0-9]/, '-', /[0-9]/, /[0-9]/];
    public cpfMask: (string | RegExp)[] = [/[0-9]/, /[0-9]/, /[0-9]/, '.', /[0-9]/, /[0-9]/, /[0-9]/,
        '.', /[0-9]/, /[0-9]/, /[0-9]/, '-', /[0-9]/, /[0-9]/];

    public legalPerson: FormGroup = this.fb.group({
        corporateName: ['', Validators.required],
        cnpj: ['', Validators.required],
        stateRegistration: ['', Validators.required],
    });

    public physicalPerson: FormGroup = this.fb.group({
        cpf: [''],
    });

    constructor(private fb: FormBuilder) { }

    public ngOnInit(): void {
        this.setControls();
    }

    public setControls(): void {
        if (this.form.controls.personType.value) {
            this.form.removeControl('legalPerson');
            this.form.addControl('physicalPerson', this.physicalPerson);
        }else {
            this.form.removeControl('physicalPerson');
            this.form.addControl('legalPerson', this.legalPerson);
        }
    }

    public getFormError(formControlName: string): boolean {
        return this.form.get(formControlName).errors && this.form.get(formControlName).touched;
    }

    public getPhysicalPersonError(formControlName: string): boolean {
        if (this.form.get('physicalPerson')) {
            return this.form.controls.physicalPerson.get(formControlName).errors && this.form.controls.physicalPerson.get(formControlName).touched;
        }

        return null;
    }

    public getLegalPersonError(formControlName: string): boolean {
        if (this.form.get('legalPerson')) {
            return this.form.controls.legalPerson.get(formControlName).errors && this.form.controls.physicalPerson.get(formControlName).touched;
        }

        return null;
    }
}
