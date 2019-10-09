import { ratingCanadaMoviesType } from './ratingcanadamoviestype.enum';
import { ratingCanadaTelevisionType } from './ratingcanadatelevisiontype.enum';

export interface mediaContentRatingCanada {
  movieRating: ratingCanadaMoviesType;
  tvRating: ratingCanadaTelevisionType
}
