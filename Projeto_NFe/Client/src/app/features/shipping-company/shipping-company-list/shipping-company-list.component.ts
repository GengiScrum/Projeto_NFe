import { Router, ActivatedRoute } from '@angular/router';
import { GridUtilsComponent } from './../../../shared/grid-utils/grid-utils-component';
import { ShippingCompanyGridService } from './../shared/shipping-company.service';
import { Component } from '@angular/core';
import { DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';

@Component({
    templateUrl: './shipping-company-list.component.html',
})

export class ShippingCompanyListComponent extends GridUtilsComponent {
    constructor(private gridService: ShippingCompanyGridService,
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
}
