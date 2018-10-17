import { PersonType } from '../../shared/person-type.enum';
import { AddressCommand } from '../../address/address.model';

export class ShippingCompany {
    public id: number;
    public businessName: string;
    public corporateName: string;
    public cnpj: string;
    public cpf: string;
    public personType: string;
    public stateRegistration: string;
    public streetName: string;
    public number: number;
    public neighborhood: string;
    public city: string;
    public state: string;
    public country: string;
}

export class ShippingCompanyListViewModel {
    public id: number;
    public businessName: string;
    public document: string;

    constructor(value: any) {
        this.id = value.id;
        this.businessName = value.businessName;
        this.document = (value.cpf) ? value.cpf : value.cnpj;
    }

    public static createArray(items: any[]): ShippingCompanyListViewModel[] {
        const shippingCompanies: ShippingCompanyListViewModel[] = [];
        items.forEach((item: any) => {
            shippingCompanies.push(new ShippingCompanyListViewModel(item));
        });

        return shippingCompanies;
    }
}

export class ShippingCompanyRegisterCommand {
    public businessName: string;
    public corporateName: string;
    public cnpj: string;
    public cpf: string;
    public personType: string;
    public stateRegistration: string;
    public address: AddressCommand;

    constructor(shippingCompany: any) {
        this.businessName = shippingCompany.businessName;
        this.personType = shippingCompany.personType;
        this.address = shippingCompany.address;
        if (this.personType === PersonType.PERSON) {
            this.cpf = shippingCompany.person.cpf;
        } else {
            this.cnpj = shippingCompany.enterprise.cnpj;
            this.stateRegistration = shippingCompany.enterprise.stateRegistration;
            this.corporateName = shippingCompany.enterprise.corporateName;
        }
    }
}

export class ShippingCompanyUpdateCommand {
    public id: number;
    public businessName: string;
    public corporateName: string;
    public cnpj: string;
    public cpf: string;
    public personType: string;
    public stateRegistration: string;
    public address: AddressCommand;

    constructor(shippingCompany: any, id: number) {
        this.id = id;
        this.businessName = shippingCompany.businessName;
        this.personType = shippingCompany.personType;
        this.address = shippingCompany.address;
        if (this.personType === PersonType.PERSON) {
            this.cpf = shippingCompany.person.cpf;
        } else {
            this.cnpj = shippingCompany.enterprise.cnpj;
            this.stateRegistration = shippingCompany.enterprise.stateRegistration;
            this.corporateName = shippingCompany.enterprise.corporateName;
        }
    }
}

export class ShippingCompanyRemoveCommand {
    public ids: number[] = [];

    constructor(selectedEntities: any) {
        this.ids = selectedEntities.map((shippingCompany: ShippingCompany) => shippingCompany.id);
    }
}
