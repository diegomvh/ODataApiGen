import { Current_Product_List } from '../../../NorthwindModel/current_product_list.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Current_Product_ListsService extends ODataEntityService<Current_Product_List> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Current_Product_Lists');
  }
  
  protected resolveEntityKey(entity: Partial<Current_Product_List>) {
    return {ProductID: entity.ProductID, ProductName: entity.ProductName};
  }
  
  
}