import { educationExternalSource } from './educationexternalsource.enum';
import { identitySet } from './identityset.interface';
import { educationTerm } from './educationterm.interface';
import { entity } from './entity.interface';
import { group } from './group.interface';
import { educationSchool } from './educationschool.interface';
import { educationUser } from './educationuser.interface';

export interface educationClass extends entity {
  displayName: string;
  mailNickname: string;
  description: string;
  createdBy: identitySet;
  classCode: string;
  externalName: string;
  externalId: string;
  externalSource: educationExternalSource;
  term: educationTerm;
  schools?: educationSchool[];
  members?: educationUser[];
  teachers?: educationUser[];
  group?: group
}
