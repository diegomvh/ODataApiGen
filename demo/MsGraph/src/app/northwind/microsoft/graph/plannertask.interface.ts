import { plannerPreviewType } from './plannerpreviewtype.enum';
import { identitySet } from './identityset.interface';
import { plannerAppliedCategories } from './plannerappliedcategories.interface';
import { plannerAssignments } from './plannerassignments.interface';
import { entity } from './entity.interface';
import { plannerTaskDetails } from './plannertaskdetails.interface';
import { plannerAssignedToTaskBoardTaskFormat } from './plannerassignedtotaskboardtaskformat.interface';
import { plannerProgressTaskBoardTaskFormat } from './plannerprogresstaskboardtaskformat.interface';
import { plannerBucketTaskBoardTaskFormat } from './plannerbuckettaskboardtaskformat.interface';

export interface plannerTask extends entity {
  createdBy: identitySet;
  planId: string;
  bucketId: string;
  title: string;
  orderHint: string;
  assigneePriority: string;
  percentComplete: number;
  startDateTime: Date;
  createdDateTime: Date;
  dueDateTime: Date;
  hasDescription: boolean;
  previewType: plannerPreviewType;
  completedDateTime: Date;
  completedBy: identitySet;
  referenceCount: number;
  checklistItemCount: number;
  activeChecklistItemCount: number;
  appliedCategories: plannerAppliedCategories;
  assignments: plannerAssignments;
  conversationThreadId: string;
  details?: plannerTaskDetails;
  assignedToTaskBoardFormat?: plannerAssignedToTaskBoardTaskFormat;
  progressTaskBoardFormat?: plannerProgressTaskBoardTaskFormat;
  bucketTaskBoardFormat?: plannerBucketTaskBoardTaskFormat
}
