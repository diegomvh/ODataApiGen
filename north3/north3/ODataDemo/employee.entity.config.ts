import { EntityConfig } from 'angular-odata';

//#region ODataApi Imports
import { Employee } from './employee.entity';
//#endregion

export const EmployeeConfig = {
  name: "Employee",
  base: "ODataDemo.Person",
  annotations: [],
  fields: {
    EmployeeID: {type: 'Edm.Int64', nullable: false},
    HireDate: {type: 'Edm.DateTime', nullable: false},
    Salary: {type: 'Edm.Single', nullable: false}
  }
} as EntityConfig<Employee>;