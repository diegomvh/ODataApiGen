import { onenoteUserRole } from './onenoteuserrole.enum';
import { notebookLinks } from './notebooklinks.interface';
import { onenoteEntityHierarchyModel } from './onenoteentityhierarchymodel.interface';
import { onenoteSection } from './onenotesection.interface';
import { sectionGroup } from './sectiongroup.interface';

export interface notebook extends onenoteEntityHierarchyModel {
  isDefault: boolean;
  userRole: onenoteUserRole;
  isShared: boolean;
  sectionsUrl: string;
  sectionGroupsUrl: string;
  links: notebookLinks;
  sections?: onenoteSection[];
  sectionGroups?: sectionGroup[]
}
