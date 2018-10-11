export class Product {
    public id: number;
    public code: string;
    public description: string;
    public unitaryValue: number;
}

export class ProductRegisterCommand {
    public code: string;
    public description: string;
    public unitaryValue: number;

    constructor(product: Product) {
        this.code = product.code;
        this.description = product.description;
        this.unitaryValue = product.unitaryValue;
    }
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
