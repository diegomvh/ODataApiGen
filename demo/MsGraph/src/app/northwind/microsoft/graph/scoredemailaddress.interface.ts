import { selectionLikelihoodInfo } from './selectionlikelihoodinfo.enum';

export interface scoredEmailAddress {
  address: string;
  relevanceScore: number;
  selectionLikelihood: selectionLikelihoodInfo;
  itemId: string
}
