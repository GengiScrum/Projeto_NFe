import { GridModule } from '@progress/kendo-angular-grid';
import { NgModule } from '@angular/core';
import { TextMaskModule } from 'angular2-text-mask';
import { RippleModule } from '@progress/kendo-angular-ripple'; 

import { AddresseeRoutingModule } from './addressee.routing-module';
import { NDDTabsbarModule } from './../../shared/ndd-ng-tabsbar/component/ndd-ng-tabsbar.module';
import { NDDTitlebarModule } from './../../shared/ndd-ng-titlebar/component/ndd-ng-titlebar.module';
import { AddresseeListComponent } from './addressee-list/addressee-list.component';
import { AddresseeGridService, AddresseeResolveService, AddresseeService } from './shared/addressee.service';
import { AddresseeDetailComponent } from './addressee-view/addressee-detail/addressee-detail.component';
import { AddresseeViewComponent } from './addressee-view/addressee-view.component';
import { SharedModule } from './../../shared/shared.module';
import { AddresseeRegisterFormComponent } from './addressee-register-form/addressee-register-form.component';
import { AddresseeFormComponent } from './addressee-form/addressee-form.component';
import { UiSwitchModule } from 'angular2-ui-switch';

@NgModule({
    imports: [
        SharedModule,
        GridModule,
        NDDTitlebarModule,
        NDDTabsbarModule,
        TextMaskModule,
        AddresseeRoutingModule,
        UiSwitchModule,
    ],
    exports: [],
    declarations: [
        AddresseeListComponent,
        AddresseeViewComponent,
        AddresseeDetailComponent,
        AddresseeFormComponent,
        AddresseeRegisterFormComponent,
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
