import { Duration } from 'angular-odata';

//#region ODataApi Imports
import { Address } from './address.entity';
//#endregion

export interface PersonDetail {
  //#region ODataApi Properties
  PersonID: number;
  Age: number;
  Gender: boolean;
  Phone?: string;
  Address?: Address;
  Photo: any;
  Liquid error: Object reference not set to an instance of an object.: Liquid error: Object reference not set to an instance of an object.;
  //#endregion
}