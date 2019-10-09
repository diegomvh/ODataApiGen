import { meetingTimeSuggestion } from './meetingtimesuggestion.interface';

export interface meetingTimeSuggestionsResult {
  meetingTimeSuggestions: meetingTimeSuggestion[];
  emptySuggestionsReason: string
}
