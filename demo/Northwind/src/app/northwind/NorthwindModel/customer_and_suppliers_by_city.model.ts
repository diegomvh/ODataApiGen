
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class Customer_and_Suppliers_by_City extends ODataModel {
  static type = 'NorthwindModel.Customer_and_Suppliers_by_City';
  static schema = Schema.create({
    keys: [
      {name: 'CompanyName'},
      {name: 'Relationship'}
    ],
    fields: [
      {name: 'City', type: 'String', required: true, length: 15},
      {name: 'CompanyName', type: 'String', required: true, length: 40},
      {name: 'ContactName', type: 'String', required: true, length: 30},
      {name: 'Relationship', type: 'String', required: true, length: 9}
    ]
  });
  City: string;
  CompanyName: string;
  ContactName: string;
  Relationship: string;

  
}