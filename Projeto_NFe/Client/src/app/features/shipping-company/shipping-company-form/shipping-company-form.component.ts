import { FormGroup } from '@angular/forms';
import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';

@Component({
    selector: 'ndd-shipping-company-form',
    templateUrl: './shipping-company-form.component.html',
})

export class ShippingCompanyFormComponent implements OnInit, OnDestroy {
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
        const corporatePerson: string = '2';
        const personType: string = this.form.get('personType').value;

        if (personType === corporatePerson) {
            return this.form.get('enterprise').get(formControlName).errors && this.form.get('enterprise').get(formControlName).touched;
        } else {
            return this.form.get('person').get(formControlName).errors && this.form.get('person').get(formControlName).touched;
        }
    }

    public changePerson(): void {
        const corporatePerson: string = '2';
        const personType: string = this.form.get('personType').value;

        if (personType === corporatePerson) {
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
