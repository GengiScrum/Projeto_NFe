import { Router, ActivatedRoute } from '@angular/router';
import { Component } from '@angular/core';
import { SelectionEvent } from '@progress/kendo-angular-grid/dist/es2015/selection/selection.service';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid/dist/es2015/data/change-event-args.interface';

import { InvoiceGridService, InvoiceService } from './../shared/invoice.service';
import { GridUtilsComponent } from './../../../shared/grid-utils/grid-utils-component';
import { InvoiceRemoveCommand } from '../../invoice/shared/invoice.model';

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

    public onClick(): void {
        this.router.navigate(['./cadastrar'], { relativeTo: this.route });
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

    public redirectOpenInvoice(): void {
        this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`],
            { relativeTo: this.route });
    }

    public deleteInvoice(): void {
        this.gridService.loading = true;
        const invoiceRemoveCommand: InvoiceRemoveCommand = new InvoiceRemoveCommand(this.getSelectedEntities());
        this.invoiceService
            .remove(invoiceRemoveCommand)
            .take(1)
            .do(() => this.gridService.loading = false)
            .subscribe(() => {
                this.selectedRows = [];
                alert('Notas fiscais removidas com sucesso.');
                this.gridService.query(this.createFormattedState());
            });
    }
}
