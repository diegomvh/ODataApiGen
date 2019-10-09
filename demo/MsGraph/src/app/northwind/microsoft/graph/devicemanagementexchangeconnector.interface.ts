import { deviceManagementExchangeConnectorStatus } from './devicemanagementexchangeconnectorstatus.enum';
import { deviceManagementExchangeConnectorType } from './devicemanagementexchangeconnectortype.enum';
import { entity } from './entity.interface';

export interface deviceManagementExchangeConnector extends entity {
  lastSyncDateTime: Date;
  status: deviceManagementExchangeConnectorStatus;
  primarySmtpAddress: string;
  serverName: string;
  connectorServerName: string;
  exchangeConnectorType: deviceManagementExchangeConnectorType;
  version: string;
  exchangeAlias: string;
  exchangeOrganization: string
}
