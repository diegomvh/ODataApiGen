import { Invoice } from '../../../NorthwindModel/invoice.interface';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataContext, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

@Injectable()
export class InvoicesService extends ODataEntityService<Invoice> {
  static set: string = 'Invoices';
  
  protected resolveEntityKey(entity: Partial<Invoice>) {
    return {CustomerName: entity.CustomerName, Discount: entity.Discount, OrderID: entity.OrderID, ProductID: entity.ProductID, ProductName: entity.ProductName, Quantity: entity.Quantity, Salesperson: entity.Salesperson, ShipperName: entity.ShipperName, UnitPrice: entity.UnitPrice};
  }
  
  
}