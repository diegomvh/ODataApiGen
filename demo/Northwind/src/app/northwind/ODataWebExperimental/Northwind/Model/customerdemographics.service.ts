import { CustomerDemographic } from '../../../NorthwindModel/customerdemographic.model';
import { Customer } from '../../../NorthwindModel/customer.model';
import { CustomerDemographicCollection } from '../../../NorthwindModel/customerdemographic.collection';
import { CustomerCollection } from '../../../NorthwindModel/customer.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class CustomerDemographicsService extends ODataModelService<CustomerDemographic> {
  static model = 'NorthwindModel.CustomerDemographic';
  static collection = 'NorthwindModel.CustomerDemographicCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'CustomerDemographics');
  }
  
  model(attrs?: any): CustomerDemographic {
    return super.model(attrs) as CustomerDemographic;
  }

  collection(attrs?: any): CustomerDemographicCollection {
    return super.collection(attrs) as CustomerDemographicCollection;
  }
}