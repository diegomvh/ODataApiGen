import { ratingIrelandMoviesType } from './ratingirelandmoviestype.enum';
import { ratingIrelandTelevisionType } from './ratingirelandtelevisiontype.enum';

export interface mediaContentRatingIreland {
  movieRating: ratingIrelandMoviesType;
  tvRating: ratingIrelandTelevisionType
}
