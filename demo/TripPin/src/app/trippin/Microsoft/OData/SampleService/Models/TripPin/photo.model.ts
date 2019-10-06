import { ODataModel, Schema } from 'angular-odata';


export class Photo extends ODataModel {
  static schema = Schema.create({ 
    keys: [
      {name: 'Id'}
    ],
    fields: [
      {name: 'Id', type: 'Number', required: true},
      {name: 'Name', type: 'String', required: true}
    ]
  });
  Id: number;
  Name: string
}