import { Current_Product_List } from '../../../NorthwindModel/current_product_list.interface';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataClient, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

@Injectable()
export class Current_Product_ListsService extends ODataEntityService<Current_Product_List> {
  static set: string = 'Current_Product_Lists';
  
  constructor(protected odata: ODataClient) {
    super(odata);
  }

  protected resolveEntityKey(entity: Partial<Current_Product_List>) {
    return {ProductID: entity.ProductID, ProductName: entity.ProductName};
  }
  
  
}