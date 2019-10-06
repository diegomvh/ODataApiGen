import { ODataCollection } from 'angular-odata';

import { Flight } from './flight.model';

export class FlightCollection extends ODataCollection<Flight> {
  static model = Flight;
}
