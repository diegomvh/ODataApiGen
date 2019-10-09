import { fileHashType } from './filehashtype.enum';

export interface fileHash {
  hashType: fileHashType;
  hashValue: string
}
