import { entity } from './entity.interface';

export interface attachment extends entity {
  lastModifiedDateTime: Date;
  name: string;
  contentType: string;
  size: number;
  isInline: boolean
}
