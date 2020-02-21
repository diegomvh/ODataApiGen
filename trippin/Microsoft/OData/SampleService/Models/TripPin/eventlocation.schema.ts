import { LocationSchema } from './location.schema';

export const EventLocationSchema = Object.assign({}, LocationSchema, {
  BuildingInfo: {type: 'string'}
});