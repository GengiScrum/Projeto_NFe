import { InvoiceTax } from './../invoice-tax/invoice-tax.model';

export class Invoice {
    public id: number;
    public issuerBusinessName: string;
    public issuerId: number;
    public shippingCompanyBusinessName: string;
    public shippingCompanyId: number;
    public addresseeBusinessName: string;
    public addresseeId: number;
    public soldProducts: SoldProduct[];
    public invoiceTax: InvoiceTax;
    public operationNature: string;
    public entryDate: Date;
}

export class InvoiceRegisterCommand {
    public issuerId: number;
    public addresseeId: number;
    public shippingCompanyId: number;
    public entryDate: Date;
    public operationNature: string;
    constructor(invoice: any) {
        this.addresseeId = invoice.addresseeId;
        this.shippingCompanyId = invoice.shippingCompanyId;
        this.issuerId = invoice.issuerId;
        this.entryDate = invoice.entryDate;
        this.operationNature = invoice.operationNature;
    }
}

export class InvoiceUpdateCommand {
    public id: number;
    public issuerId: number;
    public addresseeId: number;
    public shippingCompanyId: number;
    public entryDate: Date;
    public operationNature: string;
    constructor(invoice: any, id: number) {
        this.id = id;
        this.addresseeId = invoice.addresseeId;
        this.shippingCompanyId = invoice.shippingCompanyId;
        this.issuerId = invoice.issuerId;
        this.entryDate = invoice.entryDate;
        this.operationNature = invoice.operationNature;
    }
}

export class InvoiceAddProductCommand {
    public id: number;
    public soldProduct: SoldProductRegisterCommand;

    constructor(soldProduct: any, id: number) {
        this.id = id;
        this.soldProduct = soldProduct;
    }
}

export class InvoiceRemoveProductsCommand {
    public id: number;
    public soldProductsIds: number[] = [];

    constructor(selectedEntities: any, id: number) {
        this.id = id;
        this.soldProductsIds = selectedEntities.map((sp: SoldProduct) => sp.id);
    }
}

export class InvoiceRemoveCommand {
    public invoicesId: number[] = [];

    constructor(selectedEntities: any) {
        this.invoicesId = selectedEntities.map((invoice: Invoice) => invoice.id);
    }
}

export class SoldProduct {
    public id: number;
    public quantity: number;
    public amount: number;
    public invoiceId: number;
    public productId: number;
    public code: string;
    public description: string;
    public unitaryValue: string;
}

export class SoldProductRegisterCommand {
    public quantity: number;
    public productId: number;
}
