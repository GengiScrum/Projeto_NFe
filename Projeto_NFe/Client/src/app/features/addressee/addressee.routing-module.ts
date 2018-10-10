import { AddresseeViewComponent } from './addressee-view/addressee-view.component';
import { AddresseeResolveService } from './shared/addressee.service';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { AddresseeListComponent } from './addressee-list/addressee-list.component';

const addresseeRoutes: Routes = [
    {
        path: '',
        component: AddresseeListComponent,
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
