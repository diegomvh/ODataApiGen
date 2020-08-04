import { EntityConfig } from 'angular-odata';

//#region ODataApi Imports
import { Category } from './category.entity';
//#endregion

export const CategoryConfig = {
  name: "Category",
  open: true,
  annotations: [],
  fields: {
    ID: {type: 'Edm.Int32', key: true, ref: 'ID', nullable: false},
    Name: {type: 'Edm.String'},
    Products: {type: '', navigation: true}
  }
} as EntityConfig<Category>;