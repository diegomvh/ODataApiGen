import { Location, LocationCollection } from './location.model';
import { ODataModel, ODataModelSchema, ODataCollection } from 'angular-odata';

export const EventLocationSchema = new ODataModelSchema({
  fields: [
    {name: 'BuildingInfo', type: 'string', required: false, length: 0, collection: false}
  ],
  relations: [
    
  ],
  defaults: {}
});

export class EventLocation extends Location {
  BuildingInfo?: string;
  protected schema: ODataModelSchema = EventLocationSchema;
}

export class EventLocationCollection extends ODataCollection<EventLocation> {
}