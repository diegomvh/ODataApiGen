import { Duration } from 'angular-odata';

//#region ODataApi Imports
import { Person } from './person.entity';
//#endregion

export interface Customer extends Person {
  //#region ODataApi Properties
  TotalExpense: number;
  //#endregion
}