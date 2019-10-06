import { ODataModel, Schema } from 'angular-odata';

import { EventLocation } from './eventlocation.model';
import { PlanItem } from './planitem.model';
import { EventLocationCollection } from './eventlocation.collection';
import { PlanItemCollection } from './planitem.collection';

export class Event extends PlanItem {
  static schema = PlanItem.schema.extend({ 
    keys: [
      
    ],
    fields: [
      {name: 'Description', type: 'String', required: true},
      {name: 'OccursAt', type: 'Microsoft.OData.SampleService.Models.TripPin.EventLocation', required: true}
    ]
  });
  Description: string;
  OccursAt: EventLocation
}