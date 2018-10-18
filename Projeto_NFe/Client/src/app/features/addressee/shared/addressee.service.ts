import { Observable } from 'rxjs/Observable';
import { State, toODataString } from '@progress/kendo-data-query';
import { HttpClient } from '@angular/common/http';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Injectable, Inject } from '@angular/core';
import { Router } from '@angular/router';

import { CORE_CONFIG_TOKEN, ICoreConfig } from './../../../core/core.config';
import { AbstractResolveService } from '../../../core/utils/abstract-resolve.service';
import { Addressee, AddresseeRemoveCommand, AddresseeRegisterCommand, AddresseeListViewModel, AddresseeUpdateCommand } from './addressee.model';
import { BaseService } from './../../../core/utils/base-service';
import { NDDBreadcrumbService } from './../../../shared/ndd-ng-breadcrumb/component/ndd-ng-breadcrumb.service';

@Injectable()
export class AddresseeGridService extends BehaviorSubject<GridDataResult>{
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
            .get(`${this.config.apiEndpoint}api/addressees?${queryStr}`)
            .map((response: any): GridDataResult => ({
                data: AddresseeListViewModel.createArray(response.items),
                total: parseInt(response.count, 10),
            }))
            .do(() => this.loading = false);
    }
}

@Injectable()
export class AddresseeService extends BaseService {
    private api: string;

    constructor( @Inject(CORE_CONFIG_TOKEN) config: ICoreConfig,
        public http: HttpClient) {
        super(http);
        this.api = `${config.apiEndpoint}api/addressees`;
    }

    public get(id: number): Observable<Addressee> {
        return this.http.get(`${this.api}/${id}`).map((response: Addressee) => response);
    }

    public getAll(): Observable<Addressee[]> {
        return this.http.get(`${this.api}`).map((response: Addressee[]) => response);
    }

    public remove(addresseeCmd: AddresseeRemoveCommand): Observable<Boolean> {
        return this.deleteRequestWithBody(`${this.api}`, addresseeCmd);
    }

    public register(addresseeCmd: AddresseeRegisterCommand): Observable<Boolean> {
        return this.http.post(`${this.api}`, addresseeCmd).map((response: boolean) => response);
    }

    public update(addresseeCmd: AddresseeUpdateCommand): Observable<Boolean> {
        return this.http.put(`${this.api}`, addresseeCmd).map((response: boolean) => response);
    }
}

@Injectable()
export class AddresseeResolveService extends AbstractResolveService<Addressee> {
    constructor(private service: AddresseeService,
        private breadcrumbService: NDDBreadcrumbService,
        router: Router) {
        super(router);
        this.paramsProperty = 'addresseeId';
    }

    protected loadEntity(entityId: number): Observable<Addressee> {
        return this.service.get(entityId).take(1).do((addressee: Addressee) => this.breadcrumbService.setMetadata({
            id: 'addressee',
            label: addressee.businessName,
            sizeLimit: true,
        }));
    }
}
