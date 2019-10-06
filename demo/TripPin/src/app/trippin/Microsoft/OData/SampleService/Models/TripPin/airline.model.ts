import { ODataModel, Schema } from 'angular-odata';


export class Airline extends ODataModel {
  static schema = Schema.create({ 
    keys: [
      {name: 'AirlineCode'}
    ],
    fields: [
      {name: 'AirlineCode', type: 'String', required: true},
      {name: 'Name', type: 'String', required: true}
    ]
  });
  AirlineCode: string;
  Name: string
}