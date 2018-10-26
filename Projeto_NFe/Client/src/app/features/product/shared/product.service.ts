import { Injectable, Inject } from '@angular/core';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { State, toODataString } from '@progress/kendo-data-query';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { CORE_CONFIG_TOKEN, ICoreConfig } from './../../../core/core.config';
import { BaseService } from './../../../core/utils/base-service';
import { Product, ProductRemoveCommand, ProductRegisterCommand, ProductUpdateCommand } from './product.model';
import { AbstractResolveService } from './../../../core/utils/abstract-resolve.service';
import { NDDBreadcrumbService } from './../../../shared/ndd-ng-breadcrumb/component/ndd-ng-breadcrumb.service';

@Injectable()
export class ProductGridService extends BehaviorSubject<GridDataResult> {
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
            .get(`${this.config.apiEndpoint}api/products?${queryStr}`)
            .map((response: any): GridDataResult => ({
                data: response.items,
                total: parseInt(response.count, 10),
            }))
            .do(() => this.loading = false);
    }
}

@Injectable()
export class ProductService extends BaseService {
    private api: string;

    constructor(@Inject(CORE_CONFIG_TOKEN) config: ICoreConfig,
        public http: HttpClient) {
        super(http);
        this.api = `${config.apiEndpoint}api/products`;
    }

    public get(id: number): Observable<Product> {
        return this.http.get(`${this.api}/${id}`).map((response: Product) => response);
    }

    public getAll(): Observable<Product[]> {
        return this.http.get(`${this.api}`).map((response: any) => response.items);
    }

    public remove(productCmd: ProductRemoveCommand): Observable<Boolean> {
        return this.deleteRequestWithBody(`${this.api}`, productCmd);
    }

    public register(productCmd: ProductRegisterCommand): Observable<Product> {
        return this.http.post(this.api, productCmd).map((response: Product) => response);
    }

    public update(productCmd: ProductUpdateCommand): Observable<Product> {
        return this.http.put(this.api, productCmd).map((response: Product) => response);
    }
}

@Injectable()
export class ProductResolveService extends AbstractResolveService<Product> {
    constructor(private service: ProductService,
        private breadcrumbService: NDDBreadcrumbService,
        router: Router) {
        super(router);
        this.paramsProperty = 'productId';
    }

    protected loadEntity(entityId: number): Observable<Product> {
        return this.service.get(entityId).take(1).do((product: Product) => this.breadcrumbService.setMetadata({
            id: 'product',
            label: product.description,
            sizeLimit: true,
        }));
    }
}
