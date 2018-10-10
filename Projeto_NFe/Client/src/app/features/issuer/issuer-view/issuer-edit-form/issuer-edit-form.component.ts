import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { Issuer, IssuerUpdateCommand } from './../../shared/issuer.model';
import { IssuerService, IssuerResolveService } from './../../shared/issuer.service';

@Component({
    templateUrl: './issuer-edit-form.component.html',
})
export class IssuerEditFormComponent implements OnInit, OnDestroy {
    public issuer: Issuer;
    public isLoading: boolean = false;
    public form: FormGroup;
    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private fb: FormBuilder,
        private service: IssuerService,
        private router: Router,
        private route: ActivatedRoute,
        private resolver: IssuerResolveService) {
        this.form = this.fb.group({
            details: this.fb.group({
                businessName: ['', Validators.required],
                corporateName: ['', Validators.required],
                cnpj: ['', Validators.required],
                stateRegistration: ['', Validators.required],
                municipalRegistration: ['', Validators.required],
            }),
            address: this.fb.group({
                streetName: ['', Validators.required],
                number: ['', Validators.required],
                neighborhood: ['', Validators.required],
                city: ['', Validators.required],
                state: ['', Validators.required],
                country: ['', Validators.required],
            }),
        });
    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.resolver.onChanges.takeUntil(this.ngUnsubscribe).subscribe((issuer: Issuer) => {
            this.isLoading = false;
            this.issuer = Object.assign(new Issuer(), issuer);
            this.populateForm();
        });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public onUpdate(): void {
        this.isLoading = true;
        const issuerUpdateCommand: IssuerUpdateCommand =
            new IssuerUpdateCommand(this.form.get('details').value, this.form.get('address').value, this.issuer.id);
        this.service.update(issuerUpdateCommand)
            .take(1)
            .subscribe(() => {
                this.isLoading = false;
                this.resolver.resolveFromRouteAndNotify();
                this.redirect();
            });
    }

    public redirect(): void {
        this.router.navigate(['../'], { relativeTo: this.route });
    }

    private populateForm(): void {
        this.form.patchValue({
            details: {
                businessName: this.issuer.businessName,
                corporateName: this.issuer.corporateName,
                cnpj: this.issuer.cnpj,
                stateRegistration: this.issuer.stateRegistration,
                municipalRegistration: this.issuer.municipalRegistration,
            },
            address: {
                streetName: this.issuer.streetName,
                number: this.issuer.number,
                neighborhood: this.issuer.neighborhood,
                city: this.issuer.city,
                state: this.issuer.state,
                country: this.issuer.country,
            },
        });
    }
}
