import { Orders_Qry } from './orders_qry.model';
import { Collection, ODataCollection } from 'angular-odata';

export class Orders_QryCollection extends ODataCollection<Orders_Qry> {
  static type = 'NorthwindModel.Orders_QryCollection';
  static Model = Orders_Qry;
}