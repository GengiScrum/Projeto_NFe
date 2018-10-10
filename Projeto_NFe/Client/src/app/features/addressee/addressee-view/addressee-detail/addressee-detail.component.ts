import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';

import { Address } from './../../../address/address.model';
import { Addressee } from './../../shared/addressee.model';
import { AddresseeResolveService } from './../../shared/addressee.service';

@Component({
    templateUrl: './addressee-detail.component.html',
})

export class AddresseeDetailComponent implements OnInit, OnDestroy {
    public address: Address;
    public addressee: Addressee;
    public isLoading: boolean = false;
    public documentNumber: string;
    public documentType: string;

    public ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: AddresseeResolveService, private router: Router, private route: ActivatedRoute) {

    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.resolver.onChanges.takeUntil(this.ngUnsubscribe).subscribe((addressee: Addressee) => {
            this.addressee = Object.assign(new Addressee(), addressee);
            this.address = new Address(this.addressee);
            this.isLoading = false;
            this.setDocument();
        });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public onEdit(): void {
        this.router.navigate(['editar'], { relativeTo: this.route, skipLocationChange: true });
    }

    public redirect(): void {
        this.router.navigate(['/destinatarios']);
    }

    private setDocument(): void {
        if (this.addressee.cpf) {
            this.documentNumber = this.addressee.cpf;
            this.documentType = 'CPF';
        } else {
            this.documentNumber = this.addressee.cnpj;
            this.documentType = 'CNPJ';
        }
    }
}
