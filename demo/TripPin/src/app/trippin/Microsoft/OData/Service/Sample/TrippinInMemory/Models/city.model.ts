
import {{ Schema, Model, ODataModel, ODataCollection }} from 'angular-odata';
export class City extends Model {
  static schema = Schema.create({
    fields: [
      {name: 'Name', type: 'string', constructor: String, required: true, collection: false},
      {name: 'CountryRegion', type: 'string', constructor: String, required: true, collection: false},
      {name: 'Region', type: 'string', constructor: String, required: true, collection: false}
    ],
    relationships: [
      
    ],
    defaults: {}
  });
  Name: string;
  CountryRegion: string;
  Region: string;
}