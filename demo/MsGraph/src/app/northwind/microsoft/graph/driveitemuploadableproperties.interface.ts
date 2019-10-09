import { fileSystemInfo } from './filesysteminfo.interface';

export interface driveItemUploadableProperties {
  description: string;
  fileSystemInfo: fileSystemInfo;
  name: string
}
