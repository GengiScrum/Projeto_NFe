import { Router, ActivatedRoute } from '@angular/router';
import { Component } from '@angular/core';
import { DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';

import { GridUtilsComponent } from './../../../shared/grid-utils/grid-utils-component';

import { ShippingCompanyGridService, ShippingCompanyService } from './../shared/shipping-company.service';
import { ShippingCompanyRemoveCommand } from '../shared/shipping-company.model';

@Component({
    templateUrl: './shipping-company-list.component.html',
})

export class ShippingCompanyListComponent extends GridUtilsComponent {
    constructor(private gridService: ShippingCompanyGridService,
        private shippingCompanyService: ShippingCompanyService,
        private router: Router,
        private route: ActivatedRoute) {
        super();
        this.gridService.query(this.createFormattedState());
    }

    public dataStateChange(event: DataStateChangeEvent): void {
        this.state = event;
        this.selectedRows = [];
        this.gridService.query(this.createFormattedState());
    }

    public onSelectionChange(event: SelectionEvent): void {
        this.updateSelectedRows(event.selectedRows, true);
        this.updateSelectedRows(event.deselectedRows, false);
    }

    public redirectOpenShippingCompany(): void {
        this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`],
            { relativeTo: this.route });
    }

    public onClick(): void {
        this.router.navigate(['./cadastrar'], { relativeTo: this.route });
    }

    public deleteShippingCompany(): void {
        this.gridService.loading = true;
        const shippingCompanyRemoveCommand: ShippingCompanyRemoveCommand = new ShippingCompanyRemoveCommand(this.getSelectedEntities());
        this.shippingCompanyService
            .remove(shippingCompanyRemoveCommand)
            .take(1)
            .do(() => this.gridService.loading = false)
            .subscribe(() => {
                this.selectedRows = [];
                alert('Transportadores removidos com sucesso.');
                this.gridService.query(this.createFormattedState());
            });
    }
}
