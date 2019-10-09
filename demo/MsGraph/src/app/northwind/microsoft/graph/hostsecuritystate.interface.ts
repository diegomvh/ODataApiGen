
export interface hostSecurityState {
  fqdn: string;
  isAzureAdJoined: boolean;
  isAzureAdRegistered: boolean;
  isHybridAzureDomainJoined: boolean;
  netBiosName: string;
  os: string;
  privateIpAddress: string;
  publicIpAddress: string;
  riskScore: string
}
