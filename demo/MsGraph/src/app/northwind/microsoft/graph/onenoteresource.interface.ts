import { onenoteEntityBaseModel } from './onenoteentitybasemodel.interface';

export interface onenoteResource extends onenoteEntityBaseModel {
  content: any;
  contentUrl: string
}
