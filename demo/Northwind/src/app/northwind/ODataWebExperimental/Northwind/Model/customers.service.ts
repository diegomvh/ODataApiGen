import { CustomerDemographic } from '../../../NorthwindModel/customerdemographic.model';
import { Customer } from '../../../NorthwindModel/customer.model';
import { Order } from '../../../NorthwindModel/order.model';
import { CustomerDemographicCollection } from '../../../NorthwindModel/customerdemographic.collection';
import { CustomerCollection } from '../../../NorthwindModel/customer.collection';
import { OrderCollection } from '../../../NorthwindModel/order.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class CustomersService extends ODataModelService<Customer> {
  static model = 'NorthwindModel.Customer';
  static collection = 'NorthwindModel.CustomerCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Customers');
  }
  
  model(attrs?: any): Customer {
    return super.model(attrs) as Customer;
  }

  collection(attrs?: any): CustomerCollection {
    return super.collection(attrs) as CustomerCollection;
  }
}