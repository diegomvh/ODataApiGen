import { Location, LocationCollection } from './location.model';
import { ODataModel, ODataModelSchema, ODataCollection } from 'angular-odata';

export const AirportLocationSchema = new ODataModelSchema({
  fields: [
    {name: 'Loc', type: 'GeographyPoint', required: false, length: 0, collection: false}
  ],
  relations: [
    
  ],
  defaults: {}
});

export class AirportLocation extends Location {
  Loc?: number[];
  protected schema: ODataModelSchema = AirportLocationSchema;
}

export class AirportLocationCollection extends ODataCollection<AirportLocation> {
}