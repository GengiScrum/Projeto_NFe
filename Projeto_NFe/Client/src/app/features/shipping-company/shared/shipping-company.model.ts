import { Address } from '../../address/address.model';
import { PersonType } from './person-type.enum';

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
    public personType: string;
    public stateRegistration: string;
    public streetName: string;
    public number: number;
    public neighborhood: string;
    public city: string;
    public state: string;
    public country: string;

    constructor(formModel: any) {
        this.businessName = formModel.businessName;
        this.personType = formModel.personType;
        this.streetName = formModel.address.streetName;
        this.number = formModel.address.number;
        this.neighborhood = formModel.address.neighborhood;
        this.city = formModel.address.city;
        this.state = formModel.address.state;
        this.country = formModel.address.country;
        if (this.personType === PersonType.PERSON) {
            this.cpf = formModel.person.cpf;
        } else {
            this.cnpj = formModel.enterprise.cnpj;
            this.stateRegistration = formModel.enterprise.stateRegistration;
            this.corporateName = formModel.enterprise.corporateName;
        }
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
