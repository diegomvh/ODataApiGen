import { mimeContent } from './mimecontent.interface';
import { entity } from './entity.interface';
import { managedEBookAssignment } from './managedebookassignment.interface';
import { eBookInstallSummary } from './ebookinstallsummary.interface';
import { deviceInstallState } from './deviceinstallstate.interface';
import { userInstallStateSummary } from './userinstallstatesummary.interface';

export interface managedEBook extends entity {
  displayName: string;
  description: string;
  publisher: string;
  publishedDateTime: Date;
  largeCover: mimeContent;
  createdDateTime: Date;
  lastModifiedDateTime: Date;
  informationUrl: string;
  privacyInformationUrl: string;
  assignments?: managedEBookAssignment[];
  installSummary?: eBookInstallSummary;
  deviceStates?: deviceInstallState[];
  userStateSummary?: userInstallStateSummary[]
}
