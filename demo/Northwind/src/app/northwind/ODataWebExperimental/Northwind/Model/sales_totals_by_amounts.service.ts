import { Sales_Totals_by_Amount } from '../../../NorthwindModel/sales_totals_by_amount.model';
import { Sales_Totals_by_AmountCollection } from '../../../NorthwindModel/sales_totals_by_amount.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Sales_Totals_by_AmountsService extends ODataModelService<Sales_Totals_by_Amount> {
  static model = 'NorthwindModel.Sales_Totals_by_Amount';
  static collection = 'NorthwindModel.Sales_Totals_by_AmountCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Sales_Totals_by_Amounts');
  }
  
  model(attrs?: any): Sales_Totals_by_Amount {
    return super.model(attrs) as Sales_Totals_by_Amount;
  }

  collection(attrs?: any): Sales_Totals_by_AmountCollection {
    return super.collection(attrs) as Sales_Totals_by_AmountCollection;
  }
}