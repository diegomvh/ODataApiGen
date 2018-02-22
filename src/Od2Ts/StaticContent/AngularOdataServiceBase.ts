import { RequestOptionsArgs } from '@angular/http/src/interfaces';
import * as https from 'https';
import { Injectable } from '@angular/core';
import { Http, RequestOptions, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';

import { ODataGetOperation } from './ODataGetOperation';
import { ODataServiceAbstract } from './ODataServiceAbstract';
import { ODataQuery } from './ODataQuery';
import { ODataQueryResult } from './ODataQueryResult';
import { ODataContext } from './ODataContext';
import { ODataError } from './ODataError';

// created by FuryTech.ODataTypeScriptGenerator

export abstract class AngularODataServiceBase<T> extends ODataServiceAbstract<T> {

    private requestOptions: RequestOptionsArgs = {
        withCredentials: true
    };

    protected abstract entitySetUrlSegment: string;

    protected get entitySetUrl(): string {
        return ODataContext.ODataRootPath + this.entitySetUrlSegment;
    }

    protected abstract http: Http;
    constructor() {
        super();
    }

    public Get(id: any): ODataGetOperation<T> {
        let idSegment = this.getEntityUriSegment(id);
        return new ODataGetOperation<T>(idSegment, async (queryString: string) => {
        return this.http.get(this.entitySetUrl + idSegment + queryString, {
            withCredentials: true,
        }).map(a => {
            return a.json() as T;
        }).toPromise();
    });
    };

    private extractResponse(res: Response) {
        if (res.status < 200 || res.status >= 300) {
            throw new ODataError(res.status, res.json());
        }
        let body: any = res.json();
        let entity: T = body;
        return entity || null;
    }

    public async Post(entity: T): Promise<T> {
        return this.http.post(this.entitySetUrl, entity, this.requestOptions)
            .map(this.extractResponse)
            .toPromise();
    }

    public async Patch(id: any, entity: T): Promise<any> {
        return this.http
            .patch(this.entitySetUrl + this.getEntityUriSegment(id), entity, this.requestOptions)
            .toPromise();
    }

    public async Put(id: any, entity: T): Promise<T> {
        return this.http
            .put(this.entitySetUrl + this.getEntityUriSegment(id), entity, this.requestOptions)
            .map(this.extractResponse)
            .toPromise();
    }

    public async Delete(id: any): Promise<any> {
        return this.http
            .delete(this.entitySetUrl + this.getEntityUriSegment(id), this.requestOptions)
            .toPromise();
    }

    protected async ExecCustomAction(actionName: string, entity: T, ...args: any[]): Promise<any> {
        return this.http
            .post(this.entitySetUrl + this.getEntityUriSegment(entity) + `/${actionName}`, null, this.requestOptions)
            .map(a => {return a.json(); } )
            .toPromise();
    }

    protected async ExecCustomCollectionAction(actionName: string, ...args: any[]): Promise<any> {
        return this.http
            .post(this.entitySetUrl + actionName, null, this.requestOptions)
            .map(a => {return a.json(); } )
            .toPromise();
    }

    protected async ExecCustomFunction(fucntionName: string, entity: T, ...args: any[]): Promise<any> {
        return this.http
            .get(this.entitySetUrl + this.getEntityUriSegment(entity) + `/${fucntionName}`, this.requestOptions)
            .map(a => {return a.json(); } )
            .toPromise();
    }

    protected async ExecCustomCollectionFunction(fucntionName: string, ...args: any[]): Promise<any> {
        return this.http
            .get(this.entitySetUrl + fucntionName, this.requestOptions)
            .map(a => {return a.json(); } )
            .toPromise();

    }


    Query(): ODataQuery<T> {

        let http = this.http;
        let entitySetUrl = this.entitySetUrl;

        let evaluateQuery = (queryString: string): Promise<ODataQueryResult<T>> => {
            let url = this.entitySetUrl + queryString;
            let subscription = http.get(url, {
                withCredentials: true
            }).map(a => {
                return a.json() as ODataQueryResult<T>;
            });

            return subscription.toPromise();
        };

        return new ODataQuery(evaluateQuery);
    }

}
