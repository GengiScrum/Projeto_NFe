import { DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';
import { Router, ActivatedRoute } from '@angular/router';
import { Component } from '@angular/core';
import { AddresseeGridService } from './../shared/addressee.service';
import { GridUtilsComponent } from './../../../shared/grid-utils/grid-utils-component';

@Component({
    templateUrl: './addressee-list.component.html',
})

export class AddresseeListComponent extends GridUtilsComponent {
    constructor(private gridService: AddresseeGridService,
        private router: Router,
        private route: ActivatedRoute) {
        super();
        this.gridService.query(this.createFormattedState());
    }

    public dataStateChange(state: DataStateChangeEvent): void {
        this.state = state;
        this.gridService.query(this.createFormattedState());
        this.selectedRows = [];
    }

    public onSelectionChange(event: SelectionEvent): void {
        this.updateSelectedRows(event.selectedRows, true);
        this.updateSelectedRows(event.deselectedRows, false);
    }

    public redirectOpenIssuer(): void {
        this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`], { relativeTo: this.route });
    }
}
