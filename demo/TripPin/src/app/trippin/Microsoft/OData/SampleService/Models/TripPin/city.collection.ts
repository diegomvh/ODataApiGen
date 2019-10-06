import { ODataCollection } from 'angular-odata';

import { City } from './city.model';

export class CityCollection extends ODataCollection<City> {
  static model = City;
}
