import { mobileApp } from './mobileapp.interface';

export interface webApp extends mobileApp {
  appUrl: string;
  useManagedBrowser: boolean
}
