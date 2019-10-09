import { inferenceClassificationType } from './inferenceclassificationtype.enum';
import { emailAddress } from './emailaddress.interface';
import { entity } from './entity.interface';

export interface inferenceClassificationOverride extends entity {
  classifyAs: inferenceClassificationType;
  senderEmailAddress: emailAddress
}
