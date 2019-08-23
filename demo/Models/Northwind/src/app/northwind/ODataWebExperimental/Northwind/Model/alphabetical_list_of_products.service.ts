import { Alphabetical_list_of_product } from '../../../NorthwindModel/alphabetical_list_of_product.model';
import { Alphabetical_list_of_productCollection } from '../../../NorthwindModel/alphabetical_list_of_product.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Alphabetical_list_of_productsService extends ODataModelService {
  static modelType = 'NorthwindModel.Alphabetical_list_of_product';
  static collectionType = 'NorthwindModel.Alphabetical_list_of_productCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Alphabetical_list_of_products');
  }
  
  model(attrs?: any): Alphabetical_list_of_product {
    return super.model(attrs) as Alphabetical_list_of_product;
  }

  collection(attrs?: any): Alphabetical_list_of_productCollection {
    return super.collection(attrs) as Alphabetical_list_of_productCollection;
  }
}