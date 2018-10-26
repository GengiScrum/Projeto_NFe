import { DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs/Subject';
import { GridUtilsComponent } from './../../../../shared/grid-utils/grid-utils-component';

import { ProductService } from './../../../product/shared/product.service';
import { Product } from './../../../product/shared/product.model';
import { InvoiceProductGridService, InvoiceResolveService, InvoiceService } from './../../shared/invoice.service';
import { Invoice, InvoiceAddProductCommand, InvoiceRemoveProductsCommand, SoldProduct } from '../../shared/invoice.model';

@Component({
    templateUrl: './invoice-product-list.component.html',
})

export class InvoiceProductListComponent extends GridUtilsComponent implements OnInit, OnDestroy {
    public products: Product[];
    public invoice: Invoice;
    public isLoading: boolean = false;
    public formSoldProduct: FormGroup = this.fb.group({
        quantity: ['', Validators.required],
        productId: ['', Validators.required],
    });
    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private fb: FormBuilder,
        private productService: ProductService,
        private invoiceService: InvoiceService,
        private productGridService: InvoiceProductGridService,
        private resolver: InvoiceResolveService,
        private router: Router) {
        super();
    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.productService.getAll()
            .take(1)
            .subscribe((products: Product[]) => this.products = products);
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((invoice: Invoice) => {
                this.invoice = Object.assign(new Invoice(), invoice);
                this.isLoading = false;
                this.productGridService.query(this.invoice.id, this.createFormattedState());
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public redirectOpenProduct(): void {
        this.router.navigate(['/produtos/', `${this.getSelectedEntities()[0].productId}`]);
    }

    public onAdd(): void {
        this.isLoading = true;
        const cmd: InvoiceAddProductCommand =
            new InvoiceAddProductCommand(this.formSoldProduct.value, this.invoice.id);

        if (!this.invoice.soldProducts.find((sp: SoldProduct) => sp.productId.toString() === cmd.soldProduct.productId.toString())) {
            this.invoiceService.addProduct(cmd)
                .take(1)
                .subscribe(() => {
                    this.isLoading = false;
                    this.resolver.resolveFromRouteAndNotify();
                    alert('Produto adicionado à nota com sucesso.');
                    this.formSoldProduct.reset();
                });
        } else {
            alert('Este produto já está adicionado.');
            this.isLoading = false;
        }
    }

    public deleteProducts(): void {
        this.isLoading = true;
        const cmd: InvoiceRemoveProductsCommand =
            new InvoiceRemoveProductsCommand(this.getSelectedEntities(), this.invoice.id);
        this.invoiceService.removeProducts(cmd)
            .take(1)
            .subscribe(() => {
                this.isLoading = false;
                this.resolver.resolveFromRouteAndNotify();
                alert('Produtos removidos da nota com sucesso.');
            });
    }

    public dataStateChange(state: DataStateChangeEvent): void {
        this.state = state;
        this.productGridService.query(this.invoice.id, this.createFormattedState());
        this.selectedRows = [];
    }

    public onSelectionChange(event: SelectionEvent): void {
        this.updateSelectedRows(event.selectedRows, true);
        this.updateSelectedRows(event.deselectedRows, false);
    }
}
