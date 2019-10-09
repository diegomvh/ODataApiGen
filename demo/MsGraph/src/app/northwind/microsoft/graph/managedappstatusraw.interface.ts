import { Json } from './json.interface';
import { managedAppStatus } from './managedappstatus.interface';

export interface managedAppStatusRaw extends managedAppStatus {
  content: Json
}
