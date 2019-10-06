import { ODataCollection } from 'angular-odata';

import { Trip } from './trip.model';

export class TripCollection extends ODataCollection<Trip> {
  static model = Trip;
}
