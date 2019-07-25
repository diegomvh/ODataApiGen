import { Product } from './product.model';
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class Supplier extends ODataModel {
  static type = 'NorthwindModel.Supplier';
  static schema = Schema.create({
    keys: [
        'SupplierID'
    ],
    fields: [
      {name: 'SupplierID', required: true, type: 'Number'},
      {name: 'CompanyName', required: true, type: 'String', length: 40},
      {name: 'ContactName', required: true, type: 'String', length: 30},
      {name: 'ContactTitle', required: true, type: 'String', length: 30},
      {name: 'Address', required: true, type: 'String', length: 60},
      {name: 'City', required: true, type: 'String', length: 15},
      {name: 'Region', required: true, type: 'String', length: 15},
      {name: 'PostalCode', required: true, type: 'String', length: 10},
      {name: 'Country', required: true, type: 'String', length: 15},
      {name: 'Phone', required: true, type: 'String', length: 24},
      {name: 'Fax', required: true, type: 'String', length: 24},
      {name: 'HomePage', required: true, type: 'String'},
      {name: 'Products', required: false, type: 'NorthwindModel.ProductCollection'}
    ],
    defaults: {}
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

  public getProducts(): ODataCollection<Product> {
    return this.relatedODataCollection('Products') as ODataCollection<Product>;
  }
  public addProductToProducts(target: ODataQueryBase, options?) {
    return this.createODataCollectionRef('Products', target, options);
  }
  public removeProductFromProducts(target: ODataQueryBase, options?) {
    return this.deleteODataCollectionRef('Products', target, options);
  }
}