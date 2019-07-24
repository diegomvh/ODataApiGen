import { Alphabetical_list_of_product } from '../../../NorthwindModel/alphabetical_list_of_product.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Alphabetical_list_of_productsService extends ODataEntityService<Alphabetical_list_of_product> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Alphabetical_list_of_products');
  }
  
  protected resolveEntityKey(entity: Partial<Alphabetical_list_of_product>) {
    return {CategoryName: entity.CategoryName, Discontinued: entity.Discontinued, ProductID: entity.ProductID, ProductName: entity.ProductName};
  }
  
  
}