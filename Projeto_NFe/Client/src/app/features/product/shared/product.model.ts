export class Product {
    public id: number;
    public code: string;
    public description: string;
    public unitaryValue: number;
    public ipiAliquot: number;
    public icmsAliquot: number;
}

export class ProductRegisterCommand {
    public code: string;
    public description: string;
    public unitaryValue: number;
    public tax: ProductTax;

    constructor(product: any) {
        this.code = product.code;
        this.description = product.description;
        this.unitaryValue = product.unitaryValue;
        this.tax = product.tax;
    }
}

export class ProductTax {
    public ipiAliquot: number;
    public icmsAliquot: number;
}

export class ProductUpdateCommand {
    public id: number;
    public code: string;
    public description: string;
    public unitaryValue: number;

    constructor(product: Product, id: number) {
        this.id = id;
        this.code = product.code;
        this.description = product.description;
        this.unitaryValue = product.unitaryValue;
    }
}

export class ProductRemoveCommand {
    public productsId: number[] = [];

    constructor(selectedEntities: any) {
        this.productsId = selectedEntities.map((product: Product) => product.id);
    }
}
