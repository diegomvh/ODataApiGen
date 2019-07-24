import { Summary_of_Sales_by_Year } from '../../../NorthwindModel/summary_of_sales_by_year.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Summary_of_Sales_by_YearsService extends ODataEntityService<Summary_of_Sales_by_Year> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Summary_of_Sales_by_Years');
  }
  
  protected resolveEntityKey(entity: Partial<Summary_of_Sales_by_Year>) {
    return entity.OrderID;
  }
  
  
}