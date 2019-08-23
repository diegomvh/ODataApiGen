import { Orders_Qry } from '../../../NorthwindModel/orders_qry.model';
import { Orders_QryCollection } from '../../../NorthwindModel/orders_qry.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Orders_QriesService extends ODataModelService {
  static modelType = 'NorthwindModel.Orders_Qry';
  static collectionType = 'NorthwindModel.Orders_QryCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Orders_Qries');
  }
  
  model(attrs?: any): Orders_Qry {
    return super.model(attrs) as Orders_Qry;
  }

  collection(attrs?: any): Orders_QryCollection {
    return super.collection(attrs) as Orders_QryCollection;
  }
}