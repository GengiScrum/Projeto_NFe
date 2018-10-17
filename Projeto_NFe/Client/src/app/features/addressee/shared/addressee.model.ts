import { PersonType } from './../../shared/person-type.enum';
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

export class AddresseeRegisterCommand {
    public businessName: string;
    public corporateName: string;
    public cnpj: string;
    public cpf: string;
    public personType: string;
    public stateRegistration: string;
    public address: AddressCommand;

    constructor(addressee: any) {
        this.businessName = addressee.businessName;
        this.personType = addressee.personType;
        this.address = addressee.address;
        if (this.personType === PersonType.PERSON) {
            this.cpf = addressee.person.cpf;
        } else {
            this.cnpj = addressee.enterprise.cnpj;
            this.stateRegistration = addressee.enterprise.stateRegistration;
            this.corporateName = addressee.enterprise.corporateName;
        }
    }
}

export class AddresseeRemoveCommand {
    public addresseesId: number[] = [];

    constructor(selectedEntities: any) {
        this.addresseesId = selectedEntities.map((addressee: Addressee) => addressee.id);
    }
}
