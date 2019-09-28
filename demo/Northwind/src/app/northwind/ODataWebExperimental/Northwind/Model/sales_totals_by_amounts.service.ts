import { Sales_Totals_by_Amount } from '../../../NorthwindModel/sales_totals_by_amount.interface';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataClient, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

@Injectable()
export class Sales_Totals_by_AmountsService extends ODataEntityService<Sales_Totals_by_Amount> {
  static set: string = 'Sales_Totals_by_Amounts';
  
  constructor(protected odata: ODataClient) {
    super(odata);
  }

  protected resolveEntityKey(entity: Partial<Sales_Totals_by_Amount>) {
    return {CompanyName: entity.CompanyName, OrderID: entity.OrderID};
  }
  
  
}