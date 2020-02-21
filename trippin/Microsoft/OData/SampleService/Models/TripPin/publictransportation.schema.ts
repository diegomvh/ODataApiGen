import { PlanItemSchema } from './planitem.schema';

export const PublicTransportationSchema = Object.assign({}, PlanItemSchema, {
  SeatNumber: {type: 'string'}
});