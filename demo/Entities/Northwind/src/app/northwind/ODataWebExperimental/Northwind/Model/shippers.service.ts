import { Order } from '../../../NorthwindModel/order.interface';
import { Shipper } from '../../../NorthwindModel/shipper.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataEntityService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class ShippersService extends ODataEntityService<Shipper> {
  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Shippers');
  }
  
  protected resolveEntityKey(entity: Partial<Shipper>) {
    return entity.ShipperID;
  }
  
  public Orders(entity: Shipper, options?): Observable<EntitySet<Order>> {
    return this.navigationProperty(entity, 'Orders', options)
        .pipe(map(resp => resp.toEntitySet<Order>()));
  }

  public addOrderToOrders(entity: Shipper, target: ODataQueryBase, options?) {
    return this.createCollectionRef(entity, 'Orders', target, options);
  }

  public removeOrderFromOrders(entity: Shipper, target: ODataQueryBase, options?) {
    return this.deleteCollectionRef(entity, 'Orders', target, options);
  }
}