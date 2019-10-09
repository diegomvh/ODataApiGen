import { mimeContent } from './mimecontent.interface';
import { rgbColor } from './rgbcolor.interface';

export interface intuneBrand {
  displayName: string;
  contactITName: string;
  contactITPhoneNumber: string;
  contactITEmailAddress: string;
  contactITNotes: string;
  privacyUrl: string;
  onlineSupportSiteUrl: string;
  onlineSupportSiteName: string;
  themeColor: rgbColor;
  showLogo: boolean;
  lightBackgroundLogo: mimeContent;
  darkBackgroundLogo: mimeContent;
  showNameNextToLogo: boolean;
  showDisplayNameNextToLogo: boolean
}
