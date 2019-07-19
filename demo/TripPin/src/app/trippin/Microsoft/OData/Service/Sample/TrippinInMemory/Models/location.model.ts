import { City, CityCollection } from './city.model';
import { ODataModel, ODataModelOptions, ODataCollection } from 'angular-odata';

export class Location extends ODataModel {
  Address?: string;
  City?: City;
  private static _meta: ODataModelOptions<Location> = new ODataModelOptions<Location>({
    fields: [
      {name: 'Address', type: 'string', required: false, length: 0, collection: false},
      {name: 'City', type: 'City', required: false, length: 0, collection: false}
    ],
    relations: [
      
    ],
    defaults: {}
  });
  protected meta() { return Location._meta; }
}

export class LocationCollection extends ODataCollection<Location> {
}