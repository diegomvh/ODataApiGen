import { Customer_and_Suppliers_by_City } from '../../../NorthwindModel/customer_and_suppliers_by_city.model';
import { Customer_and_Suppliers_by_CityCollection } from '../../../NorthwindModel/customer_and_suppliers_by_city.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Customer_and_Suppliers_by_CitiesService extends ODataModelService {
  static modelType = 'NorthwindModel.Customer_and_Suppliers_by_City';
  static collectionType = 'NorthwindModel.Customer_and_Suppliers_by_CityCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Customer_and_Suppliers_by_Cities');
  }
  
  model(attrs?: any): Customer_and_Suppliers_by_City {
    return super.model(attrs) as Customer_and_Suppliers_by_City;
  }

  collection(attrs?: any): Customer_and_Suppliers_by_CityCollection {
    return super.collection(attrs) as Customer_and_Suppliers_by_CityCollection;
  }
}