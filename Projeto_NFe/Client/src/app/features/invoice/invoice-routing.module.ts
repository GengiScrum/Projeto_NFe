import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { InvoiceRegisterFormComponent } from './invoice-register-form/invoice-register-form.component';
import { InvoiceListComponent } from './invoice-list/invoice-list.component';
import { InvoiceViewComponent } from './invoice-view/invoice-view.component';
import { InvoiceDetailComponent } from './invoice-view/invoice-detail/invoice-detail.component';
import { InvoiceEditFormComponent } from './invoice-view/invoice-edit-form/invoice-edit-form.component';
import { InvoiceResolveService } from './shared/invoice.service';

const invoicesRoutes: Routes = [
    {
        path: '',
        component: InvoiceListComponent,
    },
    {
        path: 'cadastrar',
        component: InvoiceRegisterFormComponent,
    },
    {
        path: ':invoiceId',
        resolve: {
            product: InvoiceResolveService,
        },
        data: {
            breadcrumbOptions: {
                breadcrumbId: 'invoice',
            },
        },
        children: [
            {
                path: '',
                component: InvoiceViewComponent,
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
                                component: InvoiceDetailComponent,
                            },
                            {
                                path: 'editar',
                                component: InvoiceEditFormComponent,
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

@NgModule({
    imports: [RouterModule.forChild(invoicesRoutes)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})
export class InvoiceRoutingModule {

}
