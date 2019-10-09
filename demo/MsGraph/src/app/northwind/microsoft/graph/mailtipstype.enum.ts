

export const ISFLAGS_MAILTIPSTYPE = true;
export enum mailTipsType {
  automaticReplies = 1,
  mailboxFullStatus = 2,
  customMailTip = 4,
  externalMemberCount = 8,
  totalMemberCount = 16,
  maxMessageSize = 32,
  deliveryRestriction = 64,
  moderationStatus = 128,
  recipientScope = 256,
  recipientSuggestions = 512
}
