import { CustomerDemographic } from '../../../NorthwindModel/customerdemographic.interface';
import { Customer } from '../../../NorthwindModel/customer.interface';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataContext, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

@Injectable()
export class CustomerDemographicsService extends ODataEntityService<CustomerDemographic> {
  static set: string = 'CustomerDemographics';
  
  protected resolveEntityKey(entity: Partial<CustomerDemographic>) {
    return entity.CustomerTypeID;
  }
  
  public Customers(entity: CustomerDemographic, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<ODataEntitySet<Customer>> {
    return this.navigationProperty<Customer>(entity, 'Customers', {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'set',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }

  public addCustomerToCustomers<Customer>(entity: CustomerDemographic, target: ODataEntityRequest<Customer>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.createRef(entity, 'Customers', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'set',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }

  public removeCustomerFromCustomers<Customer>(entity: CustomerDemographic, target: ODataEntityRequest<Customer>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.deleteRef(entity, 'Customers', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'set',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
}