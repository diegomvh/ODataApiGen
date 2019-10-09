import { teamMemberSettings } from './teammembersettings.interface';
import { teamGuestSettings } from './teamguestsettings.interface';
import { teamMessagingSettings } from './teammessagingsettings.interface';
import { teamFunSettings } from './teamfunsettings.interface';
import { entity } from './entity.interface';
import { channel } from './channel.interface';
import { teamsAppInstallation } from './teamsappinstallation.interface';
import { teamsAsyncOperation } from './teamsasyncoperation.interface';

export interface team extends entity {
  webUrl: string;
  memberSettings: teamMemberSettings;
  guestSettings: teamGuestSettings;
  messagingSettings: teamMessagingSettings;
  funSettings: teamFunSettings;
  isArchived: boolean;
  channels?: channel[];
  installedApps?: teamsAppInstallation[];
  operations?: teamsAsyncOperation[]
}
