import { HttpParams, HttpOptions } from "@angular/common/http";
import { ODataContext } from "./ODataContext";
import { ODataService, ODataQuery, ODataResponse, EntitySet } from "./../odata";
import { ODataQueryBuilder } from "./ODataQueryBuilder";

import * as builder from './ODataQueryBuilder';

export class ODataEntitySetService<T> {
  private static readonly ODATA_ETAG = '@odata.etag';
  private static readonly ODATA_ID = '@odata.id';

  constructor(
    protected odataService: ODataService,
    protected context: ODataContext,
    protected entitySetName: string) {
  }

  public entity(key): ODataQueryBuilder {
    return new ODataQueryBuilder(this.entitySetName).key(key);
  }

  public collection(): ODataQueryBuilder {
    return new ODataQueryBuilder(this.entitySetName);
  }

  public fetch(builder: ODataQueryBuilder): Promise<ODataResponse> {
    let query = builder.query(this.odataService, this.context.ODataRootPath);
    return query
      .get()
      .toPromise();
  }

  public fetchAll(query: ODataQueryBuilder): Promise<T[]> {
    return this.fetch(query)
      .then(resp => resp.toEntitySet<T>().getEntities());
  }

  public fetchOne(query: ODataQueryBuilder): Promise<T> {
    return this.fetch(query)
      .then(resp => resp.toEntity<T>());
  }

  public fetchValue<V>(query: ODataQueryBuilder): Promise<V> {
    return this.fetch(query)
      .then(resp => resp.toPropertyValue<V>());
  }

  // HTTP Actions
  public get(key): Promise<T> {
    return this.entity(key)
      .query(this.odataService, this.context.ODataRootPath)
      .get()
      .toPromise()
      .then(resp => resp.toEntity<T>());
  }

  public post(data) {
    return this.collection()
      .query(this.odataService, this.context.ODataRootPath)
      .post(data)
      .toPromise()
      .then(resp => resp.toEntity<T>());
  }

  public put(entity): Promise<T> {
    return this.entity(entity.id)
      .query(this.odataService, this.context.ODataRootPath)
      .put(entity)
      .toPromise()
      .then(resp => resp.toEntity<T>());
  }

  public patch(delta) {
    return this.entity(delta.id)
      .query(this.odataService, this.context.ODataRootPath)
      .patch(delta)
      .toPromise();
  }

  public delete(entity) {
    let etag = entity[ODataEntitySetService.ODATA_ETAG];
    return this.entity(entity.id)
      .query(this.odataService, this.context.ODataRootPath)
      .delete()
      .toPromise();
  }

  // Shortcuts
  public save(entity) {
    if (entity.id)
      return this.put(entity);
    else
      return this.post(entity);
  }

  public createRef(entity, property, target: ODataQueryBuilder) {
    return this.entity(entity.id)
      .query(this.odataService, this.context.ODataRootPath)
      .navigationProperty(property)
      .ref()
      .post({
        ODATA_ID: target
          .query(this.odataService, this.context.ODataRootPath)
          .toString()
      })
      .toPromise();
  }

  public deleteRef(entity, property, target) {
    let etag = entity[ODataEntitySetService.ODATA_ETAG];
    let options = new HttpOptions();
    options.params = new HttpParams();
    options.params.append("id", target
      .query(this.odataService, this.context.ODataRootPath)
      .toString());
    return this.entity(entity.id)
      .query(this.odataService, this.context.ODataRootPath)
      .navigationProperty(property)
      .ref()
      .delete(etag, options)
      .toPromise();
  }

  // Function and actions
  public customAction(key: any, name: string, postdata: any = {}): Promise<ODataResponse> {
    return this.entity(key)
      .action(name)
      .query(this.odataService, this.context.ODataRootPath)
      .post(postdata)
      .toPromise();
  }

  public customCollectionAction(name: string, postdata: any = {}): Promise<ODataResponse> {
    return this.collection()
      .action(name)
      .post(postdata)
      .toPromise();
  }

  public customFunction(key: any, name: string, parameters: any = {}): Promise<ODataResponse> {
    let options = {};
    options[name] = parameters;
    return this.entity(key)
      .func(options)
      .query(this.odataService, this.context.ODataRootPath)
      .get()
      .toPromise();
  }

  public customCollectionFunction(name: string, parameters: any = {}): Promise<ODataResponse> {
    let options = {};
    options[name] = parameters;
    return this.collection()
      .func(options)
      .query(this.odataService, this.context.ODataRootPath)
      .get()
      .toPromise();
  }
}