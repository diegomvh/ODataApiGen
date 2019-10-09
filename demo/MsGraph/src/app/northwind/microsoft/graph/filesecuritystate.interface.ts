import { fileHash } from './filehash.interface';

export interface fileSecurityState {
  fileHash: fileHash;
  name: string;
  path: string;
  riskScore: string
}
