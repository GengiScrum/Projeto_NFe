import { InvoiceListComponent } from './invoice-list/invoice-list.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const invoicesRoutes: Routes = [
    {
        path: '',
        component: InvoiceListComponent,
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
