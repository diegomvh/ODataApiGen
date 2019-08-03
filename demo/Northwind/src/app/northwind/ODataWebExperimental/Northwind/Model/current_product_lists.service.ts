import { Current_Product_List } from '../../../NorthwindModel/current_product_list.model';
import { Current_Product_ListCollection } from '../../../NorthwindModel/current_product_list.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Current_Product_ListsService extends ODataModelService {
  static modelType = 'NorthwindModel.Current_Product_List';
  static collectionType = 'NorthwindModel.Current_Product_ListCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Current_Product_Lists');
  }
  
  model(attrs?: any): Current_Product_List {
    return super.model(attrs) as Current_Product_List;
  }

  collection(attrs?: any): Current_Product_ListCollection {
    return super.collection(attrs) as Current_Product_ListCollection;
  }
}