import { ODataModel, Schema } from 'angular-odata';


export class City extends ODataModel {
  static schema = Schema.create({ 
    keys: [
      
    ],
    fields: [
      {name: 'CountryRegion', type: 'String', required: true},
      {name: 'Name', type: 'String', required: true},
      {name: 'Region', type: 'String', required: true}
    ]
  });
  CountryRegion: string;
  Name: string;
  Region: string
}