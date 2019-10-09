import { entity } from './entity.interface';
import { alert } from './alert.interface';
import { secureScoreControlProfile } from './securescorecontrolprofile.interface';
import { secureScore } from './securescore.interface';

export interface security extends entity {
  alerts?: alert[];
  secureScoreControlProfiles?: secureScoreControlProfile[];
  secureScores?: secureScore[]
}
