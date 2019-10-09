import { Json } from './json.interface';
import { imageInfo } from './imageinfo.interface';

export interface visualInfo {
  attribution: imageInfo;
  backgroundColor: string;
  description: string;
  displayText: string;
  content: Json
}
