import { Customer_and_Suppliers_by_City } from '../../../NorthwindModel/customer_and_suppliers_by_city.interface';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataContext, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

@Injectable()
export class Customer_and_Suppliers_by_CitiesService extends ODataEntityService<Customer_and_Suppliers_by_City> {
  static set: string = 'Customer_and_Suppliers_by_Cities';
  
  protected resolveEntityKey(entity: Partial<Customer_and_Suppliers_by_City>) {
    return {CompanyName: entity.CompanyName, Relationship: entity.Relationship};
  }
  
  
}