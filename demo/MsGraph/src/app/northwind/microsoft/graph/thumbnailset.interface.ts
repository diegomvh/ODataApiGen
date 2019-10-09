import { thumbnail } from './thumbnail.interface';
import { entity } from './entity.interface';

export interface thumbnailSet extends entity {
  large: thumbnail;
  medium: thumbnail;
  small: thumbnail;
  source: thumbnail
}
