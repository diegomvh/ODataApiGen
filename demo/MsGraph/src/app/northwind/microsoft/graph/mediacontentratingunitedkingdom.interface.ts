import { ratingUnitedKingdomMoviesType } from './ratingunitedkingdommoviestype.enum';
import { ratingUnitedKingdomTelevisionType } from './ratingunitedkingdomtelevisiontype.enum';

export interface mediaContentRatingUnitedKingdom {
  movieRating: ratingUnitedKingdomMoviesType;
  tvRating: ratingUnitedKingdomTelevisionType
}
