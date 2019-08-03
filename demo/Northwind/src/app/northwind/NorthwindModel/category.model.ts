import { Product } from './product.model';
import { ProductCollection } from './product.collection';
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class Category extends ODataModel {
  static type = 'NorthwindModel.Category';
  static schema = Schema.create({
    keys: [
      {name: 'CategoryID'}
    ],
    fields: [
      {name: 'CategoryID', type: 'Number', required: true},
      {name: 'CategoryName', type: 'String', required: true, length: 15},
      {name: 'Description', type: 'String', required: true},
      {name: 'Picture', type: 'String', required: true},
      {name: 'Products', type: 'NorthwindModel.ProductCollection', ctor: true, related: true, collection: true}
    ]
  });
  CategoryID: number;
  CategoryName: string;
  Description: string;
  Picture: string;
  Products?: ProductCollection;

  
}