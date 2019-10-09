

export const ISFLAGS_MANAGEMENTAGENTTYPE = false;
export enum managementAgentType {
  eas = 1,
  mdm = 2,
  easMdm = 3,
  intuneClient = 4,
  easIntuneClient = 5,
  configurationManagerClient = 8,
  configurationManagerClientMdm = 10,
  configurationManagerClientMdmEas = 11,
  unknown = 16,
  jamf = 32,
  googleCloudDevicePolicyController = 64
}
