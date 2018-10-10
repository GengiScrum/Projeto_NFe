import { Router } from '@angular/router';
import { NDDBreadcrumbService } from './../../../shared/ndd-ng-breadcrumb/component/ndd-ng-breadcrumb.service';
import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';
import { GridDataResult } from '@progress/kendo-angular-grid/dist/es2015/data/data.collection';
import { State, toODataString } from '@progress/kendo-data-query';
import { CORE_CONFIG_TOKEN, ICoreConfig } from './../../../core/core.config';
import { BaseService } from './../../../core/utils/base-service';
import { Issuer, IssuerRemoveCommand, IssuerRegisterCommand, IssuerUpdateCommand } from './issuer.model';
import { map } from 'rxjs/operators';
import { AbstractResolveService } from './../../../core/utils/abstract-resolve.service';

@Injectable()
export class IssuerGridService extends BehaviorSubject<GridDataResult>{
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
            .get(`${this.config.apiEndpoint}api/issuers?${queryStr}`)
            .map((response: any): GridDataResult => ({
                data: response.items,
                total: parseInt(response.cound, 10),
            }))
            .do(() => this.loading = false);
    }
}

@Injectable()
export class IssuerService extends BaseService {
    private api: string;

    constructor( @Inject(CORE_CONFIG_TOKEN) config: ICoreConfig,
        public http: HttpClient) {
        super(http);
        this.api = `${config.apiEndpoint}api/issuers`;
    }

    public get(id: number): Observable<Issuer> {
        return this.http.get(`${this.api}/${id}`).map((response: Issuer) => response);
    }

    public getAll(): Observable<Issuer[]> {
        return this.http.get(`${this.api}`).map((response: Issuer[]) => response);
    }

    public getByName(filterValue: string): any {
        const queryStr: string = `skip=0&$count=true&$filter=contains(tolower(NomeFantasia),tolower('${filterValue}'))`;

        return this.http
            .get(`${this.api}?${queryStr}`)
            .pipe(map((response: any) => response.items));
    }

    public remove(issuerCmd: IssuerRemoveCommand): Observable<Boolean> {
        return this.deleteRequestWithBody(`${this.api}`, issuerCmd);
    }

    public register(issuerCmd: IssuerRegisterCommand): Observable<Issuer> {
        return this.http.post(this.api, issuerCmd).map((response: Issuer) => response);
    }

    public update(issuerCmd: IssuerUpdateCommand): Observable<Issuer> {
        return this.http.put(this.api, issuerCmd).map((response: Issuer) => response);
    }
}

@Injectable()
export class IssuerResolveService extends AbstractResolveService<Issuer> {
    constructor(private service: IssuerService,
        private breadcrumbService: NDDBreadcrumbService,
        router: Router) {
        super(router);
        this.paramsProperty = 'issuerId';
    }

    protected loadEntity(entityId: number): Observable<Issuer> {
        return this.service.get(entityId).take(1).do((issuer: Issuer) => this.breadcrumbService.setMetadata({
            id: 'issuer',
            label: issuer.businessName,
            sizeLimit: true,
        }));
    }
}
