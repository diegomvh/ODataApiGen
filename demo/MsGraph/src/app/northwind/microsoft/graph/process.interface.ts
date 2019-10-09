import { processIntegrityLevel } from './processintegritylevel.enum';
import { fileHash } from './filehash.interface';

export interface process {
  accountName: string;
  commandLine: string;
  createdDateTime: Date;
  fileHash: fileHash;
  integrityLevel: processIntegrityLevel;
  isElevated: boolean;
  name: string;
  parentProcessCreatedDateTime: Date;
  parentProcessId: number;
  parentProcessName: string;
  path: string;
  processId: number
}
