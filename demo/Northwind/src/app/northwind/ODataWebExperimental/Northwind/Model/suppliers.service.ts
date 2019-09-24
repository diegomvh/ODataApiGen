import { Product } from '../../../NorthwindModel/product.interface';
import { Supplier } from '../../../NorthwindModel/supplier.interface';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataContext, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

@Injectable()
export class SuppliersService extends ODataEntityService<Supplier> {
  static set: string = 'Suppliers';
  
  protected resolveEntityKey(entity: Partial<Supplier>) {
    return entity.SupplierID;
  }
  
  public Products(entity: Supplier, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }): Observable<ODataEntitySet<Product>> {
    return this.navigationProperty<Product>(entity, 'Products', {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'set',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }

  public addProductToProducts<Product>(entity: Supplier, target: ODataEntityRequest<Product>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.createRef(entity, 'Products', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'set',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }

  public removeProductFromProducts<Product>(entity: Supplier, target: ODataEntityRequest<Product>, options?: {
    headers?: HttpHeaders | {[header: string]: string | string[]},
    params?: HttpParams|{[param: string]: string | string[]},
    reportProgress?: boolean,
    withCredentials?: boolean
  }) {
    return this.deleteRef(entity, 'Products', target, {
        headers: options && options.headers,
        params: options && options.params,
        responseType: 'set',
        reportProgress: options && options.reportProgress,
        withCredentials: options && options.withCredentials
    });
  }
}