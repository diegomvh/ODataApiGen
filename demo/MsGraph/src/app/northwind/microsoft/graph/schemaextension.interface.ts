import { extensionSchemaProperty } from './extensionschemaproperty.interface';
import { entity } from './entity.interface';

export interface schemaExtension extends entity {
  description: string;
  targetTypes: string[];
  properties: extensionSchemaProperty[];
  status: string;
  owner: string
}
