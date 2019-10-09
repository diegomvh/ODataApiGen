import { ratingAustraliaMoviesType } from './ratingaustraliamoviestype.enum';
import { ratingAustraliaTelevisionType } from './ratingaustraliatelevisiontype.enum';

export interface mediaContentRatingAustralia {
  movieRating: ratingAustraliaMoviesType;
  tvRating: ratingAustraliaTelevisionType
}
