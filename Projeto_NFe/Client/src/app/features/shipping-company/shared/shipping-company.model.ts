import { PersonType } from '../../shared/person-type.enum';

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
    public personType: string;
    public stateRegistration: string;
    public streetName: string;
    public number: number;
    public neighborhood: string;
    public city: string;
    public state: string;
    public country: string;

    constructor(formModel: any, id: number) {
        this.id = id;
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

export class ShippingCompanyRemoveCommand {
    public ids: number[] = [];

    constructor(selectedEntities: any) {
        this.ids = selectedEntities.map((shippingCompany: ShippingCompany) => shippingCompany.id);
    }
}
