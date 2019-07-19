import { PlanItem, PlanItemCollection } from './planitem.model';
import { ODataModel, ODataModelOptions, ODataCollection } from 'angular-odata';

export class PublicTransportation extends PlanItem {
  SeatNumber?: string;
  private static _meta: ODataModelOptions<PublicTransportation> = new ODataModelOptions<PublicTransportation>({
    fields: [
      {name: 'SeatNumber', type: 'string', required: false, length: 0, collection: false}
    ],
    relations: [
      
    ],
    defaults: {}
  });
  protected meta() { return PublicTransportation._meta; }
}

export class PublicTransportationCollection extends ODataCollection<PublicTransportation> {
}