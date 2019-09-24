import { Summary_of_Sales_by_Quarter } from '../../../NorthwindModel/summary_of_sales_by_quarter.interface';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataContext, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

@Injectable()
export class Summary_of_Sales_by_QuartersService extends ODataEntityService<Summary_of_Sales_by_Quarter> {
  static set: string = 'Summary_of_Sales_by_Quarters';
  
  protected resolveEntityKey(entity: Partial<Summary_of_Sales_by_Quarter>) {
    return entity.OrderID;
  }
  
  
}