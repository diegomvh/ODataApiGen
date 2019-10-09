import { entity } from './entity.interface';
import { notebook } from './notebook.interface';
import { onenoteSection } from './onenotesection.interface';
import { sectionGroup } from './sectiongroup.interface';
import { onenotePage } from './onenotepage.interface';
import { onenoteResource } from './onenoteresource.interface';
import { onenoteOperation } from './onenoteoperation.interface';

export interface onenote extends entity {
  notebooks?: notebook[];
  sections?: onenoteSection[];
  sectionGroups?: sectionGroup[];
  pages?: onenotePage[];
  resources?: onenoteResource[];
  operations?: onenoteOperation[]
}
