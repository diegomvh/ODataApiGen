import { Product } from './product.model';
import { ProductCollection } from './product.collection';
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class Supplier extends ODataModel {
  static type = 'NorthwindModel.Supplier';
  static schema = Schema.create({
    keys: [
      {name: 'SupplierID'}
    ],
    fields: [
      {name: 'SupplierID', type: 'Number', required: true},
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
      {name: 'HomePage', type: 'String', required: true},
      {name: 'Products', type: 'NorthwindModel.ProductCollection', ctor: true, related: true, collection: true}
    ]
  });
  SupplierID: number;
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
  HomePage: string;
  Products?: ProductCollection;

  
}