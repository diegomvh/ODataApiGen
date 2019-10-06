import { ODataCollection } from 'angular-odata';

import { PublicTransportation } from './publictransportation.model';

export class PublicTransportationCollection extends ODataCollection<PublicTransportation> {
  static model = PublicTransportation;
}
