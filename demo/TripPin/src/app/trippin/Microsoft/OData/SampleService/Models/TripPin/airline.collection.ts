import { ODataCollection } from 'angular-odata';

import { Airline } from './airline.model';

export class AirlineCollection extends ODataCollection<Airline> {
  static model = Airline;
}
