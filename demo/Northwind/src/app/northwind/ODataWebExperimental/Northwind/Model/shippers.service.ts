import { Order } from '../../../NorthwindModel/order.model';
import { Shipper } from '../../../NorthwindModel/shipper.model';
import { OrderCollection } from '../../../NorthwindModel/order.collection';
import { ShipperCollection } from '../../../NorthwindModel/shipper.collection';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ODataModelService, ODataContext, ODataQueryBase, EntitySet } from 'angular-odata';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class ShippersService extends ODataModelService<Shipper> {
  static model = 'NorthwindModel.Shipper';
  static collection = 'NorthwindModel.ShipperCollection';

  constructor(
    protected http: HttpClient,
    public context: ODataContext
  ) {
    super(http, context, 'Shippers');
  }
  
  model(attrs?: any): Shipper {
    return super.model(attrs) as Shipper;
  }

  collection(attrs?: any): ShipperCollection {
    return super.collection(attrs) as ShipperCollection;
  }
}