import { InvoiceTax } from './../invoice-tax/invoice-tax.model';
import { Product } from '../../product/shared/product.model';

export class Invoice {
    public id: number;
    public issuerBusinessName: string;
    public issuerId: number;
    public shippingCompanyBusinessName: string;
    public shippingCompanyId: number;
    public addresseeBusinessName: string;
    public addresseeId: number;
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
    public id: number;
    public issuerId: number;
    public addresseeId: number;
    public shippingCompanyId: number;
    public entryDate: Date;
    public operationNature: string;
    public productSolds: ProductSoldRegisterCommand[];

    constructor(invoice: any, id: number) {
        this.id = id;
        this.addresseeId = invoice.addresseeId;
        this.shippingCompanyId = invoice.shippingCompanyId;
        this.issuerId = invoice.issuerId;
        this.entryDate = invoice.entryDate;
        this.operationNature = invoice.operationNature;
    }
}

export class InvoiceRemoveCommand {
    public invoicesId: number[] = [];

    constructor(selectedEntities: any) {
        this.invoicesId = selectedEntities.map((invoice: Invoice) => invoice.id);
    }
}

export class ProductSold {

}

export class ProductSoldRegisterCommand {
    public quantity: number;
    public product: Product;
    public invoiceId: number;
}
