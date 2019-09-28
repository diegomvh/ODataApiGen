import { Alphabetical_list_of_product } from '../../../NorthwindModel/alphabetical_list_of_product.interface';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataClient, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

@Injectable()
export class Alphabetical_list_of_productsService extends ODataEntityService<Alphabetical_list_of_product> {
  static set: string = 'Alphabetical_list_of_products';
  
  constructor(protected odata: ODataClient) {
    super(odata);
  }

  protected resolveEntityKey(entity: Partial<Alphabetical_list_of_product>) {
    return {CategoryName: entity.CategoryName, Discontinued: entity.Discontinued, ProductID: entity.ProductID, ProductName: entity.ProductName};
  }
  
  
}