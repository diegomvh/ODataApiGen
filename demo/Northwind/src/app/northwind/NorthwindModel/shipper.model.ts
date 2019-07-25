import { Order } from './order.model';
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class Shipper extends ODataModel {
  static type = 'NorthwindModel.Shipper';
  static schema = Schema.create({
    keys: [
        'ShipperID'
    ],
    fields: [
      {name: 'ShipperID', required: true, type: 'Number'},
      {name: 'CompanyName', required: true, type: 'String', length: 40},
      {name: 'Phone', required: true, type: 'String', length: 24},
      {name: 'Orders', required: false, type: 'NorthwindModel.OrderCollection'}
    ],
    defaults: {}
  });
  ShipperID: number;
  CompanyName: string;
  Phone: string;

  public getOrders(): ODataCollection<Order> {
    return this.relatedODataCollection('Orders') as ODataCollection<Order>;
  }
  public addOrderToOrders(target: ODataQueryBase, options?) {
    return this.createODataCollectionRef('Orders', target, options);
  }
  public removeOrderFromOrders(target: ODataQueryBase, options?) {
    return this.deleteODataCollectionRef('Orders', target, options);
  }
}