import { Router, ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs/Subject';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { OnInit, OnDestroy, Component } from '@angular/core';
import { Product, ProductUpdateCommand } from './../../shared/product.model';
import { ProductService, ProductResolveService } from './../../shared/product.service';

@Component({
    templateUrl:'./product-edit-form.component.html',
})

export class ProductEditFormComponent implements OnInit, OnDestroy{
    public product: Product;
    public isLoading: boolean;
    public form: FormGroup;
    public ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private fb: FormBuilder,
        private service: ProductService,
        private router: Router,
        private route: ActivatedRoute,
        private resolver: ProductResolveService,
    ) {
        this.form = this.fb.group({
            code: ['', Validators.required],
            description: ['', Validators.required],
            unitaryValue: ['', Validators.required],
        });
    }

    public ngOnInit(): void {
        this.isLoading = true;
        this.resolver.onChanges.takeUntil(this.ngUnsubscribe).subscribe((product: Product) => {
            this.isLoading = false;
            this.product = Object.assign(new Product(), product);
            this.populateForm();
        });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public onUpdate(): void {
        this.isLoading = true;
        const productUpdateCommand: ProductUpdateCommand =
            new ProductUpdateCommand(this.form.value, this.product.id);
        this.service.update(productUpdateCommand)
            .take(1)
            .subscribe(() => {
                this.isLoading = false;
                this.resolver.resolveFromRouteAndNotify();
                this.redirect();
            });
    }

    public redirect(): void {
        this.router.navigate(['../'],  { relativeTo: this.route});
    }

    private populateForm(): void {
        this.form.patchValue({
            code: this.product.code,
            description: this.product.description,
            unitaryValue: this.product.unitaryValue,
        });
    }
}
