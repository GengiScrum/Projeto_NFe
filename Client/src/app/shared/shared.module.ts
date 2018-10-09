import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AddressDetailComponent } from './../features/address/address-details/address-detail.component';
import { AddressFormComponent } from './../features/address/address-form/address-form.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
    ],
    exports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        AddressDetailComponent,
        AddressFormComponent,
        ],
    declarations: [
        AddressDetailComponent,
        AddressFormComponent,
    ],
    providers: [],
})
export class SharedModule {}
