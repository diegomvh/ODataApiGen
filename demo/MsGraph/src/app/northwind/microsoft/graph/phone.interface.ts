import { phoneType } from './phonetype.enum';

export interface phone {
  type: phoneType;
  number: string;
  region: string;
  language: string
}
