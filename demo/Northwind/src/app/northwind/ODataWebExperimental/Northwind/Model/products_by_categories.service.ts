import { Products_by_Category } from '../../../NorthwindModel/products_by_category.model';
import { Products_by_CategoryCollection } from '../../../NorthwindModel/products_by_category.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Products_by_CategoriesService extends ODataModelService {
  static modelType = 'NorthwindModel.Products_by_Category';
  static collectionType = 'NorthwindModel.Products_by_CategoryCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Products_by_Categories');
  }
  
  model(attrs?: any): Products_by_Category {
    return super.model(attrs) as Products_by_Category;
  }

  collection(attrs?: any): Products_by_CategoryCollection {
    return super.collection(attrs) as Products_by_CategoryCollection;
  }
}