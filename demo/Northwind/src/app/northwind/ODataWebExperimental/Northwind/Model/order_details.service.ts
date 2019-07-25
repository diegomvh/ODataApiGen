import { Order_Detail } from '../../../NorthwindModel/order_detail.model';
import { Order } from '../../../NorthwindModel/order.model';
import { Product } from '../../../NorthwindModel/product.model';
import { Order_DetailCollection } from '../../../NorthwindModel/order_detail.collection';
import { OrderCollection } from '../../../NorthwindModel/order.collection';
import { ProductCollection } from '../../../NorthwindModel/product.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Order_DetailsService extends ODataModelService<Order_Detail> {
  static model = 'NorthwindModel.Order_Detail';
  static collection = 'NorthwindModel.Order_DetailCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Order_Details');
  }
  
  model(attrs?: any): Order_Detail {
    return super.model(attrs) as Order_Detail;
  }

  collection(attrs?: any): Order_DetailCollection {
    return super.collection(attrs) as Order_DetailCollection;
  }
}