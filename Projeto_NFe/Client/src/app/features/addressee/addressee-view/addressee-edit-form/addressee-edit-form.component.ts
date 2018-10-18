import { Router, ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs/Subject';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Component, OnInit, OnDestroy } from '@angular/core';

import { Addressee, AddresseeUpdateCommand } from './../../shared/addressee.model';
import { AddresseeService, AddresseeResolveService } from './../../shared/addressee.service';
import { PersonType } from './../../../shared/person-type.enum';

@Component({
    templateUrl: './addressee-edit-form.component.html',
})

export class AddresseeEditFormComponent implements OnInit, OnDestroy {
    public addressee: Addressee;
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
        private service: AddresseeService,
        private router: Router,
        private route: ActivatedRoute,
        private resolver: AddresseeResolveService) {
        this.arrangeForm();
    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((addressee: Addressee) => {
                this.isLoading = false;
                this.addressee = Object.assign(new Addressee(), addressee);
                this.populateForm();
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public onSubmit(): void {
        this.isLoading = true;
        const addresseeUpdateCommand: AddresseeUpdateCommand
            = new AddresseeUpdateCommand(this.formModel.value, this.addressee.id);
        this.service.update(addresseeUpdateCommand)
            .take(1)
            .subscribe(() => {
                this.isLoading = false;
                this.resolver.resolveFromRouteAndNotify();
                alert('Destinatario editado com sucesso');
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
                number: ['', [Validators.required, Validators.pattern('[0-9]+')]],
                neighborhood: ['', Validators.required],
                city: ['', Validators.required],
                state: ['', Validators.required],
                country: ['', Validators.required],
            }),
        });
    }

    private populateForm(): void {
        this.formModel.patchValue({
            businessName: this.addressee.businessName,
            personType: this.addressee.personType.toString(),
            address: {
                streetName: this.addressee.streetName,
                number: this.addressee.number,
                neighborhood: this.addressee.neighborhood,
                city: this.addressee.city,
                state: this.addressee.state,
                country: this.addressee.country,
            },
        });
        if (this.addressee.personType.toString() === PersonType.PERSON) {
            this.populateFormPerson();
        } else {
            this.populateFormEnterprise();
        }
    }

    private populateFormPerson(): void {
        this.formModel.addControl('person', this.person);
        this.formModel.patchValue({
            person: {
                cpf: this.addressee.cpf,
            },
        });
    }

    private populateFormEnterprise(): void {
        this.formModel.addControl('enterprise', this.enterprise);
        this.formModel.patchValue({
            enterprise: {
                cnpj: this.addressee.cnpj,
                stateRegistration: this.addressee.stateRegistration,
                corporateName: this.addressee.corporateName,
            },
        });
    }
}
