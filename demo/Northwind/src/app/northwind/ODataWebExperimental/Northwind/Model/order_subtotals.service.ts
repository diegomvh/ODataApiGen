import { Order_Subtotal } from '../../../NorthwindModel/order_subtotal.model';
import { Order_SubtotalCollection } from '../../../NorthwindModel/order_subtotal.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Order_SubtotalsService extends ODataModelService<Order_Subtotal> {
  static model = 'NorthwindModel.Order_Subtotal';
  static collection = 'NorthwindModel.Order_SubtotalCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Order_Subtotals');
  }
  
  model(attrs?: any): Order_Subtotal {
    return super.model(attrs) as Order_Subtotal;
  }

  collection(attrs?: any): Order_SubtotalCollection {
    return super.collection(attrs) as Order_SubtotalCollection;
  }
}