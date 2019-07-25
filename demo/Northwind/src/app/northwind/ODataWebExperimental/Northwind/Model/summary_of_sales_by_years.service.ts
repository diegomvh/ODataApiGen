import { Summary_of_Sales_by_Year } from '../../../NorthwindModel/summary_of_sales_by_year.model';
import { Summary_of_Sales_by_YearCollection } from '../../../NorthwindModel/summary_of_sales_by_year.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Summary_of_Sales_by_YearsService extends ODataModelService<Summary_of_Sales_by_Year> {
  static model = 'NorthwindModel.Summary_of_Sales_by_Year';
  static collection = 'NorthwindModel.Summary_of_Sales_by_YearCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Summary_of_Sales_by_Years');
  }
  
  model(attrs?: any): Summary_of_Sales_by_Year {
    return super.model(attrs) as Summary_of_Sales_by_Year;
  }

  collection(attrs?: any): Summary_of_Sales_by_YearCollection {
    return super.collection(attrs) as Summary_of_Sales_by_YearCollection;
  }
}