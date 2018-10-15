import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';

import { ShippingCompany, ShippingCompanyUpdateCommand } from './../../shared/shipping-company.model';
import { ShippingCompanyService, ShippingCompanyResolveService } from './../../shared/shipping-company.service';
import { PersonType } from './../../../shared/person-type.enum';

@Component({
    templateUrl: './shipping-company-edit-form.component.html',
})
export class ShippingCompanyEditFormComponent implements OnInit, OnDestroy {
    public shippingCompany: ShippingCompany;
    public isLoading: boolean = false;
    public formModel: FormGroup;
    public person: FormGroup = this.fb.group({
        cpf: ['', Validators.required],
    });

    public enterprise: FormGroup = this.fb.group({
        cnpj: ['', Validators.required],
        corporateName: ['', Validators.required],
        stateRegistration: ['', Validators.required],
    });
    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private fb: FormBuilder,
        private service: ShippingCompanyService,
        private router: Router,
        private route: ActivatedRoute,
        private resolver: ShippingCompanyResolveService) {
        this.arrangeForm();
    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((shippingCompany: ShippingCompany) => {
                this.isLoading = false;
                this.shippingCompany = Object.assign(new ShippingCompany(), shippingCompany);
                this.populateForm();
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public onSubmit(): void {
        this.isLoading = true;
        const shippingCompanyUpdateCommand: ShippingCompanyUpdateCommand =
            new ShippingCompanyUpdateCommand(this.formModel.value, this.shippingCompany.id);
        this.service.update(shippingCompanyUpdateCommand)
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

    private arrangeForm(): void {
        this.formModel = this.fb.group({
            businessName: ['', Validators.required],
            personType: ['1', Validators.required],
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

    private populateForm(): void {
        this.formModel.patchValue({
            businessName: this.shippingCompany.businessName,
            personType: this.shippingCompany.personType.toString(),
            address: {
                streetName: this.shippingCompany.streetName,
                number: this.shippingCompany.number,
                neighborhood: this.shippingCompany.neighborhood,
                city: this.shippingCompany.city,
                state: this.shippingCompany.state,
                country: this.shippingCompany.country,
            },
        });
        if (this.shippingCompany.personType.toString() === PersonType.PERSON) {
            this.populateFormPerson();
        } else {
            this.populateFormEnterprise();
        }
    }

    private populateFormPerson(): void {
        this.formModel.addControl('person', this.person);
        this.formModel.patchValue({
            person: {
                cpf: this.shippingCompany.cpf,
            },
        });
    }

    private populateFormEnterprise(): void {
        this.formModel.addControl('enterprise', this.enterprise);
        this.formModel.patchValue({
            enterprise: {
                cnpj: this.shippingCompany.cnpj,
                stateRegistration: this.shippingCompany.stateRegistration,
                corporateName: this.shippingCompany.corporateName,
            },
        });
    }
}
