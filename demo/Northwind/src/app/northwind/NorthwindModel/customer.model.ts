import { CustomerDemographic } from './customerdemographic.model';
import { Order } from './order.model';
import { CustomerDemographicCollection } from './customerdemographic.collection';
import { OrderCollection } from './order.collection';
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class Customer extends ODataModel {
  static type = 'NorthwindModel.Customer';
  static schema = Schema.create({
    keys: [
      {name: 'CustomerID'}
    ],
    fields: [
      {name: 'CustomerID', type: 'String', required: true, length: 5},
      {name: 'CompanyName', type: 'String', required: true, length: 40},
      {name: 'ContactName', type: 'String', required: true, length: 30},
      {name: 'ContactTitle', type: 'String', required: true, length: 30},
      {name: 'Address', type: 'String', required: true, length: 60},
      {name: 'City', type: 'String', required: true, length: 15},
      {name: 'Region', type: 'String', required: true, length: 15},
      {name: 'PostalCode', type: 'String', required: true, length: 10},
      {name: 'Country', type: 'String', required: true, length: 15},
      {name: 'Phone', type: 'String', required: true, length: 24},
      {name: 'Fax', type: 'String', required: true, length: 24},
      {name: 'Orders', type: 'NorthwindModel.OrderCollection', ctor: true, related: true, collection: true},
      {name: 'CustomerDemographics', type: 'NorthwindModel.CustomerDemographicCollection', ctor: true, related: true, collection: true}
    ]
  });
  CustomerID: string;
  CompanyName: string;
  ContactName: string;
  ContactTitle: string;
  Address: string;
  City: string;
  Region: string;
  PostalCode: string;
  Country: string;
  Phone: string;
  Fax: string;
  Orders?: OrderCollection;
  CustomerDemographics?: CustomerDemographicCollection;

  
}