import { Category } from '../../../NorthwindModel/category.model';
import { Order_Detail } from '../../../NorthwindModel/order_detail.model';
import { Product } from '../../../NorthwindModel/product.model';
import { Supplier } from '../../../NorthwindModel/supplier.model';
import { CategoryCollection } from '../../../NorthwindModel/category.collection';
import { Order_DetailCollection } from '../../../NorthwindModel/order_detail.collection';
import { ProductCollection } from '../../../NorthwindModel/product.collection';
import { SupplierCollection } from '../../../NorthwindModel/supplier.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class ProductsService extends ODataModelService<Product> {
  static model = 'NorthwindModel.Product';
  static collection = 'NorthwindModel.ProductCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Products');
  }
  
  model(attrs?: any): Product {
    return super.model(attrs) as Product;
  }

  collection(attrs?: any): ProductCollection {
    return super.collection(attrs) as ProductCollection;
  }
}