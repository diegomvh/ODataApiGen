import { connectionDirection } from './connectiondirection.enum';
import { connectionStatus } from './connectionstatus.enum';
import { securityNetworkProtocol } from './securitynetworkprotocol.enum';

export interface networkConnection {
  applicationName: string;
  destinationAddress: string;
  destinationDomain: string;
  destinationPort: string;
  destinationUrl: string;
  direction: connectionDirection;
  domainRegisteredDateTime: Date;
  localDnsName: string;
  natDestinationAddress: string;
  natDestinationPort: string;
  natSourceAddress: string;
  natSourcePort: string;
  protocol: securityNetworkProtocol;
  riskScore: string;
  sourceAddress: string;
  sourcePort: string;
  status: connectionStatus;
  urlParameters: string
}
