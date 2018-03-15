import { ODataContext } from "./ODataContext";
import { ODataService, ODataQuery } from "./../odata";

import * as builder from './ODataQueryBuilder';

export class ODataEntitySetService<T> {
  constructor(
    protected odataService: ODataService,
    protected context: ODataContext,
    protected entitySetName: string) {
  }

  public Query(select?, filter?, search?, groupBy?, transform?, orderby?, top?, skip?, key?, count?, expand?, action?, func?): ODataQuery {
    let query = new ODataQuery(this.odataService, this.context.ODataRootPath)
      .entitySet(this.entitySetName);
    query.select(select);
    if (filter)
      query.filter(builder.buildFilter(filter) || "");
    if (search)
      query.search(search);
    //transforms
    if (top)
      query.top(top);
    if (skip)
      query.skip(skip);
    if (key)
      query.entityKey(builder.buildEntityKey(key));
    if (count) {
      if (typeof (count) === 'boolean')
        query.countOption(count);
      else
        query.countSegment();
    }
    if (action)
      query.functionCall(builder.buildAction(action));
    if (func)
      query.functionCall(builder.buildFunction(func));
    if (expand)
      query.expand(builder.buildExpand(expand));
    if (orderby)
      query.orderby(builder.buildOrderBy(orderby));
    return query;
  }

  public Get(key): Promise<T> {
    return this.Query()
      .entityKey(key)
      .get()
      .toPromise()
      .then(resp => resp.toEntity<T>());
  }
}