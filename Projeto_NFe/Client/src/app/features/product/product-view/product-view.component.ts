import { Component } from '@angular/core';
import { OnDestroy, OnInit } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { ProductResolveService } from './../shared/product.service';
import { Product } from './../shared/product.model';

@Component({
    templateUrl: './product-view.component.html',
})

export class ProductViewComponent implements OnInit, OnDestroy {
    public product: Product;
    public infoItems: object[];
    public title: string;
    public returnRoute: string = '/produtos';

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: ProductResolveService) {

    }

    public ngOnInit(): void {
        this.resolver.onChanges.takeUntil(this.ngUnsubscribe).subscribe((product: Product) => {
            this.product = product;
            this.createProperty();
        });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }
    private createProperty(): void {
        this.title = this.product.description;
        const unitaryValue: string = 'Valor Unitário: R$ ' + this.product.unitaryValue;

        this.infoItems = [
            {
                value: unitaryValue,
                description: unitaryValue,
            },
        ];
    }
}
