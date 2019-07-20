
import { ODataModel, ODataModelSchema, ODataCollection } from 'angular-odata';

export const AirlineSchema = new ODataModelSchema({
  fields: [
    {name: 'AirlineCode', type: 'string', required: true, length: 0, collection: false},
      {name: 'Name', type: 'string', required: false, length: 0, collection: false}
  ],
  relations: [
    
  ],
  defaults: {}
});

export class Airline extends ODataModel {
  AirlineCode: string;
  Name?: string;
  protected schema: ODataModelSchema = AirlineSchema;
}

export class AirlineCollection extends ODataCollection<Airline> {
}