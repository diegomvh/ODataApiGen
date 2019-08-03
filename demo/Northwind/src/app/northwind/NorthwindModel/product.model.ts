import { Category } from './category.model';
import { Order_Detail } from './order_detail.model';
import { Supplier } from './supplier.model';
import { CategoryCollection } from './category.collection';
import { Order_DetailCollection } from './order_detail.collection';
import { SupplierCollection } from './supplier.collection';
import { Schema, Model, ODataQueryBuilder, ODataModel, ODataCollection, PlainObject } from 'angular-odata';

export class Product extends ODataModel {
  static type = 'NorthwindModel.Product';
  static schema = Schema.create({
    keys: [
      {name: 'ProductID'}
    ],
    fields: [
      {name: 'ProductID', type: 'Number', required: true},
      {name: 'ProductName', type: 'String', required: true, length: 40},
      {name: 'SupplierID', type: 'Number', required: true},
      {name: 'CategoryID', type: 'Number', required: true},
      {name: 'QuantityPerUnit', type: 'String', required: true, length: 20},
      {name: 'UnitPrice', type: 'Number', required: true},
      {name: 'UnitsInStock', type: 'Number', required: true},
      {name: 'UnitsOnOrder', type: 'Number', required: true},
      {name: 'ReorderLevel', type: 'Number', required: true},
      {name: 'Discontinued', type: 'Boolean', required: true},
      {name: 'Category', type: 'NorthwindModel.Category', ctor: true, related: true},
      {name: 'Order_Details', type: 'NorthwindModel.Order_DetailCollection', ctor: true, related: true, collection: true},
      {name: 'Supplier', type: 'NorthwindModel.Supplier', ctor: true, related: true}
    ]
  });
  ProductID: number;
  ProductName: string;
  SupplierID: number;
  CategoryID: number;
  QuantityPerUnit: string;
  UnitPrice: number;
  UnitsInStock: number;
  UnitsOnOrder: number;
  ReorderLevel: number;
  Discontinued: boolean;
  Category?: Category;
  Order_Details?: Order_DetailCollection;
  Supplier?: Supplier;

  
}