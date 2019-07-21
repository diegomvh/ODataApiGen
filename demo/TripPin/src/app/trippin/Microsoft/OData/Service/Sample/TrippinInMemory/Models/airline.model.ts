
import {{ Schema, Model, ODataModel, ODataCollection }} from 'angular-odata';
export class Airline extends ODataModel {
  static schema = Schema.create({
    fields: [
      {name: 'AirlineCode', type: 'string', constructor: String, required: true, collection: false},
      {name: 'Name', type: 'string', constructor: String, required: true, collection: false}
    ],
    relationships: [
      
    ],
    defaults: {}
  });
  AirlineCode: string;
  Name: string;
}
export class AirlineCollection extends ODataCollection<Airline> {
  static Model = Airline;
}