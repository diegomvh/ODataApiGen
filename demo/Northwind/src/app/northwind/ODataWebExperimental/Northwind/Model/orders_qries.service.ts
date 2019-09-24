import { Orders_Qry } from '../../../NorthwindModel/orders_qry.interface';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { ODataEntityService, ODataContext, ODataEntityRequest, ODataEntitySet } from 'angular-odata';

@Injectable()
export class Orders_QriesService extends ODataEntityService<Orders_Qry> {
  static set: string = 'Orders_Qries';
  
  protected resolveEntityKey(entity: Partial<Orders_Qry>) {
    return {CompanyName: entity.CompanyName, OrderID: entity.OrderID};
  }
  
  
}