import { InvoiceTax } from './../invoice-tax/invoice-tax.model';
import { Product } from '../../product/shared/product.model';

export class Invoice {
    public id: number;
    public issuerBusinessName: string;
    public shippingCompanyBusinessName: string;
    public addresseBusinessName: string;
    public productSolds: ProductSold[];
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
    public productSolds: ProductSoldRegisterCommand[];

    constructor(invoice: any) {
        this.addresseeId = invoice.addresseeId;
        this.shippingCompanyId = invoice.shippingCompanyId;
        this.issuerId = invoice.issuerId;
        this.entryDate = invoice.entryDate;
        this.operationNature = invoice.operationNature;
    }
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
