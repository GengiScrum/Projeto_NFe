export class Address {
    public streetName: string;
    public number: number;
    public neighborhood: string;
    public city: string;
    public state: string;
    public country: string;

    constructor (entity: any) {
        this.streetName = entity.streetName;
        this.number = entity.number;
        this.neighborhood = entity.neighborhood ;
        this.city = entity.city;
        this.state = entity.state;
        this.country = entity.country;
    }
}
