import { invitedUserMessageInfo } from './invitedusermessageinfo.interface';
import { entity } from './entity.interface';
import { user } from './user.interface';

export interface invitation extends entity {
  invitedUserDisplayName: string;
  invitedUserType: string;
  invitedUserEmailAddress: string;
  invitedUserMessageInfo: invitedUserMessageInfo;
  sendInvitationMessage: boolean;
  inviteRedirectUrl: string;
  inviteRedeemUrl: string;
  status: string;
  invitedUser?: user
}
