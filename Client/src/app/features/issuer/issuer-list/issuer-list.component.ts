import { IssuerRemoveCommand } from './../shared/issuer.model';
import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { GridUtilsComponent } from './../../../shared/grid-utils/grid-utils-component';

import { IssuerGridService, IssuerService } from './../shared/issuer.service';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid/dist/es2015/data/change-event-args.interface';
import { SelectionEvent } from '@progress/kendo-angular-grid/dist/es2015/selection/selection.service';

@Component({
    selector: 'ndd-issuer-list',
    templateUrl: './issuer-list.component.html',
})
export class IssuerListComponent extends GridUtilsComponent {
    constructor(private gridService: IssuerGridService,
        private issuerService: IssuerService,
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

    public deleteIssuer(): void {
        this.gridService.loading = true;
        const issuerRemoveCommand: IssuerRemoveCommand = new IssuerRemoveCommand(this.getSelectedEntities());
        this.issuerService.remove(issuerRemoveCommand).take(1).do(() => this.gridService.loading = false).subscribe(() => {
            this.selectedRows = [];
            this.gridService.query(this.createFormattedState());
        });
    }

    public redirectOpenIssuer(): void {
        this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`], { relativeTo: this.route });
    }

    public onClick(): void {
        this.router.navigate(['./cadastrar'], { relativeTo: this.route });
    }
}
