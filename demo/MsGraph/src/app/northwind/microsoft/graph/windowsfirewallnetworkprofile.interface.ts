import { stateManagementSetting } from './statemanagementsetting.enum';

export interface windowsFirewallNetworkProfile {
  firewallEnabled: stateManagementSetting;
  stealthModeBlocked: boolean;
  incomingTrafficBlocked: boolean;
  unicastResponsesToMulticastBroadcastsBlocked: boolean;
  inboundNotificationsBlocked: boolean;
  authorizedApplicationRulesFromGroupPolicyMerged: boolean;
  globalPortRulesFromGroupPolicyMerged: boolean;
  connectionSecurityRulesFromGroupPolicyMerged: boolean;
  outboundConnectionsBlocked: boolean;
  inboundConnectionsBlocked: boolean;
  securedPacketExemptionAllowed: boolean;
  policyRulesFromGroupPolicyMerged: boolean
}
