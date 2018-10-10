import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LayoutComponent } from './core/layout/layout.component';

const appRoutes: Routes = [
    {
        path: 'page-not-found',
        loadChildren: './features/error-pages/page-not-found/page-not-found.module#PageNotFoundModule',
    },
    {
        path: '',
        component: LayoutComponent,
        children: [
            {
                path: '',
                redirectTo: 'notas-fiscais',
                pathMatch: 'full',
            },
            {
                path: 'notas-fiscais',
                loadChildren: './features/shipping-company/shipping-company.module#ShippingCompanyModule',
                data : {
                    breadcrumbOptions: {
                        breadcrumbLabel: 'Notas Fiscais',
                    },
                },
            },
            {
                path: 'transportadores',
                loadChildren: './features/shipping-company/shipping-company.module#ShippingCompanyModule',
                data: {
                    breadcrumbOptions: {
                        breadcrumbLabel: 'Transportadores',
                    },
                },
            },
            {
                path: 'emitentes',
                loadChildren: './features/issuer/issuer.module#IssuerModule',
                data: {
                    breadcrumbOptions: {
                        breadcrumbLabel: 'Emitentes',
                    },
                },
            },
            {
                path: 'produtos',
                loadChildren: './features/product/product.module#ProductModule',
                data: {
                    breadcrumbOptions: {
                        breadcrumbLabel: 'Produtos',
                    },
                },
            },
        ],
    },
    { path: '**', redirectTo: 'page-not-found', pathMatch: 'full' },
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes, {
        paramsInheritanceStrategy: 'always',
    })],
    exports: [RouterModule],
})
export class AppRoutingModule { }
