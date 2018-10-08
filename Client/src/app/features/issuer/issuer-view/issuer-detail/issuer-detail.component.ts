import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Issuer } from './../../shared/issuer.model';
import { Subject } from 'rxjs/Subject';
import { IssuerResolveService } from './../../shared/issuer.service';
import { Address } from './../../../address/address.model';

@Component({
    templateUrl: './issuer-detail.component.html',
})
export class IssuerDetailComponent implements OnInit, OnDestroy {
    public address: Address;
    public issuer: Issuer;
    public isLoading: boolean = false;

    public ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: IssuerResolveService, private router: Router, private route: ActivatedRoute) {

    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.resolver.onChanges.takeUntil(this.ngUnsubscribe).subscribe((issuer: Issuer) => {
            this.issuer = Object.assign(new Issuer(), issuer);
            this.address = new Address(this.issuer);
            this.isLoading = false;
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
        this.router.navigate(['/emitentes']);
    }
}
