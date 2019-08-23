import { Orders_Qry } from '../../../NorthwindModel/orders_qry.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class Orders_QriesService extends ODataEntityService<Orders_Qry> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Orders_Qries');
  }
  
  protected resolveEntityKey(entity: Partial<Orders_Qry>) {
    return {CompanyName: entity.CompanyName, OrderID: entity.OrderID};
  }
  
  
}