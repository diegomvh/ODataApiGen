import { managedAppAvailability } from './managedappavailability.enum';
import { mobileApp } from './mobileapp.interface';

export interface managedApp extends mobileApp {
  appAvailability: managedAppAvailability;
  version: string
}
