import { Products_Above_Average_Price } from '../../../NorthwindModel/products_above_average_price.interface';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataContext, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

@Injectable()
export class Products_Above_Average_PricesService extends ODataEntityService<Products_Above_Average_Price> {
  static set: string = 'Products_Above_Average_Prices';
  
  protected resolveEntityKey(entity: Partial<Products_Above_Average_Price>) {
    return entity.ProductName;
  }
  
  
}