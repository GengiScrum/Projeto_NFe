import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductListComponent } from './product-list/product-list.component';

const productRoutes: Routes = [
    {
        path: '',
        component: ProductListComponent,
    },
    {
        path: 'cadastrar',
        data: {
            breadcrumbOptions: {
                breadcrumbLabel: 'Cadastrar',
            },
        },
        children: [
            {
                path: '',
                /*component: IssuerRegisterFormComponent,*/
            },
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(productRoutes)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})

export class ProducRoutingModule {

}
