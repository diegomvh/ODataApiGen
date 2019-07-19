import { Location, LocationCollection } from './location.model';
import { ODataModel, ODataModelOptions, ODataCollection } from 'angular-odata';

export class EventLocation extends Location {
  BuildingInfo?: string;
  private static _meta: ODataModelOptions<EventLocation> = new ODataModelOptions<EventLocation>({
    fields: [
      {name: 'BuildingInfo', type: 'string', required: false, length: 0, collection: false}
    ],
    relations: [
      
    ],
    defaults: {}
  });
  protected meta() { return EventLocation._meta; }
}

export class EventLocationCollection extends ODataCollection<EventLocation> {
}