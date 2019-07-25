import { Category_Sales_for_1997 } from '../../../NorthwindModel/category_sales_for_1997.model';
import { Category_Sales_for_1997Collection } from '../../../NorthwindModel/category_sales_for_1997.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Category_Sales_for_1997Service extends ODataModelService<Category_Sales_for_1997> {
  static model = 'NorthwindModel.Category_Sales_for_1997';
  static collection = 'NorthwindModel.Category_Sales_for_1997Collection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Category_Sales_for_1997');
  }
  
  model(attrs?: any): Category_Sales_for_1997 {
    return super.model(attrs) as Category_Sales_for_1997;
  }

  collection(attrs?: any): Category_Sales_for_1997Collection {
    return super.collection(attrs) as Category_Sales_for_1997Collection;
  }
}