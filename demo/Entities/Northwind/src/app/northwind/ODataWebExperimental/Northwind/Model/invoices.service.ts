import { Invoice } from '../../../NorthwindModel/invoice.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class InvoicesService extends ODataEntityService<Invoice> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Invoices');
  }
  
  protected resolveEntityKey(entity: Partial<Invoice>) {
    return {CustomerName: entity.CustomerName, Discount: entity.Discount, OrderID: entity.OrderID, ProductID: entity.ProductID, ProductName: entity.ProductName, Quantity: entity.Quantity, Salesperson: entity.Salesperson, ShipperName: entity.ShipperName, UnitPrice: entity.UnitPrice};
  }
  
  
}