import { iosHomeScreenItem } from './ioshomescreenitem.interface';
import { iosHomeScreenFolderPage } from './ioshomescreenfolderpage.interface';

export interface iosHomeScreenFolder extends iosHomeScreenItem {
  pages: iosHomeScreenFolderPage[]
}
