import { AddresseeViewComponent } from './addressee-view/addressee-view.component';
import { GridModule } from '@progress/kendo-angular-grid';
import { NgModule } from '@angular/core';
import { SharedModule } from '@progress/kendo-angular-dropdowns';
import { TextMaskModule } from 'angular2-text-mask';

import { AddresseeRoutingModule } from './addressee.routing-module';
import { NDDTabsbarModule } from './../../shared/ndd-ng-tabsbar/component/ndd-ng-tabsbar.module';
import { NDDTitlebarModule } from './../../shared/ndd-ng-titlebar/component/ndd-ng-titlebar.module';
import { AddresseeListComponent } from './addressee-list/addressee-list.component';
import { AddresseeGridService, AddresseeResolveService, AddresseeService } from './shared/addressee.service';

@NgModule({
    imports: [
        SharedModule,
        GridModule,
        NDDTitlebarModule,
        NDDTabsbarModule,
        TextMaskModule,
        AddresseeRoutingModule,
    ],
    exports: [],
    declarations: [
        AddresseeListComponent,
        AddresseeViewComponent,
    ],
    providers: [
        AddresseeService,
        AddresseeGridService,
        AddresseeResolveService,
    ],
})

export class AddresseeModule {
    //
}
