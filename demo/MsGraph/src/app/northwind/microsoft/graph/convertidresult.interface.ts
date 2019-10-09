import { genericError } from './genericerror.interface';

export interface convertIdResult {
  sourceId: string;
  targetId: string;
  errorDetails: genericError
}
