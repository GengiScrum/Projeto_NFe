import { NgModule } from '@angular/core';
import { GridModule } from '@progress/kendo-angular-grid';

import { SharedModule } from './../../shared/shared.module';
import { NDDTabsbarModule } from './../../shared/ndd-ng-tabsbar/component/ndd-ng-tabsbar.module';
import { NDDTitlebarModule } from './../../shared/ndd-ng-titlebar/component/ndd-ng-titlebar.module';

import { InvoiceRoutingModule } from './invoice-routing.module';
import { InvoiceListComponent } from './invoice-list/invoice-list.component';
import { InvoiceGridService, InvoiceResolveService, InvoiceService } from './shared/invoice.service';
import { InvoiceFormComponent } from './invoice-form/invoice-form.component';
import { InvoiceRegisterFormComponent } from './invoice-register-form/invoice-register-form.component';
import { ShippingCompanySharedModule } from '../shipping-company/shared/shipping-company-shared.module';
import { IssuerSharedModule } from '../issuer/shared/issuer-shared.module';
import { AddresseeSharedModule } from '../addressee/shared/addressee-shared.module';
import { InvoiceViewComponent } from './invoice-view/invoice-view.component';
import { InvoiceDetailComponent } from './invoice-view/invoice-detail/invoice-detail.component';
import { InvoiceEditFormComponent } from './invoice-view/invoice-edit-form/invoice-edit-form.component';
import { InvoiceProductDetailComponent } from './invoice-view/invoice-product-detail/invoice-product-detail.component';
import { ProductSharedModule } from './../product/shared/product-shared.module';

@NgModule({
    imports: [
        GridModule,
        SharedModule,
        NDDTitlebarModule,
        NDDTabsbarModule,
        InvoiceRoutingModule,
        ShippingCompanySharedModule,
        IssuerSharedModule,
        AddresseeSharedModule,
        ProductSharedModule,
    ],
    exports: [],
    declarations: [
        InvoiceListComponent,
        InvoiceFormComponent,
        InvoiceRegisterFormComponent,
        InvoiceViewComponent,
        InvoiceDetailComponent,
        InvoiceEditFormComponent,
        InvoiceProductDetailComponent,
    ],
    providers: [
        InvoiceGridService,
        InvoiceResolveService,
        InvoiceService,
    ],
})
export class InvoiceModule {

}
