import { City, CityCollection } from './city.model';
import { ODataModel, ODataModelSchema, ODataCollection } from 'angular-odata';

export const LocationSchema = new ODataModelSchema({
  fields: [
    {name: 'Address', type: 'string', required: false, length: 0, collection: false},
      {name: 'City', type: 'City', required: false, length: 0, collection: false}
  ],
  relations: [
    
  ],
  defaults: {}
});

export class Location extends ODataModel {
  Address?: string;
  City?: City;
  protected schema: ODataModelSchema = LocationSchema;
}

export class LocationCollection extends ODataCollection<Location> {
}