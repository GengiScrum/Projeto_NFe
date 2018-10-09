import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { Issuer } from './../shared/issuer.model';
import { IssuerResolveService } from './../shared/issuer.service';

@Component({
    templateUrl: './issuer-view.component.html',
})
export class IssuerViewComponent implements OnInit, OnDestroy{
    public issuer: Issuer;
    public infoItems: object[];
    public title: string;
    public returnRoute: string = '/emitentes';

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: IssuerResolveService) {

    }

    public ngOnInit(): void {
        this.resolver.onChanges.takeUntil(this.ngUnsubscribe).subscribe((issuer: Issuer) => { this.issuer = issuer; this.createProperty(); });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    private createProperty(): void {
        this.title = this.issuer.businessName;
        const cnpj: string = 'CNPJ: ' + this.issuer.cnpj;
        const stateRegistration: string = 'Inscrição Estadual: ' + this.issuer.stateRegistration;
        const municipalRegistration: string = 'Inscrição Municipal: ' + this.issuer.municipalRegistration;

        this.infoItems = [
            {
                value: cnpj,
                description: cnpj,
            },
            {
                value: stateRegistration,
                description: stateRegistration,
            },
            {
                value: municipalRegistration,
                description: municipalRegistration,
            },
        ];
    }
}
