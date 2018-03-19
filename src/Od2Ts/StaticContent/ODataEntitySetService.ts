import { ODataContext } from "./ODataContext";
import { ODataService, ODataQuery, ODataResponse } from "./../odata";

import * as builder from './ODataQueryBuilder';

export class ODataEntitySetService<T> {
  constructor(
    protected odataService: ODataService,
    protected context: ODataContext,
    protected entitySetName: string) {
  }

  public Query(): ODataQuery {
    return new ODataQuery(this.odataService, this.context.ODataRootPath)
      .entitySet(this.entitySetName);
  }

  public Fetch(options: {select?, filter?, search?, groupBy?, 
      transform?, orderby?, top?, skip?, 
      key?, count?, expand?, action?, func?} = {}): Promise<ODataResponse> {
    let query = this.Query();

    if (options.select)
      query.select(options.select);
    if (options.filter)
      query.filter(builder.buildFilter(options.filter) || "");
    if (options.search)
      query.search(options.search);
    //transforms
    if (options.top)
      query.top(options.top);
    if (options.skip)
      query.skip(options.skip);
    if (options.key)
      query.entityKey(builder.buildEntityKey(options.key));
    if (options.count) {
      if (typeof (options.count) === 'boolean')
        query.countOption(options.count);
      else
        query.countSegment();
    }
    if (options.expand)
      query.expand(builder.buildExpand(options.expand));
    if (options.orderby)
      query.orderby(builder.buildOrderBy(options.orderby));
    return query
      .get()
      .toPromise();
  }

  // HTTP Actions
  public Get(key): Promise<T> {
    return this.Query()
      .entityKey(key)
      .get()
      .toPromise()
      .then(resp => resp.toEntity<T>());
  }

  public Post(entity) {
    return this.Query()
      .post(entity)
      .toPromise()
      .then(resp => resp.toEntity<T>());
  }

  public Put(entity): Promise<T> {
    return this.Query()
      .entityKey(entity.id)
      .put(entity)
      .toPromise()
      .then(resp => resp.toEntity<T>());
  }

  public Patch(entity) {
    return this.Query()
      .entityKey(entity.id)
      .patch(entity)
      .toPromise();
  }

  public Delete(entity) {
    return this.Query()
      .entityKey(entity.id)
      .delete()
      .toPromise();
  }

  // Shortcuts
  public Save(entity) {
    if (entity.id)
      return this.Put(entity);
    else
      return this.Post(entity);
  }

  // Function and actions
  public CustomAction(name: string, key: any, postdata: any): Promise<ODataResponse> {
    let query = this.Query();
    query.entityKey(builder.buildEntityKey(key));
    query.actionCall(builder.buildAction(name));
    return query
      .post(postdata)
      .toPromise();
  }

  public CustomCollectionAction(name: string, postdata: any): Promise<ODataResponse> {
    let query = this.Query();
    query.actionCall(builder.buildAction(name));
    return query
      .post(postdata)
      .toPromise();
  }

  public CustomFunction(name: string, key: any, parameters: any = {}): Promise<ODataResponse> {
    let options = {};
    let query = this.Query();
    options[name] = parameters;
    query.entityKey(builder.buildEntityKey(key));
    query.functionCall(builder.buildFunction(options));
    return query
      .get()
      .toPromise();
  }

  public CustomCollectionFunction(name: string, parameters: any = {}): Promise<ODataResponse> {
    let options = {};
    let query = this.Query();
    options[name] = parameters;
    query.functionCall(builder.buildFunction(options));
    return query
      .get()
      .toPromise();
  }
}