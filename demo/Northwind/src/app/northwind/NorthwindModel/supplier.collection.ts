import { Supplier } from './supplier.model';
import { Collection, ODataCollection } from 'angular-odata';

export class SupplierCollection extends ODataCollection<Supplier> {
  static type = 'NorthwindModel.SupplierCollection';
  static Model = Supplier;
}