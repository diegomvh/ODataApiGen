import { ratingGermanyMoviesType } from './ratinggermanymoviestype.enum';
import { ratingGermanyTelevisionType } from './ratinggermanytelevisiontype.enum';

export interface mediaContentRatingGermany {
  movieRating: ratingGermanyMoviesType;
  tvRating: ratingGermanyTelevisionType
}
