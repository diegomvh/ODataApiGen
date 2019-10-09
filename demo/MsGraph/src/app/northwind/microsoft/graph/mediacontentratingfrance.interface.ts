import { ratingFranceMoviesType } from './ratingfrancemoviestype.enum';
import { ratingFranceTelevisionType } from './ratingfrancetelevisiontype.enum';

export interface mediaContentRatingFrance {
  movieRating: ratingFranceMoviesType;
  tvRating: ratingFranceTelevisionType
}
