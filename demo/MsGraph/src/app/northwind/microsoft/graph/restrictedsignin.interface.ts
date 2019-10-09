import { signIn } from './signin.interface';

export interface restrictedSignIn extends signIn {
  targetTenantId: string
}
