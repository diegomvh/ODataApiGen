import { mobileAppPublishingState } from './mobileapppublishingstate.enum';
import { mimeContent } from './mimecontent.interface';
import { entity } from './entity.interface';
import { mobileAppCategory } from './mobileappcategory.interface';
import { mobileAppAssignment } from './mobileappassignment.interface';

export interface mobileApp extends entity {
  displayName: string;
  description: string;
  publisher: string;
  largeIcon: mimeContent;
  createdDateTime: Date;
  lastModifiedDateTime: Date;
  isFeatured: boolean;
  privacyInformationUrl: string;
  informationUrl: string;
  owner: string;
  developer: string;
  notes: string;
  publishingState: mobileAppPublishingState;
  categories?: mobileAppCategory[];
  assignments?: mobileAppAssignment[]
}
