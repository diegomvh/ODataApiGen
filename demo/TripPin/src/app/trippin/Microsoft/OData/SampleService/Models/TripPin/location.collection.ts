import { ODataCollection } from 'angular-odata';

import { Location } from './location.model';

export class LocationCollection extends ODataCollection<Location> {
  static model = Location;
}
