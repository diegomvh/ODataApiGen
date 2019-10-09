

export const ISFLAGS_RISKEVENTTYPE = false;
export enum riskEventType {
  unlikelyTravel = 0,
  anonymizedIPAddress = 1,
  maliciousIPAddress = 2,
  unfamiliarFeatures = 3,
  malwareInfectedIPAddress = 4,
  suspiciousIPAddress = 5,
  leakedCredentials = 6,
  investigationsThreatIntelligence = 7,
  generic = 8,
  adminConfirmedUserCompromised = 9,
  mcasImpossibleTravel = 10,
  mcasSuspiciousInboxManipulationRules = 11,
  investigationsThreatIntelligenceSigninLinked = 12,
  maliciousIPAddressValidCredentialsBlockedIP = 13,
  unknownFutureValue = 14
}
