import { EntityConfig } from 'angular-odata';

//#region ODataApi Imports
import { Address } from './address.entity';
//#endregion

export const AddressConfig = {
  name: "Address",
  annotations: [],
  fields: {
    Street: {type: 'Edm.String'},
    City: {type: 'Edm.String'},
    State: {type: 'Edm.String'},
    ZipCode: {type: 'Edm.String'},
    Country: {type: 'Edm.String'}
  }
} as EntityConfig<Address>;