import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { InvoiceRegisterFormComponent } from './invoice-register-form/invoice-register-form.component';
import { InvoiceListComponent } from './invoice-list/invoice-list.component';

const invoicesRoutes: Routes = [
    {
        path: '',
        component: InvoiceListComponent,
    },
    {
        path: 'cadastrar',
        component: InvoiceRegisterFormComponent,
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
