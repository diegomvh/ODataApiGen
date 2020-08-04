import { EntityConfig } from 'angular-odata';

//#region ODataApi Imports
import { PersonDetail } from './persondetail.entity';
//#endregion

export const PersonDetailConfig = {
  name: "PersonDetail",
  annotations: [],
  fields: {
    PersonID: {type: 'Edm.Int32', key: true, ref: 'PersonID', nullable: false},
    Age: {type: 'Edm.Byte', nullable: false},
    Gender: {type: 'Edm.Boolean', nullable: false},
    Phone: {type: 'Edm.String'},
    Address: {type: 'ODataDemo.Address'},
    Photo: {type: 'Edm.Stream', nullable: false},
    Person: {type: '', navigation: true}
  }
} as EntityConfig<PersonDetail>;