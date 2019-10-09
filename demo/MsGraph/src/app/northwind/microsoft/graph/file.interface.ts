import { hashes } from './hashes.interface';

export interface file {
  hashes: hashes;
  mimeType: string;
  processingMetadata: boolean
}
