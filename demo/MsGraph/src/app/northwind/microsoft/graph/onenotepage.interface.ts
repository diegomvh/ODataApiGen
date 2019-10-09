import { pageLinks } from './pagelinks.interface';
import { onenoteEntitySchemaObjectModel } from './onenoteentityschemaobjectmodel.interface';
import { notebook } from './notebook.interface';
import { onenoteSection } from './onenotesection.interface';

export interface onenotePage extends onenoteEntitySchemaObjectModel {
  title: string;
  createdByAppId: string;
  links: pageLinks;
  contentUrl: string;
  content: any;
  lastModifiedDateTime: Date;
  level: number;
  order: number;
  userTags: string[];
  parentSection?: onenoteSection;
  parentNotebook?: notebook
}
