import { NgModule } from '@angular/core';
import { GridModule } from '@progress/kendo-angular-grid';
import { UiSwitchModule } from 'angular2-ui-switch';
import { TextMaskModule } from 'angular2-text-mask';
import { ProductGridService, ProductService, ProductResolveService } from './shared/product.service';
import { ProducRoutingModule } from './product-routing.module';
import { NDDTitlebarModule } from '../../shared/ndd-ng-titlebar/component';
import { NDDTabsbarModule } from '../../shared/ndd-ng-tabsbar/component';
import { SharedModule } from '../../shared/shared.module';
import { ProductListComponent } from './product-list/product-list.component';

@NgModule({
    imports: [
        ProducRoutingModule,
        GridModule,
        SharedModule,
        UiSwitchModule,
        NDDTitlebarModule,
        NDDTabsbarModule,
        TextMaskModule,
    ],
    exports: [],
    declarations: [
        ProductListComponent,
    ],
    providers: [ProductGridService, ProductService, ProductResolveService ],
})
export class ProductModule {

}
