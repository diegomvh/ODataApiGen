import { onenoteSourceService } from './onenotesourceservice.enum';
import { recentNotebookLinks } from './recentnotebooklinks.interface';

export interface recentNotebook {
  displayName: string;
  lastAccessedTime: Date;
  links: recentNotebookLinks;
  sourceService: onenoteSourceService
}
