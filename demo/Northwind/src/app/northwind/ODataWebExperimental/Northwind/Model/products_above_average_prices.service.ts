import { Products_Above_Average_Price } from '../../../NorthwindModel/products_above_average_price.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Products_Above_Average_PricesService extends ODataEntityService<Products_Above_Average_Price> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Products_Above_Average_Prices');
  }
  
  protected resolveEntityKey(entity: Partial<Products_Above_Average_Price>) {
    return entity.ProductName;
  }
  
  
}