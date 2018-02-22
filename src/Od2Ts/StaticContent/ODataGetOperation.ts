import { ODataOperation } from './ODataOperation';

export class ODataGetOperation<T> extends ODataOperation<T> {

    private buildQueryUrl(): string {
        let url = '?';
        if (this._expand) { url += `$expand=${this._expand}&`; }
        if (this._select) { url += `$expand=${this._select}&`; }
        if (url === '?') url = '';
        return url;
    }

    /**
     * Executes the Get operation
     * @returns An awaitable Promise<T>
     */
    public async Exec(): Promise<T> {
        let queryUrl = this.buildQueryUrl();
        return await this.evaluate(queryUrl);
    }

    constructor(private idSegment: string, private evaluate: (queryString) => Promise<T>) {
        super();
    }

}
