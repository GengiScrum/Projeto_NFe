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
}

export class ProductUpdateCommand {
    public id: number;
    public code: string;
    public description: string;
    public unitaryValue: number;
}

export class ProductRemoveCommand {
    public productsId: number[] = [];

    constructor(selectedEntities: any) {
        this.productsId = selectedEntities.map((product: Product) => product.id);
    }
}
