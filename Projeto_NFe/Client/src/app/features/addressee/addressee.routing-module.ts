import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { AddresseeDetailComponent } from './addressee-view/addressee-detail/addressee-detail.component';
import { AddresseeViewComponent } from './addressee-view/addressee-view.component';
import { AddresseeResolveService } from './shared/addressee.service';
import { AddresseeListComponent } from './addressee-list/addressee-list.component';
import { AddresseeRegisterFormComponent } from './addressee-register-form/addressee-register-form.component';
import { AddresseeEditFormComponent } from './addressee-view/addressee-edit-form/addressee-edit-form.component';

const addresseeRoutes: Routes = [
    {
        path: '',
        component: AddresseeListComponent,
    },
    {
        path: 'cadastrar',
        component: AddresseeRegisterFormComponent,
    },
    {
        path: ':addresseeId',
        resolve: {
            addressee: AddresseeResolveService,
        },
        data: {
            breadcrumbOptions: {
                breadcrumbId: 'addressee',
            },
        },
        children: [
            {
                path: '',
                component: AddresseeViewComponent,
                children: [
                    {
                        path: '',
                        redirectTo: 'info',
                        pathMatch: 'full',
                    },
                    {
                        path: 'info',
                        children: [
                            {
                                path: '',
                                component: AddresseeDetailComponent,
                            },
                            {
                                path: 'editar',
                                component: AddresseeEditFormComponent,
                                data: {
                                    breadcrumbOptions: {
                                        breadcrumbLabel: 'Editar',
                                    },
                                },
                            },
                        ],
                    },
                ],
            },
        ],
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
