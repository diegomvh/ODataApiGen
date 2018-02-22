import { ODataQuery } from './ODataQuery';
import { ODataGetOperation } from './ODataGetOperation';

export abstract class ODataServiceAbstract<T> {

    protected abstract entitySetUrl: string;

    /**
     * Creates an OData Get Operation object.
     * @param id The entity's unique identifier
     */
    public abstract Get(id: any): ODataGetOperation<T>;

    /**
 * Executes an OData Post Operation
 * @param entity the entity to be posted
 * @returns an awaitable promise with the created content
 */

    public async abstract Post(entity: T): Promise<T>;

    /**
     * Executes an OData Patch Operation
     * @param id The entitie's unique identifier
     * @param entity's delta to be patched
     * @returns an awaitable promise
     */
    public async abstract Patch(id: any, entity: T): Promise<T>;

    /**
     * Executes an OData Put Operation
     * @param id The entitie's unique identifier
     * @param entity the entity to be putted
     * @returns an awaitable promise with the putted content
     */
    public async abstract Put(id: any, entity: T): Promise<T>;

    /**
     * Executes an OData Delete Operation
     * @param id The entity's unique identifier
     * @returns an awaitable promise
     */
    public async abstract Delete(id: any): Promise<any>;

    /**
     * Executes a custom action on an OData entity
     * @param actionName The action's actionName
     * @param id The entity's unique identifier
     * @param ...args The other optional arguments
     * @returns An awaitable promise
     */
    protected abstract ExecCustomAction(actionName: string, id: any, ...args: any[]): Promise<any>;
    /**
     * Executes a custom action on an OData entity collection
     * @param actionName The action's actionName
     * @param ...args The other optional arguments
     * @returns An awaitable promise
     */
    protected abstract ExecCustomCollectionAction(actionName: string, ...args: any[]): Promise<any>;

    /**
     * Executes a custom function on an OData entity
     * @param actionName The action's actionName
     * @param id The entity's unique identifier
     * @param ...args The other optional arguments
     * @returns An awaitable promise
     */
    protected abstract ExecCustomFunction(fucntionName: string, id: any, ...args: any[]): Promise<any>;
    /**
     * Executes a custom function on an OData entity collection
     * @param actionName The action's actionName
     * @param ...args The other optional arguments
     * @returns An awaitable promise
     */
    protected abstract ExecCustomCollectionFunction(fucntionName: string, ...args: any[]): Promise<any>;

    /**
     * Creates an OData Query object
     * @param id The entitie's unique identifier
     * @param entity the entity to be posted
     * @returns an awaitable promise with the created content
     */
    public abstract Query(): ODataQuery<T>;

    protected getEntityUriSegment(entityKey: any): string {
        entityKey = entityKey.toString();
        if (!/^[0-9]*$/.test(entityKey)) {
            return `('${entityKey}')`;
        }

        return `(${entityKey})`;
    }
}
