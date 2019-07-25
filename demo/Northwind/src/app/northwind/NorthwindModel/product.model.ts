import { Category } from './category.model';
import { Order_Detail } from './order_detail.model';
import { Supplier } from './supplier.model';
import { Schema, Model, ODataQueryBase, ODataModel, ODataCollection } from 'angular-odata';

export class Product extends ODataModel {
  static type = 'NorthwindModel.Product';
  static schema = Schema.create({
    keys: [
        'ProductID'
    ],
    fields: [
      {name: 'ProductID', required: true, type: 'Number'},
      {name: 'ProductName', required: true, type: 'String', length: 40},
      {name: 'SupplierID', required: true, type: 'Number'},
      {name: 'CategoryID', required: true, type: 'Number'},
      {name: 'QuantityPerUnit', required: true, type: 'String', length: 20},
      {name: 'UnitPrice', required: true, type: 'Number'},
      {name: 'UnitsInStock', required: true, type: 'Number'},
      {name: 'UnitsOnOrder', required: true, type: 'Number'},
      {name: 'ReorderLevel', required: true, type: 'Number'},
      {name: 'Discontinued', required: true, type: 'Boolean'},
      {name: 'Category', required: false, type: 'NorthwindModel.Category'},
      {name: 'Order_Details', required: false, type: 'NorthwindModel.Order_DetailCollection'},
      {name: 'Supplier', required: false, type: 'NorthwindModel.Supplier'}
    ],
    defaults: {}
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

  public getCategory(): Category {
    return this.relatedODataModel('Category') as Category;
  }
  public setCategoryAsCategory(target: ODataQueryBase, options?) {
    return this.createODataModelRef('Category', target, options);
  }
  public unsetCategoryAsCategory(target: ODataQueryBase, options?) {
    return this.deleteODataModelRef('Category', target, options);
  }
  public getOrder_Details(): ODataCollection<Order_Detail> {
    return this.relatedODataCollection('Order_Details') as ODataCollection<Order_Detail>;
  }
  public addOrder_DetailToOrder_Details(target: ODataQueryBase, options?) {
    return this.createODataCollectionRef('Order_Details', target, options);
  }
  public removeOrder_DetailFromOrder_Details(target: ODataQueryBase, options?) {
    return this.deleteODataCollectionRef('Order_Details', target, options);
  }
  public getSupplier(): Supplier {
    return this.relatedODataModel('Supplier') as Supplier;
  }
  public setSupplierAsSupplier(target: ODataQueryBase, options?) {
    return this.createODataModelRef('Supplier', target, options);
  }
  public unsetSupplierAsSupplier(target: ODataQueryBase, options?) {
    return this.deleteODataModelRef('Supplier', target, options);
  }
}