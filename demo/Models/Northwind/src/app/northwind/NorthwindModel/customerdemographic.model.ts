import { Customer } from './customer.model';
import { CustomerCollection } from './customer.collection';
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class CustomerDemographic extends ODataModel {
  static type = 'NorthwindModel.CustomerDemographic';
  static schema = Schema.create({
    keys: [
      {name: 'CustomerTypeID'}
    ],
    fields: [
      {name: 'CustomerTypeID', type: 'String', required: true, length: 10},
      {name: 'CustomerDesc', type: 'String', required: true},
      {name: 'Customers', type: 'NorthwindModel.CustomerCollection', ctor: true, related: true, collection: true}
    ]
  });
  CustomerTypeID: string;
  CustomerDesc: string;
  Customers?: CustomerCollection;

  
}