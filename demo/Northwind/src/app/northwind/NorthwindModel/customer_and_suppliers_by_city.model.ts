
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class Customer_and_Suppliers_by_City extends ODataModel {
  static type = 'NorthwindModel.Customer_and_Suppliers_by_City';
  static schema = Schema.create({
    keys: [
        'CompanyName', 'Relationship'
    ],
    fields: [
      {name: 'City', required: true, type: 'String', length: 15},
      {name: 'CompanyName', required: true, type: 'String', length: 40},
      {name: 'ContactName', required: true, type: 'String', length: 30},
      {name: 'Relationship', required: true, type: 'String', length: 9}
    ],
    defaults: {}
  });
  City: string;
  CompanyName: string;
  ContactName: string;
  Relationship: string;

  
}