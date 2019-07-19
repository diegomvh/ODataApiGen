import { Location, LocationCollection } from './location.model';
import { ODataModel, ODataModelOptions, ODataCollection } from 'angular-odata';

export class AirportLocation extends Location {
  Loc?: GeographyPoint;
  private static _meta: ODataModelOptions<AirportLocation> = new ODataModelOptions<AirportLocation>({
    fields: [
      {name: 'Loc', type: 'GeographyPoint', required: false, length: 0, collection: false}
    ],
    relations: [
      
    ],
    defaults: {}
  });
  protected meta() { return AirportLocation._meta; }
}

export class AirportLocationCollection extends ODataCollection<AirportLocation> {
}