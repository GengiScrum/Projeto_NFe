import { Subject } from 'rxjs/Subject';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Component, Input, OnInit, OnDestroy } from '@angular/core';

@Component({
    templateUrl: './addressee-form.component.html',
    selector: 'ndd-addressee-form',
})

export class AddresseeFormComponent implements OnInit, OnDestroy {
    @Input() public form: FormGroup;
    @Input() public person: FormGroup;
    @Input() public enterprise: FormGroup;
    @Input() public returnRoute: string;

    public cnpjMask: (string | RegExp)[] = [/[0-9]/, /[0-9]/, '.', /[0-9]/, /[0-9]/, /[0-9]/, '.', /[0-9]/,
        /[0-9]/, /[0-9]/, '/', /[0-9]/, /[0-9]/, /[0-9]/, /[0-9]/, '-', /[0-9]/, /[0-9]/];
    public cpfMask: (string | RegExp)[] = [/[0-9]/, /[0-9]/, /[0-9]/, '.', /[0-9]/, /[0-9]/, /[0-9]/,
        '.', /[0-9]/, /[0-9]/, /[0-9]/, '-', /[0-9]/, /[0-9]/];

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    public ngOnInit(): void {
        this.changePerson();
        this.form.get('personType').valueChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe(() => {
                this.changePerson();
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public getFormError(formControlName: string): boolean {
        return this.form.get(formControlName).errors && this.form.get(formControlName).touched;
    }

    public getPersonTypeFormError(formControlName: string): boolean {
        const personType: boolean = this.form.get('personType').value;

        if (personType) {
            return this.form.get('enterprise').get(formControlName).errors && this.form.get('enterprise').get(formControlName).touched;
        } else {
            return this.form.get('person').get(formControlName).errors && this.form.get('person').get(formControlName).touched;
        }
    }

    public changePerson(): void {
        const personType: boolean = this.form.get('personType').value;

        if (personType) {
            this.arrangeLegalPersonForm();
        } else {
            this.arrangeIndividualPersonForm();
        }
    }

    private arrangeIndividualPersonForm(): void {
        this.form.addControl('person', this.person);
        this.form.removeControl('entreprise');
        this.form.updateValueAndValidity();
    }

    private arrangeLegalPersonForm(): void {
        this.form.addControl('enterprise', this.enterprise);
        this.form.removeControl('person');
        this.form.updateValueAndValidity();
    }
}
