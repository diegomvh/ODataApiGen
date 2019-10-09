import { managedApp } from './managedapp.interface';
import { mobileAppContent } from './mobileappcontent.interface';

export interface managedMobileLobApp extends managedApp {
  committedContentVersion: string;
  fileName: string;
  size: number;
  contentVersions?: mobileAppContent[]
}
