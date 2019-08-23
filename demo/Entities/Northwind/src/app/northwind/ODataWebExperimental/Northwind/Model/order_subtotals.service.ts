import { Order_Subtotal } from '../../../NorthwindModel/order_subtotal.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Order_SubtotalsService extends ODataEntityService<Order_Subtotal> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Order_Subtotals');
  }
  
  protected resolveEntityKey(entity: Partial<Order_Subtotal>) {
    return entity.OrderID;
  }
  
  
}