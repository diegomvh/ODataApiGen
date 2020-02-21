import { LocationSchema } from './location.schema';

export const AirportLocationSchema = Object.assign({}, LocationSchema, {
  Loc: {type: 'Object', nullable: false, srid: 4326}
});