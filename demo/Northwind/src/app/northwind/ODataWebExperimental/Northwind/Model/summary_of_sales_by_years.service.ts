import { Summary_of_Sales_by_Year } from '../../../NorthwindModel/summary_of_sales_by_year.interface';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataContext, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

@Injectable()
export class Summary_of_Sales_by_YearsService extends ODataEntityService<Summary_of_Sales_by_Year> {
  static set: string = 'Summary_of_Sales_by_Years';
  
  protected resolveEntityKey(entity: Partial<Summary_of_Sales_by_Year>) {
    return entity.OrderID;
  }
  
  
}