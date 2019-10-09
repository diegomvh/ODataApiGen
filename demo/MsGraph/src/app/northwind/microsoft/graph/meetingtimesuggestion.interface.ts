import { freeBusyStatus } from './freebusystatus.enum';
import { location } from './location.interface';
import { attendeeAvailability } from './attendeeavailability.interface';
import { timeSlot } from './timeslot.interface';

export interface meetingTimeSuggestion {
  confidence: number;
  order: number;
  organizerAvailability: freeBusyStatus;
  attendeeAvailability: attendeeAvailability[];
  locations: location[];
  suggestionReason: string;
  meetingTimeSlot: timeSlot
}
