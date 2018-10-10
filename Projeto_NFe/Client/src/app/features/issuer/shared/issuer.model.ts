import { Address } from './../../address/address.model';
export class Issuer {
    public id: number;
    public businessName: string;
    public corporateName: string;
    public cnpj: string;
    public stateRegistration: string;
    public municipalRegistration: string;
    public streetName: string;
    public number: string;
    public neighborhood: string;
    public city: string;
    public state: string;
    public country: string;
}

export class IssuerRegisterCommand {
    public businessName: string;
    public corporateName: string;
    public cnpj: string;
    public stateRegistration: string;
    public municipalRegistration: string;
    public streetName: string;
    public number: string;
    public neighborhood: string;
    public city: string;
    public state: string;
    public country: string;

    constructor(issuer: Issuer, address: Address) {
        this.businessName = issuer.businessName;
        this.corporateName = issuer.corporateName;
        this.cnpj = issuer.cnpj;
        this.stateRegistration = issuer.stateRegistration;
        this.municipalRegistration = issuer.municipalRegistration;
        this.streetName = address.streetName;
        this.number = address.number.toString();
        this.neighborhood = address.neighborhood;
        this.city = address.city;
        this.state = address.state;
        this.country = address.country;
    }
}

export class IssuerUpdateCommand {
    public id: number;
    public businessName: string;
    public corporateName: string;
    public cnpj: string;
    public stateRegistration: string;
    public municipalRegistration: string;
    public streetName: string;
    public number: string;
    public neighborhood: string;
    public city: string;
    public state: string;
    public country: string;

    constructor(issuer: Issuer, address: Address, id: number) {
        this.id = id;
        this.businessName = issuer.businessName;
        this.corporateName = issuer.corporateName;
        this.cnpj = issuer.cnpj;
        this.stateRegistration = issuer.stateRegistration;
        this.municipalRegistration = issuer.municipalRegistration;
        this.streetName = address.streetName;
        this.number = address.number.toString();
        this.neighborhood = address.neighborhood;
        this.city = address.city;
        this.state = address.state;
        this.country = address.country;
    }
}

export class IssuerRemoveCommand {
    public issuersId: number[] = [];

    constructor(selectedEntities: any) {
        this.issuersId = selectedEntities.map((issuer: Issuer) => issuer.id);
    }
}
