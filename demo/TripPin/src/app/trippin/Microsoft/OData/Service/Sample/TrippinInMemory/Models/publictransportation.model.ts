import { PlanItem, PlanItemCollection } from './planitem.model';
import { ODataModel, ODataModelSchema, ODataCollection } from 'angular-odata';

export const PublicTransportationSchema = new ODataModelSchema({
  fields: [
    {name: 'SeatNumber', type: 'string', required: false, length: 0, collection: false}
  ],
  relations: [
    
  ],
  defaults: {}
});

export class PublicTransportation extends PlanItem {
  SeatNumber?: string;
  protected schema: ODataModelSchema = PublicTransportationSchema;
}

export class PublicTransportationCollection extends ODataCollection<PublicTransportation> {
}