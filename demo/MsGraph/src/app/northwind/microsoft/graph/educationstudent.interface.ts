import { educationGender } from './educationgender.enum';

export interface educationStudent {
  graduationYear: string;
  grade: string;
  birthDate: any;
  gender: educationGender;
  studentNumber: string;
  externalId: string
}
