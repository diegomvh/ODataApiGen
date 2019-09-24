import { Order_Details_Extended } from '../../../NorthwindModel/order_details_extended.interface';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataContext, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

@Injectable()
export class Order_Details_ExtendedsService extends ODataEntityService<Order_Details_Extended> {
  static set: string = 'Order_Details_Extendeds';
  
  protected resolveEntityKey(entity: Partial<Order_Details_Extended>) {
    return {Discount: entity.Discount, OrderID: entity.OrderID, ProductID: entity.ProductID, ProductName: entity.ProductName, Quantity: entity.Quantity, UnitPrice: entity.UnitPrice};
  }
  
  
}