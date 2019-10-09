import { resourceReference } from './resourcereference.interface';
import { insightIdentity } from './insightidentity.interface';

export interface sharingDetail {
  sharedBy: insightIdentity;
  sharedDateTime: Date;
  sharingSubject: string;
  sharingType: string;
  sharingReference: resourceReference
}
