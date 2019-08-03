import { Summary_of_Sales_by_Quarter } from '../../../NorthwindModel/summary_of_sales_by_quarter.model';
import { Summary_of_Sales_by_QuarterCollection } from '../../../NorthwindModel/summary_of_sales_by_quarter.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Summary_of_Sales_by_QuartersService extends ODataModelService {
  static modelType = 'NorthwindModel.Summary_of_Sales_by_Quarter';
  static collectionType = 'NorthwindModel.Summary_of_Sales_by_QuarterCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Summary_of_Sales_by_Quarters');
  }
  
  model(attrs?: any): Summary_of_Sales_by_Quarter {
    return super.model(attrs) as Summary_of_Sales_by_Quarter;
  }

  collection(attrs?: any): Summary_of_Sales_by_QuarterCollection {
    return super.collection(attrs) as Summary_of_Sales_by_QuarterCollection;
  }
}