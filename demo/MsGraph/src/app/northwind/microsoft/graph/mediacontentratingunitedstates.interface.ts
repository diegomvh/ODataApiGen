import { ratingUnitedStatesMoviesType } from './ratingunitedstatesmoviestype.enum';
import { ratingUnitedStatesTelevisionType } from './ratingunitedstatestelevisiontype.enum';

export interface mediaContentRatingUnitedStates {
  movieRating: ratingUnitedStatesMoviesType;
  tvRating: ratingUnitedStatesTelevisionType
}
