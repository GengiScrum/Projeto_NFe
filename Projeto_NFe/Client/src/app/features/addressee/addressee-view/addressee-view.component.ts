import { Subject } from 'rxjs/Subject';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Addressee } from './../shared/addressee.model';
import { AddresseeResolveService } from './../shared/addressee.service';

@Component({
    templateUrl: './addressee-view.component.html',
})

export class AddresseeViewComponent implements OnInit, OnDestroy{
    public addressee: Addressee;
    public infoItems: object[];
    public title: string;
    public returnRoute: string = '/destinatarios';

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: AddresseeResolveService) {

    }

    public ngOnInit(): void {
        this.resolver.onChanges.takeUntil(this.ngUnsubscribe).subscribe((addressee: Addressee) => {
            this.addressee = addressee; this.createProperty(); });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    private createProperty(): void {
        this.title = this.addressee.businessName;
        const document: string = this.setDocument();

        this.infoItems = [
            {
                value: document,
                description: document,
            },
        ];
    }

    private setDocument(): string {
        if (this.addressee.cpf === null) {
            return 'CNPJ: ' + this.addressee.cnpj;
        }else {
            return 'CPF: ' + this.addressee.cpf;
        }
    }
}
