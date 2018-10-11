import { Router, ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs/Subject';
import { OnInit, OnDestroy, Component } from '@angular/core';
import { ProductResolveService } from './../../shared/product.service';
import { Product } from './../../shared/product.model';

@Component({
    templateUrl: './product-detail.component.html',
})

export class ProductDetailComponent implements OnInit, OnDestroy {
    public product: Product;
    public isLoading: boolean;

    public unSubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: ProductResolveService, private router: Router, private route: ActivatedRoute) {

    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.resolver.onChanges.takeUntil(this.unSubscribe).subscribe((product: Product) => {
            this.product = Object.assign(new Product(), product);
            this.isLoading = false;
        });
    }

    public ngOnDestroy(): void {
        this.unSubscribe.next();
        this.unSubscribe.complete();
    }

    public onEdit(): void {
        this.router.navigate(['editar'], { relativeTo: this.route, skipLocationChange: true});
    }

    public redirect(): void {
        this.router.navigate(['/produtos']);
    }
}
