import { Shipper } from './shipper.model';
import { Collection, ODataCollection } from 'angular-odata';

export class ShipperCollection extends ODataCollection<Shipper> {
  static type = 'NorthwindModel.ShipperCollection';
  static modelType = 'NorthwindModel.Shipper';
}