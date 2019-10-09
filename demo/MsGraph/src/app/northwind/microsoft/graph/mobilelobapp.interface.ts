import { mobileApp } from './mobileapp.interface';
import { mobileAppContent } from './mobileappcontent.interface';

export interface mobileLobApp extends mobileApp {
  committedContentVersion: string;
  fileName: string;
  size: number;
  contentVersions?: mobileAppContent[]
}
