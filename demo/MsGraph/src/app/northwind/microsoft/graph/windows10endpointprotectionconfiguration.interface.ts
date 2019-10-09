import { firewallPreSharedKeyEncodingMethodType } from './firewallpresharedkeyencodingmethodtype.enum';
import { firewallCertificateRevocationListCheckMethodType } from './firewallcertificaterevocationlistcheckmethodtype.enum';
import { firewallPacketQueueingMethodType } from './firewallpacketqueueingmethodtype.enum';
import { appLockerApplicationControlType } from './applockerapplicationcontroltype.enum';
import { applicationGuardBlockFileTransferType } from './applicationguardblockfiletransfertype.enum';
import { applicationGuardBlockClipboardSharingType } from './applicationguardblockclipboardsharingtype.enum';
import { windowsFirewallNetworkProfile } from './windowsfirewallnetworkprofile.interface';
import { bitLockerRemovableDrivePolicy } from './bitlockerremovabledrivepolicy.interface';
import { deviceConfiguration } from './deviceconfiguration.interface';

export interface windows10EndpointProtectionConfiguration extends deviceConfiguration {
  firewallBlockStatefulFTP: boolean;
  firewallIdleTimeoutForSecurityAssociationInSeconds: number;
  firewallPreSharedKeyEncodingMethod: firewallPreSharedKeyEncodingMethodType;
  firewallIPSecExemptionsAllowNeighborDiscovery: boolean;
  firewallIPSecExemptionsAllowICMP: boolean;
  firewallIPSecExemptionsAllowRouterDiscovery: boolean;
  firewallIPSecExemptionsAllowDHCP: boolean;
  firewallCertificateRevocationListCheckMethod: firewallCertificateRevocationListCheckMethodType;
  firewallMergeKeyingModuleSettings: boolean;
  firewallPacketQueueingMethod: firewallPacketQueueingMethodType;
  firewallProfileDomain: windowsFirewallNetworkProfile;
  firewallProfilePublic: windowsFirewallNetworkProfile;
  firewallProfilePrivate: windowsFirewallNetworkProfile;
  defenderAttackSurfaceReductionExcludedPaths: string[];
  defenderGuardedFoldersAllowedAppPaths: string[];
  defenderAdditionalGuardedFolders: string[];
  defenderExploitProtectionXml: string;
  defenderExploitProtectionXmlFileName: string;
  defenderSecurityCenterBlockExploitProtectionOverride: boolean;
  appLockerApplicationControl: appLockerApplicationControlType;
  smartScreenEnableInShell: boolean;
  smartScreenBlockOverrideForFiles: boolean;
  applicationGuardEnabled: boolean;
  applicationGuardBlockFileTransfer: applicationGuardBlockFileTransferType;
  applicationGuardBlockNonEnterpriseContent: boolean;
  applicationGuardAllowPersistence: boolean;
  applicationGuardForceAuditing: boolean;
  applicationGuardBlockClipboardSharing: applicationGuardBlockClipboardSharingType;
  applicationGuardAllowPrintToPDF: boolean;
  applicationGuardAllowPrintToXPS: boolean;
  applicationGuardAllowPrintToLocalPrinters: boolean;
  applicationGuardAllowPrintToNetworkPrinters: boolean;
  bitLockerDisableWarningForOtherDiskEncryption: boolean;
  bitLockerEnableStorageCardEncryptionOnMobile: boolean;
  bitLockerEncryptDevice: boolean;
  bitLockerRemovableDrivePolicy: bitLockerRemovableDrivePolicy
}
