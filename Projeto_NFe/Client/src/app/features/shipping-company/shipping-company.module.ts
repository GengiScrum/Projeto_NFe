import { NgModule } from '@angular/core';
import { GridModule } from '@progress/kendo-angular-grid/dist/es2015/grid.module';
import { TextMaskModule } from 'angular2-text-mask';

import { ShippingCompanyGridService, ShippingCompanyService, ShippingCompanyResolveService } from './shared/shipping-company.service';
import { ShippingCompanyRoutingModule } from './shipping-company.routing-module';
import { ShippingCompanyViewComponent } from './shipping-company-view/shipping-company-view.component';
import { ShippingCompanyListComponent } from './shipping-company-list/shipping-company-list.component';
import { SharedModule } from './../../shared/shared.module';
import { ShippingCompanyDetailComponent } from './shipping-company-view/shipping-company-detail/shipping-company-detail.component';
import { ShippingCompanyFormComponent } from './shipping-company-form/shipping-company-form.component';
import { ShippingCompanyRegisterFormComponent } from './shipping-company-register-form/shipping-company-register-form.component';
import { NDDTabsbarModule } from './../../shared/ndd-ng-tabsbar/component/ndd-ng-tabsbar.module';
import { NDDTitlebarModule } from './../../shared/ndd-ng-titlebar/component/ndd-ng-titlebar.module';

@NgModule({
    imports: [
        SharedModule,
        GridModule,
        ShippingCompanyRoutingModule,
        NDDTitlebarModule,
        NDDTabsbarModule,
        TextMaskModule,
    ],
    exports: [],
    declarations: [
        ShippingCompanyListComponent,
        ShippingCompanyViewComponent,
        ShippingCompanyDetailComponent,
        ShippingCompanyFormComponent,
        ShippingCompanyRegisterFormComponent,
    ],
    providers: [
        ShippingCompanyGridService,
        ShippingCompanyService,
        ShippingCompanyResolveService,
    ],
})

export class ShippingCompanyModule {
    //
}
