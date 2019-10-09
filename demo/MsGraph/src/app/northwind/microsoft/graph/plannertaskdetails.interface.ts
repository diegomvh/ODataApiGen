import { plannerPreviewType } from './plannerpreviewtype.enum';
import { plannerExternalReferences } from './plannerexternalreferences.interface';
import { plannerChecklistItems } from './plannerchecklistitems.interface';
import { entity } from './entity.interface';

export interface plannerTaskDetails extends entity {
  description: string;
  previewType: plannerPreviewType;
  references: plannerExternalReferences;
  checklist: plannerChecklistItems
}
