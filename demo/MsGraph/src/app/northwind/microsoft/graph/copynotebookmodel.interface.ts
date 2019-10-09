import { onenoteUserRole } from './onenoteuserrole.enum';
import { identitySet } from './identityset.interface';
import { notebookLinks } from './notebooklinks.interface';

export interface CopyNotebookModel {
  isDefault: boolean;
  userRole: onenoteUserRole;
  isShared: boolean;
  sectionsUrl: string;
  sectionGroupsUrl: string;
  links: notebookLinks;
  name: string;
  createdBy: string;
  createdByIdentity: identitySet;
  lastModifiedBy: string;
  lastModifiedByIdentity: identitySet;
  lastModifiedTime: Date;
  id: string;
  self: string;
  createdTime: Date
}
