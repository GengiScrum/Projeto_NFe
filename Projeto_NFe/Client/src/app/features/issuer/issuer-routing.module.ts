import { IssuerEditFormComponent } from './issuer-view/issuer-edit-form/issuer-edit-form.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { IssuerListComponent } from './issuer-list/issuer-list.component';
import { IssuerRegisterFormComponent } from './issuer-register-form/issuer-register-form.component';
import { IssuerResolveService } from './shared/issuer.service';
import { IssuerViewComponent } from './issuer-view/issuer-view.component';
import { IssuerDetailComponent } from './issuer-view/issuer-detail/issuer-detail.component';

const issuerRoutes: Routes = [
    {
        path: '',
        component: IssuerListComponent,
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
                component: IssuerRegisterFormComponent,
            },
        ],
    },
    {
        path: ':issuerId',
        resolve: {
            issuer: IssuerResolveService,
        },
        data: {
            breadcrumbOptions: {
                breadcrumbId: 'issuer',
            },
        },
        children: [
            {
                path: '',
                component: IssuerViewComponent,
                children: [
                    {
                        path: '',
                        redirectTo: 'info',
                        pathMatch: 'full',
                    },
                    {
                        path: 'info',
                        children: [
                            {
                                path: '',
                                component: IssuerDetailComponent,
                            },
                            {
                                path: 'editar',
                                component: IssuerEditFormComponent,
                                data: {
                                    breadcrumbOptions: {
                                        breadcrumbLabel: 'Editar',
                                    },
                                },
                            },
                        ],
                    },
                ],
            },
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(issuerRoutes)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})
export class IssuerRoutingModule {

}
