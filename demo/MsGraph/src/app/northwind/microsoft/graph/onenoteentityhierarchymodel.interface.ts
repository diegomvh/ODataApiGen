import { identitySet } from './identityset.interface';
import { onenoteEntitySchemaObjectModel } from './onenoteentityschemaobjectmodel.interface';

export interface onenoteEntityHierarchyModel extends onenoteEntitySchemaObjectModel {
  displayName: string;
  createdBy: identitySet;
  lastModifiedBy: identitySet;
  lastModifiedDateTime: Date
}
