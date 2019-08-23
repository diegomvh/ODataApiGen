import { Products_Above_Average_Price } from '../../../NorthwindModel/products_above_average_price.model';
import { Products_Above_Average_PriceCollection } from '../../../NorthwindModel/products_above_average_price.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Products_Above_Average_PricesService extends ODataModelService {
  static modelType = 'NorthwindModel.Products_Above_Average_Price';
  static collectionType = 'NorthwindModel.Products_Above_Average_PriceCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Products_Above_Average_Prices');
  }
  
  model(attrs?: any): Products_Above_Average_Price {
    return super.model(attrs) as Products_Above_Average_Price;
  }

  collection(attrs?: any): Products_Above_Average_PriceCollection {
    return super.collection(attrs) as Products_Above_Average_PriceCollection;
  }
}