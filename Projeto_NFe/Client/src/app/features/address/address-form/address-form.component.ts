import { Component, Input, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

import { States, IState } from './../states.model';

@Component({
    selector: 'ndd-address-form',
    templateUrl: './address-form.component.html',
})

export class AddressFormComponent implements OnInit {

    @Input() public form: FormControl;

    public states: IState[] = States.UF;

    public ngOnInit(): void {
        this.form.patchValue({
            country: 'Brasil',
        });
    }

    public getFormError(formControlName: string): boolean {
        return this.form.get(formControlName).errors && this.form.get(formControlName).touched;
    }
}
