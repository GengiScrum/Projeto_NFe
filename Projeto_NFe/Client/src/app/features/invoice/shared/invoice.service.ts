import { Router } from '@angular/router';
import { NDDBreadcrumbService } from './../../../shared/ndd-ng-breadcrumb/component/ndd-ng-breadcrumb.service';
import { Invoice, InvoiceRemoveCommand, InvoiceRegisterCommand, InvoiceUpdateCommand } from './invoice.model';
import { BaseService } from './../../../core/utils/base-service';
import { Observable } from 'rxjs/Observable';
import { State, toODataString } from '@progress/kendo-data-query';
import { CORE_CONFIG_TOKEN, ICoreConfig } from './../../../core/core.config';
import { HttpClient } from '@angular/common/http';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Injectable, Inject } from '@angular/core';
import { AbstractResolveService } from './../../../core/utils/abstract-resolve.service';
import { map } from 'rxjs/operators';

@Injectable()
export class InvoiceGridService extends BehaviorSubject<GridDataResult>{
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
            .get(`${this.config.apiEndpoint}api/invoices?${queryStr}`)
            .map((response: any): GridDataResult => ({
                data: response.items,
                total: parseInt(response.count, 10),
            }))
            .do(() => this.loading = false);
    }
}

@Injectable()
export class InvoiceService extends BaseService {
    private api: string;

    constructor( @Inject(CORE_CONFIG_TOKEN) config: ICoreConfig,
        public http: HttpClient) {
        super(http);
        this.api = `${config.apiEndpoint}api/invoices`;
    }

    public get(id: number): Observable<Invoice> {
        return this.http.get(`${this.api}/${id}`).map((response: Invoice) => response);
    }

    public getAll(): Observable<Invoice[]> {
        return this.http.get(`${this.api}`).map((response: Invoice[]) => response);
    }

    public getByName(filterValue: string): any {
        const queryStr: string = `skip=0&$count=true&$filter=contains(tolower(NomeFantasia),tolower('${filterValue}'))`;

        return this.http
            .get(`${this.api}?${queryStr}`)
            .pipe(map((response: any) => response.items));
    }

    public remove(invoiceCmd: InvoiceRemoveCommand): Observable<Boolean> {
        return this.deleteRequestWithBody(`${this.api}`, invoiceCmd);
    }

    public register(invoiceCmd: InvoiceRegisterCommand): Observable<Invoice> {
        return this.http.post(this.api, invoiceCmd).map((response: Invoice) => response);
    }

    public update(invoiceCmd: InvoiceUpdateCommand): Observable<Invoice> {
        return this.http.put(this.api, invoiceCmd).map((response: Invoice) => response);
    }
}

@Injectable()
export class InvoiceResolveService extends AbstractResolveService<Invoice> {
    constructor(private service: InvoiceService,
        private breadcrumbService: NDDBreadcrumbService,
        router: Router) {
        super(router);
        this.paramsProperty = 'invoiceId';
    }

    protected loadEntity(entityId: number): Observable<Invoice> {
        return this.service.get(entityId).take(1).do((invoice: Invoice) => this.breadcrumbService.setMetadata({
            id: 'invoice',
            label: invoice.id.toString(),
            sizeLimit: true,
        }));
    }
}
