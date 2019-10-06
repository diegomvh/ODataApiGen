import { ODataModel, Schema } from 'angular-odata';

import { Location } from './location.model';
import { LocationCollection } from './location.collection';

export class EventLocation extends Location {
  static schema = Location.schema.extend({ 
    keys: [
      
    ],
    fields: [
      {name: 'BuildingInfo', type: 'String', required: true}
    ]
  });
  BuildingInfo: string
}