import { InvoiceTax } from './../invoice-tax/invoice-tax.model';

export class Invoice {
    public id: number;
    public issuerBusinessName: string;
    public shippingCompanyBusinessName: string;
    public addresseBusinessName: string;
    public productSolds: ProductSold[];
    public invoiceTax: InvoiceTax;
    public operationNature: string;
    public issueDate: Date;
    public entryDate: Date;
}

export class InvoiceRegisterCommand {
    public issuerId: number;
    public adresseeId: number;
    public shippingCompanyId: number;
    public entryDate: Date;
    public operationNature: string;
    public productSolds: ProductSoldRegisterCommand[];
}

export class InvoiceUpdateCommand {

}

export class InvoiceRemoveCommand {

}

export class ProductSold {

}

export class ProductSoldRegisterCommand {
    public quantity: number;
    public product: Product;
    public invoiceId: number;
}
