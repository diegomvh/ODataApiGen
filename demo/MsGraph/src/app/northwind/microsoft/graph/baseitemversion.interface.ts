import { identitySet } from './identityset.interface';
import { publicationFacet } from './publicationfacet.interface';
import { entity } from './entity.interface';

export interface baseItemVersion extends entity {
  lastModifiedBy: identitySet;
  lastModifiedDateTime: Date;
  publication: publicationFacet
}
