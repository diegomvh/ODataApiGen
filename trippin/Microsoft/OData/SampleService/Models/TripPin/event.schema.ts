import { EventLocationSchema } from './eventlocation.schema';
import { PlanItemSchema } from './planitem.schema';

export const EventSchema = Object.assign({}, PlanItemSchema, {
  Description: {type: 'string'},
  OccursAt: {type: 'Microsoft.OData.SampleService.Models.TripPin.EventLocation', nullable: false}
});