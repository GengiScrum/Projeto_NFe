import { Observable } from 'rxjs/Observable';
import { State, toODataString } from '@progress/kendo-data-query';
import { HttpClient } from '@angular/common/http';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Injectable, Inject } from '@angular/core';
import { CORE_CONFIG_TOKEN, ICoreConfig } from './../../../core/core.config';

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
                data: response.items,
                total: parseInt(response.cound, 10),
            }))
            .do(() => this.loading = false);
    }
}
