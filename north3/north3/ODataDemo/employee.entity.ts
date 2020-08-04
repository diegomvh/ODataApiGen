import { Duration } from 'angular-odata';

//#region ODataApi Imports
import { Person } from './person.entity';
//#endregion

export interface Employee extends Person {
  //#region ODataApi Properties
  EmployeeID: number;
  HireDate: any;
  Salary: number;
  //#endregion
}