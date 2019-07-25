import { Order } from './order.model';
import { Product } from './product.model';
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class Order_Detail extends ODataModel {
  static type = 'NorthwindModel.Order_Detail';
  static schema = Schema.create({
    keys: [
        'OrderID', 'ProductID'
    ],
    fields: [
      {name: 'OrderID', required: true, type: 'Number'},
      {name: 'ProductID', required: true, type: 'Number'},
      {name: 'UnitPrice', required: true, type: 'Number'},
      {name: 'Quantity', required: true, type: 'Number'},
      {name: 'Discount', required: true, type: 'Number'},
      {name: 'Order', required: false, type: 'NorthwindModel.Order'},
      {name: 'Product', required: false, type: 'NorthwindModel.Product'}
    ],
    defaults: {}
  });
  OrderID: number;
  ProductID: number;
  UnitPrice: number;
  Quantity: number;
  Discount: number;

  public getOrder(): Order {
    return this.relatedODataModel('Order') as Order;
  }
  public setOrderAsOrder(target: ODataQueryBase, options?) {
    return this.createODataModelRef('Order', target, options);
  }
  public unsetOrderAsOrder(target: ODataQueryBase, options?) {
    return this.deleteODataModelRef('Order', target, options);
  }
  public getProduct(): Product {
    return this.relatedODataModel('Product') as Product;
  }
  public setProductAsProduct(target: ODataQueryBase, options?) {
    return this.createODataModelRef('Product', target, options);
  }
  public unsetProductAsProduct(target: ODataQueryBase, options?) {
    return this.deleteODataModelRef('Product', target, options);
  }
}