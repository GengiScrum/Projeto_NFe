import { IssuerEditFormComponent } from './issuer-view/issuer-edit-form/issuer-edit-form.component';
import { NgModule } from '@angular/core';
import { GridModule } from '@progress/kendo-angular-grid/dist/es2015/grid.module';
import { UiSwitchModule } from 'angular2-ui-switch';
import { SharedModule } from './../../shared/shared.module';
import { IssuerGridService, IssuerService, IssuerResolveService } from './shared/issuer.service';
import { IssuerListComponent } from './issuer-list/issuer-list.component';
import { IssuerFormComponent } from './issuer-form/issuer-form.component';
import { IssuerRoutingModule } from './issuer-routing.module';
import { NDDTabsbarModule } from './../../shared/ndd-ng-tabsbar/component/ndd-ng-tabsbar.module';
import { NDDTitlebarModule } from './../../shared/ndd-ng-titlebar/component/ndd-ng-titlebar.module';
import { IssuerRegisterFormComponent } from './issuer-register-form/issuer-register-form.component';
import { IssuerViewComponent } from './issuer-view/issuer-view.component';
import { IssuerDetailComponent } from './issuer-view/issuer-detail/issuer-detail.component';
import { TextMaskModule } from 'angular2-text-mask';

@NgModule({
    imports: [
        IssuerRoutingModule,
        GridModule,
        SharedModule,
        UiSwitchModule,
        NDDTitlebarModule,
        NDDTabsbarModule,
        TextMaskModule,
    ],
    exports: [],
    declarations: [
        IssuerListComponent,
        IssuerFormComponent,
        IssuerRegisterFormComponent,
        IssuerViewComponent,
        IssuerDetailComponent,
        IssuerEditFormComponent,
    ],
    providers: [ IssuerGridService, IssuerService, IssuerResolveService ],
})
export class IssuerModule{

}
