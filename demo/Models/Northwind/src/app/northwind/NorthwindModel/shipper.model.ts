import { Order } from './order.model';
import { OrderCollection } from './order.collection';
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class Shipper extends ODataModel {
  static type = 'NorthwindModel.Shipper';
  static schema = Schema.create({
    keys: [
      {name: 'ShipperID'}
    ],
    fields: [
      {name: 'ShipperID', type: 'Number', required: true},
      {name: 'CompanyName', type: 'String', required: true, length: 40},
      {name: 'Phone', type: 'String', required: true, length: 24},
      {name: 'Orders', type: 'NorthwindModel.OrderCollection', ctor: true, related: true, collection: true}
    ]
  });
  ShipperID: number;
  CompanyName: string;
  Phone: string;
  Orders?: OrderCollection;

  
}