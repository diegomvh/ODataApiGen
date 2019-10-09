import { registryHive } from './registryhive.enum';
import { registryOperation } from './registryoperation.enum';
import { registryValueType } from './registryvaluetype.enum';

export interface registryKeyState {
  hive: registryHive;
  key: string;
  oldKey: string;
  oldValueData: string;
  oldValueName: string;
  operation: registryOperation;
  processId: number;
  valueData: string;
  valueName: string;
  valueType: registryValueType
}
