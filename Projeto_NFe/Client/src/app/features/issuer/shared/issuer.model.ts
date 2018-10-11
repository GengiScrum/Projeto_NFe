import { Address, AddressCommand } from './../../address/address.model';
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
    public address: AddressCommand;

    constructor(issuer: Issuer, address: AddressCommand) {
        this.businessName = issuer.businessName;
        this.corporateName = issuer.corporateName;
        this.cnpj = issuer.cnpj;
        this.stateRegistration = issuer.stateRegistration;
        this.municipalRegistration = issuer.municipalRegistration;
        this.address = address;
    }
}

export class IssuerUpdateCommand {
    public id: number;
    public businessName: string;
    public corporateName: string;
    public cnpj: string;
    public stateRegistration: string;
    public municipalRegistration: string;
    public address: AddressCommand;

    constructor(issuer: Issuer, address: AddressCommand, id: number) {
        this.id = id;
        this.businessName = issuer.businessName;
        this.corporateName = issuer.corporateName;
        this.cnpj = issuer.cnpj;
        this.stateRegistration = issuer.stateRegistration;
        this.municipalRegistration = issuer.municipalRegistration;
        this.address = address;
    }
}

export class IssuerRemoveCommand {
    public issuersId: number[] = [];

    constructor(selectedEntities: any) {
        this.issuersId = selectedEntities.map((issuer: Issuer) => issuer.id);
    }
}
