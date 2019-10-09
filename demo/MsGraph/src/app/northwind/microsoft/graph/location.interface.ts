import { locationType } from './locationtype.enum';
import { locationUniqueIdType } from './locationuniqueidtype.enum';
import { physicalAddress } from './physicaladdress.interface';
import { outlookGeoCoordinates } from './outlookgeocoordinates.interface';

export interface location {
  displayName: string;
  locationEmailAddress: string;
  address: physicalAddress;
  locationUri: string;
  coordinates: outlookGeoCoordinates;
  locationType: locationType;
  uniqueId: string;
  uniqueIdType: locationUniqueIdType
}
