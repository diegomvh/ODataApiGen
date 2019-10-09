import { giphyRatingType } from './giphyratingtype.enum';

export interface teamFunSettings {
  allowGiphy: boolean;
  giphyContentRating: giphyRatingType;
  allowStickersAndMemes: boolean;
  allowCustomMemes: boolean
}
