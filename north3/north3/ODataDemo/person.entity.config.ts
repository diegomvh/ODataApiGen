import { EntityConfig } from 'angular-odata';

//#region ODataApi Imports
import { Person } from './person.entity';
//#endregion

export const PersonConfig = {
  name: "Person",
  annotations: [],
  fields: {
    ID: {type: 'Edm.Int32', key: true, ref: 'ID', nullable: false},
    Name: {type: 'Edm.String'},
    PersonDetail: {type: '', navigation: true}
  }
} as EntityConfig<Person>;