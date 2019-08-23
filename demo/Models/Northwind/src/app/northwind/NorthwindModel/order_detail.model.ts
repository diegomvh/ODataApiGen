import { Order } from './order.model';
import { Product } from './product.model';
import { OrderCollection } from './order.collection';
import { ProductCollection } from './product.collection';
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class Order_Detail extends ODataModel {
  static type = 'NorthwindModel.Order_Detail';
  static schema = Schema.create({
    keys: [
      {name: 'OrderID'},
      {name: 'ProductID'}
    ],
    fields: [
      {name: 'OrderID', type: 'Number', required: true},
      {name: 'ProductID', type: 'Number', required: true},
      {name: 'UnitPrice', type: 'Number', required: true},
      {name: 'Quantity', type: 'Number', required: true},
      {name: 'Discount', type: 'Number', required: true},
      {name: 'Order', type: 'NorthwindModel.Order', ctor: true, related: true},
      {name: 'Product', type: 'NorthwindModel.Product', ctor: true, related: true}
    ]
  });
  OrderID: number;
  ProductID: number;
  UnitPrice: number;
  Quantity: number;
  Discount: number;
  Order?: Order;
  Product?: Product;

  
}