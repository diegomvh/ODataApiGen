import { ratingJapanMoviesType } from './ratingjapanmoviestype.enum';
import { ratingJapanTelevisionType } from './ratingjapantelevisiontype.enum';

export interface mediaContentRatingJapan {
  movieRating: ratingJapanMoviesType;
  tvRating: ratingJapanTelevisionType
}
