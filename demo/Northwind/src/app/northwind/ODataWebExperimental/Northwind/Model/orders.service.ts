import { Customer } from '../../../NorthwindModel/customer.model';
import { Employee } from '../../../NorthwindModel/employee.model';
import { Order_Detail } from '../../../NorthwindModel/order_detail.model';
import { Order } from '../../../NorthwindModel/order.model';
import { Shipper } from '../../../NorthwindModel/shipper.model';
import { CustomerCollection } from '../../../NorthwindModel/customer.collection';
import { EmployeeCollection } from '../../../NorthwindModel/employee.collection';
import { Order_DetailCollection } from '../../../NorthwindModel/order_detail.collection';
import { OrderCollection } from '../../../NorthwindModel/order.collection';
import { ShipperCollection } from '../../../NorthwindModel/shipper.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class OrdersService extends ODataModelService<Order> {
  static model = 'NorthwindModel.Order';
  static collection = 'NorthwindModel.OrderCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Orders');
  }
  
  model(attrs?: any): Order {
    return super.model(attrs) as Order;
  }

  collection(attrs?: any): OrderCollection {
    return super.collection(attrs) as OrderCollection;
  }
}