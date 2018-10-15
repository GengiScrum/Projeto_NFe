import { AddressCommand } from './../../address/address.model';
export class Addressee {
    public id: number;
    public businessName: string;
    public corporateName: string;
    public cnpj: string;
    public cpf: string;
    public stateRegistration: string;
    public streetName: string;
    public number: number;
    public neighborhood: string;
    public city: string;
    public state: string;
    public country: string;
    public personType: number;
}

export class AddresseRegisterCommand {
    public businessName: string;
    public corporateName: string;
    public cnpj: string;
    public cpf: string;
    public stateRegistration: string;
    public address: AddressCommand;

    constructor(addressee: Addressee, address: AddressCommand) {
        this.businessName = addressee.businessName;
        this.corporateName = addressee.corporateName === null ? '' : addressee.corporateName;
        this.cnpj = addressee.cnpj === null ? '' : addressee.cnpj;
        this.cpf = addressee.cpf === null ? '' : addressee.cpf;
        this.stateRegistration = addressee.stateRegistration === null ? '' : addressee.stateRegistration;
        this.address = address;
    }
}

export class AddresseeRemoveCommand {
    public addresseesId: number[] = [];

    constructor(selectedEntities: any) {
        this.addresseesId = selectedEntities.map((addressee: Addressee) => addressee.id);
    }
}
