
export interface deviceHealthAttestationState {
  lastUpdateDateTime: string;
  contentNamespaceUrl: string;
  deviceHealthAttestationStatus: string;
  contentVersion: string;
  issuedDateTime: Date;
  attestationIdentityKey: string;
  resetCount: number;
  restartCount: number;
  dataExcutionPolicy: string;
  bitLockerStatus: string;
  bootManagerVersion: string;
  codeIntegrityCheckVersion: string;
  secureBoot: string;
  bootDebugging: string;
  operatingSystemKernelDebugging: string;
  codeIntegrity: string;
  testSigning: string;
  safeMode: string;
  windowsPE: string;
  earlyLaunchAntiMalwareDriverProtection: string;
  virtualSecureMode: string;
  pcrHashAlgorithm: string;
  bootAppSecurityVersion: string;
  bootManagerSecurityVersion: string;
  tpmVersion: string;
  pcr0: string;
  secureBootConfigurationPolicyFingerPrint: string;
  codeIntegrityPolicy: string;
  bootRevisionListInfo: string;
  operatingSystemRevListInfo: string;
  healthStatusMismatchInfo: string;
  healthAttestationSupportedStatus: string
}
