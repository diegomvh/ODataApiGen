import { Summary_of_Sales_by_Quarter } from '../../../NorthwindModel/summary_of_sales_by_quarter.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Summary_of_Sales_by_QuartersService extends ODataEntityService<Summary_of_Sales_by_Quarter> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Summary_of_Sales_by_Quarters');
  }
  
  protected resolveEntityKey(entity: Partial<Summary_of_Sales_by_Quarter>) {
    return entity.OrderID;
  }
  
  
}