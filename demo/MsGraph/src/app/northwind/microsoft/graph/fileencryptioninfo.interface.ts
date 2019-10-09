
export interface fileEncryptionInfo {
  encryptionKey: string;
  initializationVector: string;
  mac: string;
  macKey: string;
  profileIdentifier: string;
  fileDigest: string;
  fileDigestAlgorithm: string
}
