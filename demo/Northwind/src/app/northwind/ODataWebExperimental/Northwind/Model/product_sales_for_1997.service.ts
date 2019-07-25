import { Product_Sales_for_1997 } from '../../../NorthwindModel/product_sales_for_1997.model';
import { Product_Sales_for_1997Collection } from '../../../NorthwindModel/product_sales_for_1997.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Product_Sales_for_1997Service extends ODataModelService<Product_Sales_for_1997> {
  static model = 'NorthwindModel.Product_Sales_for_1997';
  static collection = 'NorthwindModel.Product_Sales_for_1997Collection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Product_Sales_for_1997');
  }
  
  model(attrs?: any): Product_Sales_for_1997 {
    return super.model(attrs) as Product_Sales_for_1997;
  }

  collection(attrs?: any): Product_Sales_for_1997Collection {
    return super.collection(attrs) as Product_Sales_for_1997Collection;
  }
}