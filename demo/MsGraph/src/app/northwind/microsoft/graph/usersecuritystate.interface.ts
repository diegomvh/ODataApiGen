import { emailRole } from './emailrole.enum';
import { logonType } from './logontype.enum';
import { userAccountSecurityType } from './useraccountsecuritytype.enum';

export interface userSecurityState {
  aadUserId: string;
  accountName: string;
  domainName: string;
  emailRole: emailRole;
  isVpn: boolean;
  logonDateTime: Date;
  logonId: string;
  logonIp: string;
  logonLocation: string;
  logonType: logonType;
  onPremisesSecurityIdentifier: string;
  riskScore: string;
  userAccountType: userAccountSecurityType;
  userPrincipalName: string
}
