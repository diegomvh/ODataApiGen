import { onenoteEntityHierarchyModel } from './onenoteentityhierarchymodel.interface';
import { notebook } from './notebook.interface';
import { onenoteSection } from './onenotesection.interface';

export interface sectionGroup extends onenoteEntityHierarchyModel {
  sectionsUrl: string;
  sectionGroupsUrl: string;
  parentNotebook?: notebook;
  parentSectionGroup?: sectionGroup;
  sections?: onenoteSection[];
  sectionGroups?: sectionGroup[]
}
