import { Product } from './product.model';
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class Category extends ODataModel {
  static type = 'NorthwindModel.Category';
  static schema = Schema.create({
    keys: [
        'CategoryID'
    ],
    fields: [
      {name: 'CategoryID', required: true, type: 'Number'},
      {name: 'CategoryName', required: true, type: 'String', length: 15},
      {name: 'Description', required: true, type: 'String'},
      {name: 'Picture', required: true, type: 'String'},
      {name: 'Products', required: false, type: 'NorthwindModel.ProductCollection'}
    ],
    defaults: {}
  });
  CategoryID: number;
  CategoryName: string;
  Description: string;
  Picture: string;

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