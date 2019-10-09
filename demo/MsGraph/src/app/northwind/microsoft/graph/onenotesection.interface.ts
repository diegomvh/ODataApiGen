import { sectionLinks } from './sectionlinks.interface';
import { onenoteEntityHierarchyModel } from './onenoteentityhierarchymodel.interface';
import { notebook } from './notebook.interface';
import { sectionGroup } from './sectiongroup.interface';
import { onenotePage } from './onenotepage.interface';

export interface onenoteSection extends onenoteEntityHierarchyModel {
  isDefault: boolean;
  links: sectionLinks;
  pagesUrl: string;
  parentNotebook?: notebook;
  parentSectionGroup?: sectionGroup;
  pages?: onenotePage[]
}
