import { City, CityCollection } from './city.model';
import {{ Schema, Model, ODataModel, ODataCollection }} from 'angular-odata';
export class Location extends Model {
  static schema = Schema.create({
    fields: [
      {name: 'Address', type: 'string', constructor: String, required: true, collection: false},
      {name: 'City', type: 'City', constructor: City, required: true, collection: false}
    ],
    relationships: [
      
    ],
    defaults: {}
  });
  Address: string;
  City: City;
}