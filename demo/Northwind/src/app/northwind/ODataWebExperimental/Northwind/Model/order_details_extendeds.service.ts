import { Order_Details_Extended } from '../../../NorthwindModel/order_details_extended.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Order_Details_ExtendedsService extends ODataEntityService<Order_Details_Extended> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Order_Details_Extendeds');
  }
  
  protected resolveEntityKey(entity: Partial<Order_Details_Extended>) {
    return {Discount: entity.Discount, OrderID: entity.OrderID, ProductID: entity.ProductID, ProductName: entity.ProductName, Quantity: entity.Quantity, UnitPrice: entity.UnitPrice};
  }
  
  
}