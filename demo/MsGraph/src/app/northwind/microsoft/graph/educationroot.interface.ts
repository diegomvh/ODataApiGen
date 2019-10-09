import { entity } from './entity.interface';
import { educationClass } from './educationclass.interface';
import { educationSchool } from './educationschool.interface';
import { educationUser } from './educationuser.interface';

export interface educationRoot extends entity {
  classes?: educationClass[];
  schools?: educationSchool[];
  users?: educationUser[];
  me?: educationUser
}
