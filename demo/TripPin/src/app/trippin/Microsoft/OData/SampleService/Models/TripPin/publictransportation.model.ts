import { ODataModel, Schema } from 'angular-odata';

import { PlanItem } from './planitem.model';
import { PlanItemCollection } from './planitem.collection';

export class PublicTransportation extends PlanItem {
  static schema = PlanItem.schema.extend({ 
    keys: [
      
    ],
    fields: [
      {name: 'SeatNumber', type: 'String', required: true}
    ]
  });
  SeatNumber: string
}