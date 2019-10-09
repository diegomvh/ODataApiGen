import { entity } from './entity.interface';
import { directoryAudit } from './directoryaudit.interface';
import { signIn } from './signin.interface';
import { restrictedSignIn } from './restrictedsignin.interface';

export interface auditLogRoot extends entity {
  signIns?: signIn[];
  directoryAudits?: directoryAudit[];
  restrictedSignIns?: restrictedSignIn[]
}
