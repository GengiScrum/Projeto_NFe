import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { AddresseeListComponent } from './addressee-list/addressee-list.component';

const addresseeRoutes: Routes = [
    {
        path: '',
        component: AddresseeListComponent,
    },
];

@NgModule ({
    imports: [RouterModule.forChild(addresseeRoutes)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})

export class AddresseeRoutingModule {
    //
}
