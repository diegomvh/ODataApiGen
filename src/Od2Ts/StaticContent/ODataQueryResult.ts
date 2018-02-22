export class ODataQueryResult<T>{
    public '@odata.context': string;
    public '@odata.count': number;

    /**
     * The '@odata.context' variable returned by the OData service
     */
    public get Context(): string {
        return this['@odata.context'];
    }

    /**
     * The '@odata.count' variable returned by the OData service
     */
    public get Count(): number {
        return this['@odata.count'];
    }

    /**
     * The query result in an array
     */
    public value: T[];
}
