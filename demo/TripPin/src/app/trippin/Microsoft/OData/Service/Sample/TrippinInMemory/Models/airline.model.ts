
import { ODataModel, ODataModelOptions, ODataCollection } from 'angular-odata';

export class Airline extends ODataModel {
  AirlineCode: string;
  Name?: string;
  private static _meta: ODataModelOptions<Airline> = new ODataModelOptions<Airline>({
    fields: [
      {name: 'AirlineCode', type: 'string', required: true, length: 0, collection: false},
      {name: 'Name', type: 'string', required: false, length: 0, collection: false}
    ],
    relations: [
      
    ],
    defaults: {}
  });
  protected meta() { return Airline._meta; }
}

export class AirlineCollection extends ODataCollection<Airline> {
}