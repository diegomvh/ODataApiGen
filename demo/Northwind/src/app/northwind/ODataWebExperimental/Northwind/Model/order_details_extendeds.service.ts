import { Order_Details_Extended } from '../../../NorthwindModel/order_details_extended.model';
import { Order_Details_ExtendedCollection } from '../../../NorthwindModel/order_details_extended.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Order_Details_ExtendedsService extends ODataModelService {
  static modelType = 'NorthwindModel.Order_Details_Extended';
  static collectionType = 'NorthwindModel.Order_Details_ExtendedCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Order_Details_Extendeds');
  }
  
  model(attrs?: any): Order_Details_Extended {
    return super.model(attrs) as Order_Details_Extended;
  }

  collection(attrs?: any): Order_Details_ExtendedCollection {
    return super.collection(attrs) as Order_Details_ExtendedCollection;
  }
}