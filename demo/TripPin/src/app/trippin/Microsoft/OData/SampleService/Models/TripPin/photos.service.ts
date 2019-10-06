import { Injectable } from '@angular/core';

import { ODataModelService } from 'angular-odata';

import { Photo } from './photo.model';
import { PhotoCollection } from './photo.collection';


@Injectable()
export class PhotosService extends ODataModelService<Photo, PhotoCollection> {
  static set: string = 'Photos';
  static model = Photo;
  static collection = PhotoCollection;
  
}