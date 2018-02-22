export class ODataError implements Error {
    public Status: number;
    public Response: any;

    public name: string;
    public message: string;

    constructor(status: number, response: any) {
        this.name = 'OData Request Error';
        this.message = response;
    }
}