import { Component } from '@angular/core';
import { DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';
import { ActivatedRoute, Router } from '@angular/router';
import { GridUtilsComponent } from './../../../shared/grid-utils/grid-utils-component';
import { ProductGridService, ProductService } from '../shared/product.service';
import { ProductRemoveCommand } from '../shared/product.model';

@Component({
    selector: 'ndd-product-list',
    templateUrl: './product-list.component.html',
})
export class ProductListComponent extends GridUtilsComponent {
    constructor(private gridService: ProductGridService,
        private productService: ProductService,
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

    public deleteProduct(): void {
        this.gridService.loading = true;
        const productRemoveCommand: ProductRemoveCommand = new ProductRemoveCommand(this.getSelectedEntities());
        this.productService.remove(productRemoveCommand).take(1).do(() => this.gridService.loading = false).subscribe(() => {
            this.selectedRows = [];
            this.gridService.query(this.createFormattedState());
        });
    }

    public redirectOpenProduct(): void {
        this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`], { relativeTo: this.route });
    }

    public onClick(): void {
        this.router.navigate(['./cadastrar'], { relativeTo: this.route });
    }
}
