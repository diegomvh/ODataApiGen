import { Json } from './json.interface';
import { entity } from './entity.interface';

export interface workbookFunctionResult extends entity {
  error: string;
  value: Json
}
