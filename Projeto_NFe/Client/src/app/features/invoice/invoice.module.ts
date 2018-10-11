import { NgModule } from '@angular/core';
import { GridModule } from '@progress/kendo-angular-grid';

import { SharedModule } from './../../shared/shared.module';
import { NDDTabsbarModule } from './../../shared/ndd-ng-tabsbar/component/ndd-ng-tabsbar.module';
import { NDDTitlebarModule } from './../../shared/ndd-ng-titlebar/component/ndd-ng-titlebar.module';
import { InvoiceRoutingModule } from './invoice-routing.module';
import { InvoiceListComponent } from './invoice-list/invoice-list.component';
import { InvoiceGridService, InvoiceResolveService, InvoiceService } from './shared/invoice.service';

@NgModule({
    imports: [
        GridModule,
        SharedModule,
        NDDTitlebarModule,
        NDDTabsbarModule,
        InvoiceRoutingModule,
    ],
    exports: [],
    declarations: [
        InvoiceListComponent,
    ],
    providers: [ InvoiceGridService, InvoiceResolveService, InvoiceService ],
})
export class InvoiceModule {

}
