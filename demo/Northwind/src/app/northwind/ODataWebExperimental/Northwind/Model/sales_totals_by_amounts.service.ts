import { Sales_Totals_by_Amount } from '../../../NorthwindModel/sales_totals_by_amount.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Sales_Totals_by_AmountsService extends ODataEntityService<Sales_Totals_by_Amount> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Sales_Totals_by_Amounts');
  }
  
  protected resolveEntityKey(entity: Partial<Sales_Totals_by_Amount>) {
    return {CompanyName: entity.CompanyName, OrderID: entity.OrderID};
  }
  
  
}