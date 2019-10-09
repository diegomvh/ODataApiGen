import { mobileAppContentFileUploadState } from './mobileappcontentfileuploadstate.enum';
import { entity } from './entity.interface';

export interface mobileAppContentFile extends entity {
  azureStorageUri: string;
  isCommitted: boolean;
  createdDateTime: Date;
  name: string;
  size: number;
  sizeEncrypted: number;
  azureStorageUriExpirationDateTime: Date;
  manifest: string;
  uploadState: mobileAppContentFileUploadState
}
