import { bitLockerEncryptionMethod } from './bitlockerencryptionmethod.enum';

export interface bitLockerRemovableDrivePolicy {
  encryptionMethod: bitLockerEncryptionMethod;
  requireEncryptionForWriteAccess: boolean;
  blockCrossOrganizationWriteAccess: boolean
}
