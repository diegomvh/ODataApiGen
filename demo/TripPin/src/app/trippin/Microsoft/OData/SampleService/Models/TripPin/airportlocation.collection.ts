import { ODataCollection } from 'angular-odata';

import { AirportLocation } from './airportlocation.model';

export class AirportLocationCollection extends ODataCollection<AirportLocation> {
  static model = AirportLocation;
}
