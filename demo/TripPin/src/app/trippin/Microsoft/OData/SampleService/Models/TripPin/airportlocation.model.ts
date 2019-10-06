import { ODataModel, Schema } from 'angular-odata';

import { Location } from './location.model';
import { LocationCollection } from './location.collection';

export class AirportLocation extends Location {
  static schema = Location.schema.extend({ 
    keys: [
      
    ],
    fields: [
      {name: 'Loc', type: 'Object', required: true}
    ]
  });
  Loc: any
}