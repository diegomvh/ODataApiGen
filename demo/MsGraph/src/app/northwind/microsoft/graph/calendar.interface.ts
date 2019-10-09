import { calendarColor } from './calendarcolor.enum';
import { emailAddress } from './emailaddress.interface';
import { entity } from './entity.interface';
import { event } from './event.interface';
import { singleValueLegacyExtendedProperty } from './singlevaluelegacyextendedproperty.interface';
import { multiValueLegacyExtendedProperty } from './multivaluelegacyextendedproperty.interface';

export interface calendar extends entity {
  name: string;
  color: calendarColor;
  changeKey: string;
  canShare: boolean;
  canViewPrivateItems: boolean;
  canEdit: boolean;
  owner: emailAddress;
  singleValueExtendedProperties?: singleValueLegacyExtendedProperty[];
  multiValueExtendedProperties?: multiValueLegacyExtendedProperty[];
  events?: event[];
  calendarView?: event[]
}
