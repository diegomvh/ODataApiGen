import { geoCoordinates } from './geocoordinates.interface';

export interface signInLocation {
  city: string;
  state: string;
  countryOrRegion: string;
  geoCoordinates: geoCoordinates
}
