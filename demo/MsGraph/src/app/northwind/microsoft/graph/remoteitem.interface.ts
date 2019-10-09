import { identitySet } from './identityset.interface';
import { sharepointIds } from './sharepointids.interface';
import { file } from './file.interface';
import { fileSystemInfo } from './filesysteminfo.interface';
import { folder } from './folder.interface';
import { package } from './package.interface';
import { itemReference } from './itemreference.interface';
import { shared } from './shared.interface';
import { specialFolder } from './specialfolder.interface';

export interface remoteItem {
  createdBy: identitySet;
  createdDateTime: Date;
  file: file;
  fileSystemInfo: fileSystemInfo;
  folder: folder;
  id: string;
  lastModifiedBy: identitySet;
  lastModifiedDateTime: Date;
  name: string;
  package: package;
  parentReference: itemReference;
  shared: shared;
  sharepointIds: sharepointIds;
  size: number;
  specialFolder: specialFolder;
  webDavUrl: string;
  webUrl: string
}
