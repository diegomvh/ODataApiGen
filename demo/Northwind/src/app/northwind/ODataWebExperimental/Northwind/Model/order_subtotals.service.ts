import { Order_Subtotal } from '../../../NorthwindModel/order_subtotal.interface';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataContext, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

@Injectable()
export class Order_SubtotalsService extends ODataEntityService<Order_Subtotal> {
  static set: string = 'Order_Subtotals';
  
  protected resolveEntityKey(entity: Partial<Order_Subtotal>) {
    return entity.OrderID;
  }
  
  
}