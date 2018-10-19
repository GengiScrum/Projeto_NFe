import { NgModule } from '@angular/core';
import { GridModule } from '@progress/kendo-angular-grid/dist/es2015/grid.module';
import { UiSwitchModule } from 'angular2-ui-switch';
import { SharedModule } from '../../shared/shared.module';

import { ProductGridService, ProductResolveService } from './shared/product.service';
import { ProducRoutingModule } from './product-routing.module';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailComponent } from './product-view/product-detail/product-detail.component';
import { ProductViewComponent } from './product-view/product-view.component';
import { ProductRegisterFormComponent } from './product-register-form/product-register-form.component';
import { ProductFormComponent } from './product-form/product-form.component';
import { ProductEditFormComponent } from './product-view/product-edit-form/product-edit-form.component';
import { NDDTabsbarModule } from './../../shared/ndd-ng-tabsbar/component/ndd-ng-tabsbar.module';
import { NDDTitlebarModule } from './../../shared/ndd-ng-titlebar/component/ndd-ng-titlebar.module';
import { ProductSharedModule } from './shared/product-shared.module';

@NgModule({
    imports: [
        ProducRoutingModule,
        GridModule,
        SharedModule,
        UiSwitchModule,
        NDDTitlebarModule,
        NDDTabsbarModule,
        ProductSharedModule,
    ],
    exports: [],
    declarations: [
        ProductListComponent,
        ProductFormComponent,
        ProductRegisterFormComponent,
        ProductViewComponent,
        ProductDetailComponent,
        ProductEditFormComponent,
    ],
    providers: [ProductGridService, ProductResolveService ],
})
export class ProductModule {

}
