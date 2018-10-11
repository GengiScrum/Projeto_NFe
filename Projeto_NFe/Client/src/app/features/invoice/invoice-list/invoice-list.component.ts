import { Router, ActivatedRoute } from '@angular/router';
import { Component } from '@angular/core';
import { SelectionEvent } from '@progress/kendo-angular-grid/dist/es2015/selection/selection.service';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid/dist/es2015/data/change-event-args.interface';
import { InvoiceGridService, InvoiceService } from './../shared/invoice.service';
import { GridUtilsComponent } from './../../../shared/grid-utils/grid-utils-component';

@Component({
    templateUrl: './invoice-list.component.html',
})
export class InvoiceListComponent extends GridUtilsComponent {
    constructor(private gridService: InvoiceGridService,
        private invoiceService: InvoiceService,
        private router: Router,
        private route: ActivatedRoute) {
        super();
        this.gridService.query(this.createFormattedState());
    }

    public dataStateChange(state: DataStateChangeEvent): void {
        this.state = state;
        this.selectedRows = [];
        this.gridService.query(this.createFormattedState());
    }

    public onSelectionChange(event: SelectionEvent): void {
        this.updateSelectedRows(event.selectedRows, true);
        this.updateSelectedRows(event.deselectedRows, false);
    }
}
