

export const ISFLAGS_REGISTRYVALUETYPE = false;
export enum registryValueType {
  unknown = 0,
  binary = 1,
  dword = 2,
  dwordLittleEndian = 3,
  dwordBigEndian = 4,
  expandSz = 5,
  link = 6,
  multiSz = 7,
  none = 8,
  qword = 9,
  qwordlittleEndian = 10,
  sz = 11,
  unknownFutureValue = 127
}
