import { ODataCollection } from 'angular-odata';

import { Photo } from './photo.model';

export class PhotoCollection extends ODataCollection<Photo> {
  static model = Photo;
}
