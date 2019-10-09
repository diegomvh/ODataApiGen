import { mailFolder } from './mailfolder.interface';

export interface mailSearchFolder extends mailFolder {
  isSupported: boolean;
  includeNestedFolders: boolean;
  sourceFolderIds: string[];
  filterQuery: string
}
