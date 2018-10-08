export class ShippingCompany {
    public id: number;
    public businessName: string;
    public corporateName: string;
    public cnpj: string;
    public cpf: string;
    public personType: number;
    public stateRegistration: string;
    public streetname: string;
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

    constructor (details: any, address: any) {
        this.businessName = details.businessName;
        this.corporateName = details.corporateName;
        this.cnpj = details.cnpj;
        this.cpf = details.cpf;
        this.personType = details.personType;
        this.stateRegistration = details.stateRegistration;
        this.streetName = address.streetName;
        this.number = address.number;
        this.neighborhood = address.neighborhood;
        this.city = address.city;
        this.state = address.state;
        this.country = address.country;
    }
}
