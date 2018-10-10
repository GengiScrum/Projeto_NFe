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

export class AddresseeRemoveCommand {
    public addresseesId: number[] = [];

    constructor(selectedEntities: any) {
        this.addresseesId = selectedEntities.map((addressee: Addressee) => addressee.id);
    }
}
