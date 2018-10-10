import { AddresseeRemoveCommand } from './../shared/addressee.model';
import { DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';
import { Router, ActivatedRoute } from '@angular/router';
import { Component } from '@angular/core';
import { AddresseeGridService, AddresseeService } from './../shared/addressee.service';
import { GridUtilsComponent } from './../../../shared/grid-utils/grid-utils-component';

@Component({
    templateUrl: './addressee-list.component.html',
})

export class AddresseeListComponent extends GridUtilsComponent {
    constructor(private gridService: AddresseeGridService,
        private addresseeService: AddresseeService,
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

    public deleteAddressee(): void {
        this.gridService.loading = true;
        const addresseeRemoveCommand: AddresseeRemoveCommand = new AddresseeRemoveCommand(this.getSelectedEntities());
        this.addresseeService.remove(addresseeRemoveCommand).take(1).do(() => this.gridService.loading = false).subscribe(() => {
            this.selectedRows = [];
            this.gridService.query(this.createFormattedState());
        });
    }

    public onClick(): void {
        this.router.navigate(['./cadastrar'], { relativeTo: this.route });
    }

    public redirectOpenAddressee(): void {
        this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`], { relativeTo: this.route });
    }
}
