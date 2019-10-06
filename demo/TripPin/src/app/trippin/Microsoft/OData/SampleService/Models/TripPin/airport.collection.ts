import { ODataCollection } from 'angular-odata';

import { Airport } from './airport.model';

export class AirportCollection extends ODataCollection<Airport> {
  static model = Airport;
}
