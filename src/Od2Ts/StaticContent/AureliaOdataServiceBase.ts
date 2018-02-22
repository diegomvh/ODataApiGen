import { HttpClient, HttpResponseMessage } from 'aurelia-http-client';

import { ODataServiceAbstract } from './ODataServiceAbstract';
import { ODataContext } from './ODataContext';
import { ODataGetOperation } from './ODataGetOperation';
import { ODataError } from './ODataError';
import { ODataQuery } from './ODataQuery';
import { ODataQueryResult } from './ODataQueryResult';

export abstract class AureliaOdataServiceBase<T> extends ODataServiceAbstract<T>{

    private http: HttpClient;

    protected get entitySetUrl(): string {
        return ODataContext.ODataRootPath + this.entitySetUrlSegment;
    }

    protected getUriForEntity(id: any): string {
        return this.entitySetUrl + this.getEntityUriSegment(id)
    }

    constructor(protected entitySetUrlSegment: string) {
        super();
        this.http = new HttpClient().configure(c => {
            c.withBaseUrl(this.entitySetUrl),
                c.withCredentials(true)
        });
    }

    /**
     * Creates an OData Get Operation object.
     * @param id The entity's unique identifier
     */
    public Get(id: any): ODataGetOperation<T> {
        let entityUri = this.getUriForEntity(id);
        return new ODataGetOperation<T>(entityUri, async (queryString: string) => {
            var result = await this.http.get(entityUri + queryString);
            return result.content;
        });
    };

    private extractResponse(res: HttpResponseMessage) {
        if (res.statusCode < 200 || res.statusCode >= 300) {
            throw new ODataError(res.statusCode, res.content);
        }
        let entity: T = res.content;
        return entity || null;
    }

    /**
     * Executes an OData Post Operation
     * @param entity the entity to be posted
     * @returns an awaitable promise with the created content
     */
    public async Post(entity: T): Promise<T> {
        var result = await this.http.post(this.entitySetUrl, entity);
        return result.content;
    }

    /**
     * Executes an OData Patch Operation
     * @param id The entitie's unique identifier
     * @param entity's delta to be patched
     * @returns an awaitable promise
     */
    public async Patch(id: any, entity: any): Promise<any> {
        var result = await this.http.patch(this.getUriForEntity(id), entity);
        return result.content;
    }

    /**
     * Executes an OData Put Operation
     * @param id The entitie's unique identifier
     * @param entity the entity to be putted
     * @returns an awaitable promise with the putted content
     */
    public async Put(id: any, entity: T): Promise<T> {
        var result = await this.http.put(this.getUriForEntity(id), entity);
        return result.content;
    }

    /**
     * Executes an OData Delete Operation
     * @param id The entity's unique identifier
     * @returns an awaitable promise
     */
    public async Delete(id: any): Promise<any> {
        var result = await this.http.delete(this.getUriForEntity(id));
        return result.content;
    }


    /**
     * Executes a custom action on an OData entity
     * @param actionName The action's actionName
     * @param id The entity's unique identifier
     * @param ...args The other optional arguments
     * @returns An awaitable promise
     */
    protected async ExecCustomAction(actionName: string, entityId: any, postData: any): Promise<any> {
        var result = await this.http.post(this.getUriForEntity(entityId) + `/${actionName}`, postData);
        return result.content;
    }

    /**
     * Executes a custom action on an OData entity collection
     * @param actionName The action's actionName
     * @param ...args The other optional arguments
     * @returns An awaitable promise
     */
    protected async ExecCustomCollectionAction(actionName: string, postData: any): Promise<any> {
        var result = await this.http.post(actionName, postData);
        return result.content;
    }

    /**
     * Executes a custom function on an OData entity
     * @param actionName The action's actionName
     * @param id The entity's unique identifier
     * @param ...args The other optional arguments
     * @returns An awaitable promise
     */
    protected async ExecCustomFunction(fucntionName: string, entityId: any, ...args: any[]): Promise<any> {
        let result = await this.http.get(this.getUriForEntity(entityId) + `/${fucntionName}`);
        return result.content;
    }

    /**
     * Executes a custom function on an OData entity collection
     * @param actionName The action's actionName
     * @param ...args The other optional arguments
     * @returns An awaitable promise
     */
    protected async ExecCustomCollectionFunction(fucntionName: string, ...args: any[]): Promise<any> {
        let result = await this.http.get(fucntionName);
        return result.content;
    }


    /**
     * Creates an OData Query object
     * @param id The entitie's unique identifier
     * @param entity the entity to be posted
     * @returns an awaitable promise with the created content
     */
    Query(): ODataQuery<T> {
        let http = this.http;
        let evaluateQuery = async (queryString: string): Promise<ODataQueryResult<T>> => {
            let url = this.entitySetUrl + "/" + queryString;
            let response = await http.get(url);
            return response.content;
        };

        return new ODataQuery(evaluateQuery);
    }

}