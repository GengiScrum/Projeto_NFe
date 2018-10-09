import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { ShippingCompanyListComponent } from './shipping-company-list/shipping-company-list.component';
import { ShippingCompanyResolveService } from './shared/shipping-company.service';
import { ShippingCompanyDetailComponent } from './shipping-company-view/shipping-company-detail/shipping-company-detail.component';
import { ShippingCompanyViewComponent } from './shipping-company-view/shipping-company-view.component';
import { ShippingCompanyRegisterFormComponent } from './shipping-company-register/shipping-company-register-form.component';
import { ShippingCompanyEditFormComponent } from './shipping-company-view/shipping-company-edit-form/shipping-company-edit-form.component';

const shippingCompanyRoutes: Routes = [
    {
        path: '',
        component: ShippingCompanyListComponent,
    },
    {
        path: 'cadastrar',
        component: ShippingCompanyRegisterFormComponent,
    },
    {
        path: ':shippingCompanyId',
        resolve: {
            product: ShippingCompanyResolveService,
        },
        data: {
            breadcrumbOptions: {
                breadcrumbId: 'shippingCompany',
            },
        },
        children: [
            {
                path: '',
                component: ShippingCompanyViewComponent,
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
                                component: ShippingCompanyDetailComponent,
                            },
                            {
                                path: 'editar',
                                component: ShippingCompanyEditFormComponent,
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
    imports: [RouterModule.forChild(shippingCompanyRoutes)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})

export class ShippingCompanyRoutingModule {
    //
}
