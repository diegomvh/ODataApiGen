
import { ODataModel, ODataModelOptions, ODataCollection } from 'angular-odata';

export class City extends ODataModel {
  Name?: string;
  CountryRegion?: string;
  Region?: string;
  private static _meta: ODataModelOptions<City> = new ODataModelOptions<City>({
    fields: [
      {name: 'Name', type: 'string', required: false, length: 0, collection: false},
      {name: 'CountryRegion', type: 'string', required: false, length: 0, collection: false},
      {name: 'Region', type: 'string', required: false, length: 0, collection: false}
    ],
    relations: [
      
    ],
    defaults: {}
  });
  protected meta() { return City._meta; }
}

export class CityCollection extends ODataCollection<City> {
}