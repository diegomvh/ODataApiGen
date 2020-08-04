import { EntityConfig } from 'angular-odata';

//#region ODataApi Imports
import { Customer } from './customer.entity';
//#endregion

export const CustomerConfig = {
  name: "Customer",
  base: "ODataDemo.Person",
  annotations: [],
  fields: {
    TotalExpense: {type: 'Edm.Decimal', nullable: false}
  }
} as EntityConfig<Customer>;