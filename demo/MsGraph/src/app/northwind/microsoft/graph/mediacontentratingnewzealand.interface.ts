import { ratingNewZealandMoviesType } from './ratingnewzealandmoviestype.enum';
import { ratingNewZealandTelevisionType } from './ratingnewzealandtelevisiontype.enum';

export interface mediaContentRatingNewZealand {
  movieRating: ratingNewZealandMoviesType;
  tvRating: ratingNewZealandTelevisionType
}
