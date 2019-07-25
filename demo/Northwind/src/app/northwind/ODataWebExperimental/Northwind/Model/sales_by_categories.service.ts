import { Sales_by_Category } from '../../../NorthwindModel/sales_by_category.model';
import { Sales_by_CategoryCollection } from '../../../NorthwindModel/sales_by_category.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Sales_by_CategoriesService extends ODataModelService<Sales_by_Category> {
  static model = 'NorthwindModel.Sales_by_Category';
  static collection = 'NorthwindModel.Sales_by_CategoryCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Sales_by_Categories');
  }
  
  model(attrs?: any): Sales_by_Category {
    return super.model(attrs) as Sales_by_Category;
  }

  collection(attrs?: any): Sales_by_CategoryCollection {
    return super.collection(attrs) as Sales_by_CategoryCollection;
  }
}