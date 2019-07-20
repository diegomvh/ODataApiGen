
import { ODataModel, ODataModelSchema, ODataCollection } from 'angular-odata';

export const CitySchema = new ODataModelSchema({
  fields: [
    {name: 'Name', type: 'string', required: false, length: 0, collection: false},
      {name: 'CountryRegion', type: 'string', required: false, length: 0, collection: false},
      {name: 'Region', type: 'string', required: false, length: 0, collection: false}
  ],
  relations: [
    
  ],
  defaults: {}
});

export class City extends ODataModel {
  Name?: string;
  CountryRegion?: string;
  Region?: string;
  protected schema: ODataModelSchema = CitySchema;
}

export class CityCollection extends ODataCollection<City> {
}