import { Router } from '@angular/router';
import { State, toODataString } from '@progress/kendo-data-query';
import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { GridDataResult } from '@progress/kendo-angular-grid';

import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';

import { CORE_CONFIG_TOKEN, ICoreConfig } from './../../../core/core.config';
import { AbstractResolveService } from './../../../core/utils/abstract-resolve.service';
import { BaseService } from './../../../core/utils/base-service';
import { NDDBreadcrumbService } from './../../../shared/ndd-ng-breadcrumb/component/ndd-ng-breadcrumb.service';

import {
    ShippingCompany, ShippingCompanyRemoveCommand,
    ShippingCompanyUpdateCommand, ShippingCompanyRegisterCommand, ShippingCompanyListViewModel,
} from './shipping-company.model';

@Injectable()
export class ShippingCompanyGridService extends BehaviorSubject<GridDataResult> {
    public loading: boolean;

    constructor(private httpClient: HttpClient,
        @Inject(CORE_CONFIG_TOKEN) private config: ICoreConfig) {
        super(null);
    }

    public query(state: State): void {
        this.fetch(state).subscribe((result: GridDataResult) => super.next(result));
    }

    protected fetch(state: any): Observable<GridDataResult> {
        const queryStr: string = `${toODataString(state)}&$count=true`;
        this.loading = true;

        return this.httpClient
            .get(`${this.config.apiEndpoint}api/shippingcompanies?${queryStr}`)
            .map((response: any): GridDataResult => ({
                data: ShippingCompanyListViewModel.createArray(response.items),
                total: parseInt(response.count, 10),
            }))
            .do(() => this.loading = false);
    }
}

@Injectable()
export class ShippingCompanyService extends BaseService {
    private api: string;

    constructor(@Inject(CORE_CONFIG_TOKEN) config: ICoreConfig,
        public http: HttpClient) {
        super(http);
        this.api = `${config.apiEndpoint}api/shippingcompanies`;
    }

    public get(id: number): Observable<ShippingCompany> {
        return this.http.get(`${this.api}/${id}`).map((response: ShippingCompany) => response);
    }

    public remove(shippingCompanyCmd: ShippingCompanyRemoveCommand): Observable<Boolean> {
        return this.deleteRequestWithBody(`${this.api}`, shippingCompanyCmd);
    }

    public register(shippingCompanyCmd: ShippingCompanyRegisterCommand): Observable<ShippingCompany> {
        return this.http.post(this.api, shippingCompanyCmd).map((response: ShippingCompany) => response);
    }

    public update(shippingCompanyCmd: ShippingCompanyUpdateCommand): Observable<ShippingCompany> {
        return this.http.put(this.api, shippingCompanyCmd).map((response: ShippingCompany) => response);
    }
}

@Injectable()
export class ShippingCompanyResolveService extends AbstractResolveService<ShippingCompany> {

    constructor(private service: ShippingCompanyService,
        private breadcrumbService: NDDBreadcrumbService,
        router: Router) {
        super(router);
        this.paramsProperty = 'shippingCompanyId';
    }

    protected loadEntity(id: number): Observable<ShippingCompany> {
        return this.service
            .get(id)
            .take(1)
            .do((shippingCompany: ShippingCompany) => {
                this.breadcrumbService.setMetadata({
                    id: 'shippingCompany',
                    label: shippingCompany.businessName,
                    sizeLimit: true,
                });
            });
    }
}
