import { Category } from '../../../NorthwindModel/category.model';
import { Product } from '../../../NorthwindModel/product.model';
import { CategoryCollection } from '../../../NorthwindModel/category.collection';
import { ProductCollection } from '../../../NorthwindModel/product.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class CategoriesService extends ODataModelService {
  static modelType = 'NorthwindModel.Category';
  static collectionType = 'NorthwindModel.CategoryCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Categories');
  }
  
  model(attrs?: any): Category {
    return super.model(attrs) as Category;
  }

  collection(attrs?: any): CategoryCollection {
    return super.collection(attrs) as CategoryCollection;
  }
}