import { Customer_and_Suppliers_by_City } from '../../../NorthwindModel/customer_and_suppliers_by_city.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Customer_and_Suppliers_by_CitiesService extends ODataEntityService<Customer_and_Suppliers_by_City> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Customer_and_Suppliers_by_Cities');
  }
  
  protected resolveEntityKey(entity: Partial<Customer_and_Suppliers_by_City>) {
    return {CompanyName: entity.CompanyName, Relationship: entity.Relationship};
  }
  
  
}