import { Address } from '../../address/address.model';

export class ShippingCompany {
    public id: number;
    public businessName: string;
    public corporateName: string;
    public cnpj: string;
    public cpf: string;
    public personType: number;
    public stateRegistration: string;
    public streetName: string;
    public number: number;
    public neighborhood: string;
    public city: string;
    public state: string;
    public country: string;
}

export class ShippingCompanyRegisterCommand {
    public businessName: string;
    public corporateName: string;
    public cnpj: string;
    public cpf: string;
    public personType: number;
    public stateRegistration: string;
    public streetName: string;
    public number: number;
    public neighborhood: string;
    public city: string;
    public state: string;
    public country: string;

    constructor(shippingCompany: ShippingCompany, address: Address) {
        this.businessName = shippingCompany.businessName;
        this.corporateName = shippingCompany.corporateName;
        this.cnpj = shippingCompany.cnpj;
        this.cpf = shippingCompany.cpf;
        this.stateRegistration = shippingCompany.stateRegistration;
        this.personType = shippingCompany.personType;
        this.streetName = address.streetName;
        this.number = address.number;
        this.neighborhood = address.neighborhood;
        this.city = address.city;
        this.state = address.state;
        this.country = address.country;
    }
}

export class ShippingCompanyUpdateCommand {
    public id: number;
    public businessName: string;
    public corporateName: string;
    public cnpj: string;
    public cpf: string;
    public personType: number;
    public stateRegistration: string;
    public streetName: string;
    public number: number;
    public neighborhood: string;
    public city: string;
    public state: string;
    public country: string;

    constructor(shippingCompany: ShippingCompany, address: Address, id: number) {
        this.id = id;
        this.businessName = shippingCompany.businessName;
        this.corporateName = shippingCompany.corporateName;
        this.cnpj = shippingCompany.cnpj;
        this.cpf = shippingCompany.cpf;
        this.stateRegistration = shippingCompany.stateRegistration;
        this.personType = shippingCompany.personType;
        this.streetName = address.streetName;
        this.number = address.number;
        this.neighborhood = address.neighborhood;
        this.city = address.city;
        this.state = address.state;
        this.country = address.country;
    }
}

export class ShippingCompanyRemoveCommand {
    public ids: number[] = [];

    constructor(selectedEntities: any) {
        this.ids = selectedEntities.map((shippingCompany: ShippingCompany) => shippingCompany.id);
    }
}
