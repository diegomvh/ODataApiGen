import { ODataConfig } from 'angular-odata';

import { riskLevel } from './microsoft/graph/risklevel.enum';
import { appliedConditionalAccessPolicyResult } from './microsoft/graph/appliedconditionalaccesspolicyresult.enum';
import { conditionalAccessStatus } from './microsoft/graph/conditionalaccessstatus.enum';
import { groupType } from './microsoft/graph/grouptype.enum';
import { operationResult } from './microsoft/graph/operationresult.enum';
import { riskState } from './microsoft/graph/riskstate.enum';
import { riskDetail } from './microsoft/graph/riskdetail.enum';
import { riskEventType } from './microsoft/graph/riskeventtype.enum';
import { educationUserRole } from './microsoft/graph/educationuserrole.enum';
import { educationExternalSource } from './microsoft/graph/educationexternalsource.enum';
import { educationGender } from './microsoft/graph/educationgender.enum';
import { attendeeType } from './microsoft/graph/attendeetype.enum';
import { activityDomain } from './microsoft/graph/activitydomain.enum';
import { freeBusyStatus } from './microsoft/graph/freebusystatus.enum';
import { locationType } from './microsoft/graph/locationtype.enum';
import { physicalAddressType } from './microsoft/graph/physicaladdresstype.enum';
import { locationUniqueIdType } from './microsoft/graph/locationuniqueidtype.enum';
import { dayOfWeek } from './microsoft/graph/dayofweek.enum';
import { automaticRepliesStatus } from './microsoft/graph/automaticrepliesstatus.enum';
import { externalAudienceScope } from './microsoft/graph/externalaudiencescope.enum';
import { mailTipsType } from './microsoft/graph/mailtipstype.enum';
import { recipientScopeType } from './microsoft/graph/recipientscopetype.enum';
import { exchangeIdFormat } from './microsoft/graph/exchangeidformat.enum';
import { timeZoneStandard } from './microsoft/graph/timezonestandard.enum';
import { bodyType } from './microsoft/graph/bodytype.enum';
import { importance } from './microsoft/graph/importance.enum';
import { inferenceClassificationType } from './microsoft/graph/inferenceclassificationtype.enum';
import { followupFlagStatus } from './microsoft/graph/followupflagstatus.enum';
import { meetingMessageType } from './microsoft/graph/meetingmessagetype.enum';
import { calendarColor } from './microsoft/graph/calendarcolor.enum';
import { responseType } from './microsoft/graph/responsetype.enum';
import { sensitivity } from './microsoft/graph/sensitivity.enum';
import { recurrencePatternType } from './microsoft/graph/recurrencepatterntype.enum';
import { weekIndex } from './microsoft/graph/weekindex.enum';
import { recurrenceRangeType } from './microsoft/graph/recurrencerangetype.enum';
import { eventType } from './microsoft/graph/eventtype.enum';
import { selectionLikelihoodInfo } from './microsoft/graph/selectionlikelihoodinfo.enum';
import { phoneType } from './microsoft/graph/phonetype.enum';
import { websiteType } from './microsoft/graph/websitetype.enum';
import { categoryColor } from './microsoft/graph/categorycolor.enum';
import { messageActionFlag } from './microsoft/graph/messageactionflag.enum';
import { installIntent } from './microsoft/graph/installintent.enum';
import { mobileAppPublishingState } from './microsoft/graph/mobileapppublishingstate.enum';
import { windowsArchitecture } from './microsoft/graph/windowsarchitecture.enum';
import { managedAppAvailability } from './microsoft/graph/managedappavailability.enum';
import { mobileAppContentFileUploadState } from './microsoft/graph/mobileappcontentfileuploadstate.enum';
import { windowsDeviceType } from './microsoft/graph/windowsdevicetype.enum';
import { vppTokenAccountType } from './microsoft/graph/vpptokenaccounttype.enum';
import { microsoftStoreForBusinessLicenseType } from './microsoft/graph/microsoftstoreforbusinesslicensetype.enum';
import { complianceStatus } from './microsoft/graph/compliancestatus.enum';
import { mdmAppConfigKeyType } from './microsoft/graph/mdmappconfigkeytype.enum';
import { installState } from './microsoft/graph/installstate.enum';
import { windows10EditionType } from './microsoft/graph/windows10editiontype.enum';
import { appListType } from './microsoft/graph/applisttype.enum';
import { androidRequiredPasswordType } from './microsoft/graph/androidrequiredpasswordtype.enum';
import { webBrowserCookieSettings } from './microsoft/graph/webbrowsercookiesettings.enum';
import { androidWorkProfileRequiredPasswordType } from './microsoft/graph/androidworkprofilerequiredpasswordtype.enum';
import { androidWorkProfileCrossProfileDataSharingType } from './microsoft/graph/androidworkprofilecrossprofiledatasharingtype.enum';
import { androidWorkProfileDefaultAppPermissionPolicyType } from './microsoft/graph/androidworkprofiledefaultapppermissionpolicytype.enum';
import { ratingAustraliaMoviesType } from './microsoft/graph/ratingaustraliamoviestype.enum';
import { ratingAustraliaTelevisionType } from './microsoft/graph/ratingaustraliatelevisiontype.enum';
import { ratingCanadaMoviesType } from './microsoft/graph/ratingcanadamoviestype.enum';
import { ratingCanadaTelevisionType } from './microsoft/graph/ratingcanadatelevisiontype.enum';
import { ratingFranceMoviesType } from './microsoft/graph/ratingfrancemoviestype.enum';
import { ratingFranceTelevisionType } from './microsoft/graph/ratingfrancetelevisiontype.enum';
import { ratingGermanyMoviesType } from './microsoft/graph/ratinggermanymoviestype.enum';
import { ratingGermanyTelevisionType } from './microsoft/graph/ratinggermanytelevisiontype.enum';
import { ratingIrelandMoviesType } from './microsoft/graph/ratingirelandmoviestype.enum';
import { ratingIrelandTelevisionType } from './microsoft/graph/ratingirelandtelevisiontype.enum';
import { ratingJapanMoviesType } from './microsoft/graph/ratingjapanmoviestype.enum';
import { ratingJapanTelevisionType } from './microsoft/graph/ratingjapantelevisiontype.enum';
import { ratingNewZealandMoviesType } from './microsoft/graph/ratingnewzealandmoviestype.enum';
import { ratingNewZealandTelevisionType } from './microsoft/graph/ratingnewzealandtelevisiontype.enum';
import { ratingUnitedKingdomMoviesType } from './microsoft/graph/ratingunitedkingdommoviestype.enum';
import { ratingUnitedKingdomTelevisionType } from './microsoft/graph/ratingunitedkingdomtelevisiontype.enum';
import { ratingUnitedStatesMoviesType } from './microsoft/graph/ratingunitedstatesmoviestype.enum';
import { ratingUnitedStatesTelevisionType } from './microsoft/graph/ratingunitedstatestelevisiontype.enum';
import { ratingAppsType } from './microsoft/graph/ratingappstype.enum';
import { requiredPasswordType } from './microsoft/graph/requiredpasswordtype.enum';
import { iosNotificationAlertType } from './microsoft/graph/iosnotificationalerttype.enum';
import { stateManagementSetting } from './microsoft/graph/statemanagementsetting.enum';
import { firewallPreSharedKeyEncodingMethodType } from './microsoft/graph/firewallpresharedkeyencodingmethodtype.enum';
import { firewallCertificateRevocationListCheckMethodType } from './microsoft/graph/firewallcertificaterevocationlistcheckmethodtype.enum';
import { firewallPacketQueueingMethodType } from './microsoft/graph/firewallpacketqueueingmethodtype.enum';
import { appLockerApplicationControlType } from './microsoft/graph/applockerapplicationcontroltype.enum';
import { applicationGuardBlockFileTransferType } from './microsoft/graph/applicationguardblockfiletransfertype.enum';
import { applicationGuardBlockClipboardSharingType } from './microsoft/graph/applicationguardblockclipboardsharingtype.enum';
import { bitLockerEncryptionMethod } from './microsoft/graph/bitlockerencryptionmethod.enum';
import { diagnosticDataSubmissionMode } from './microsoft/graph/diagnosticdatasubmissionmode.enum';
import { edgeCookiePolicy } from './microsoft/graph/edgecookiepolicy.enum';
import { visibilitySetting } from './microsoft/graph/visibilitysetting.enum';
import { defenderThreatAction } from './microsoft/graph/defenderthreataction.enum';
import { weeklySchedule } from './microsoft/graph/weeklyschedule.enum';
import { defenderMonitorFileActivity } from './microsoft/graph/defendermonitorfileactivity.enum';
import { defenderPromptForSampleSubmission } from './microsoft/graph/defenderpromptforsamplesubmission.enum';
import { defenderScanType } from './microsoft/graph/defenderscantype.enum';
import { defenderCloudBlockLevelType } from './microsoft/graph/defendercloudblockleveltype.enum';
import { windowsStartMenuAppListVisibilityType } from './microsoft/graph/windowsstartmenuapplistvisibilitytype.enum';
import { windowsStartMenuModeType } from './microsoft/graph/windowsstartmenumodetype.enum';
import { windowsSpotlightEnablementSettings } from './microsoft/graph/windowsspotlightenablementsettings.enum';
import { automaticUpdateMode } from './microsoft/graph/automaticupdatemode.enum';
import { safeSearchFilterType } from './microsoft/graph/safesearchfiltertype.enum';
import { edgeSearchEngineType } from './microsoft/graph/edgesearchenginetype.enum';
import { prereleaseFeatures } from './microsoft/graph/prereleasefeatures.enum';
import { editionUpgradeLicenseType } from './microsoft/graph/editionupgradelicensetype.enum';
import { windowsDeliveryOptimizationMode } from './microsoft/graph/windowsdeliveryoptimizationmode.enum';
import { sharedPCAccountDeletionPolicyType } from './microsoft/graph/sharedpcaccountdeletionpolicytype.enum';
import { sharedPCAllowedAccountType } from './microsoft/graph/sharedpcallowedaccounttype.enum';
import { windowsUpdateType } from './microsoft/graph/windowsupdatetype.enum';
import { internetSiteSecurityLevel } from './microsoft/graph/internetsitesecuritylevel.enum';
import { siteSecurityLevel } from './microsoft/graph/sitesecuritylevel.enum';
import { windowsUserAccountControlSettings } from './microsoft/graph/windowsuseraccountcontrolsettings.enum';
import { miracastChannel } from './microsoft/graph/miracastchannel.enum';
import { welcomeScreenMeetingInformation } from './microsoft/graph/welcomescreenmeetinginformation.enum';
import { deviceComplianceActionType } from './microsoft/graph/devicecomplianceactiontype.enum';
import { deviceThreatProtectionLevel } from './microsoft/graph/devicethreatprotectionlevel.enum';
import { policyPlatformType } from './microsoft/graph/policyplatformtype.enum';
import { iosUpdatesInstallStatus } from './microsoft/graph/iosupdatesinstallstatus.enum';
import { deviceManagementExchangeConnectorSyncType } from './microsoft/graph/devicemanagementexchangeconnectorsynctype.enum';
import { mdmAuthority } from './microsoft/graph/mdmauthority.enum';
import { windowsHelloForBusinessPinUsage } from './microsoft/graph/windowshelloforbusinesspinusage.enum';
import { enablement } from './microsoft/graph/enablement.enum';
import { vppTokenState } from './microsoft/graph/vpptokenstate.enum';
import { vppTokenSyncStatus } from './microsoft/graph/vpptokensyncstatus.enum';
import { deviceManagementExchangeConnectorStatus } from './microsoft/graph/devicemanagementexchangeconnectorstatus.enum';
import { deviceManagementExchangeConnectorType } from './microsoft/graph/devicemanagementexchangeconnectortype.enum';
import { mobileThreatPartnerTenantState } from './microsoft/graph/mobilethreatpartnertenantstate.enum';
import { deviceManagementPartnerTenantState } from './microsoft/graph/devicemanagementpartnertenantstate.enum';
import { deviceManagementPartnerAppType } from './microsoft/graph/devicemanagementpartnerapptype.enum';
import { actionState } from './microsoft/graph/actionstate.enum';
import { managedDeviceOwnerType } from './microsoft/graph/manageddeviceownertype.enum';
import { complianceState } from './microsoft/graph/compliancestate.enum';
import { managementAgentType } from './microsoft/graph/managementagenttype.enum';
import { deviceEnrollmentType } from './microsoft/graph/deviceenrollmenttype.enum';
import { deviceRegistrationState } from './microsoft/graph/deviceregistrationstate.enum';
import { deviceManagementExchangeAccessState } from './microsoft/graph/devicemanagementexchangeaccessstate.enum';
import { deviceManagementExchangeAccessStateReason } from './microsoft/graph/devicemanagementexchangeaccessstatereason.enum';
import { managedDevicePartnerReportedHealthState } from './microsoft/graph/manageddevicepartnerreportedhealthstate.enum';
import { deviceManagementSubscriptionState } from './microsoft/graph/devicemanagementsubscriptionstate.enum';
import { managedAppDataStorageLocation } from './microsoft/graph/managedappdatastoragelocation.enum';
import { managedAppDataTransferLevel } from './microsoft/graph/managedappdatatransferlevel.enum';
import { managedAppClipboardSharingLevel } from './microsoft/graph/managedappclipboardsharinglevel.enum';
import { managedAppPinCharacterSet } from './microsoft/graph/managedapppincharacterset.enum';
import { managedAppDataEncryptionType } from './microsoft/graph/managedappdataencryptiontype.enum';
import { windowsInformationProtectionEnforcementLevel } from './microsoft/graph/windowsinformationprotectionenforcementlevel.enum';
import { windowsInformationProtectionPinCharacterRequirements } from './microsoft/graph/windowsinformationprotectionpincharacterrequirements.enum';
import { managedAppFlaggedReason } from './microsoft/graph/managedappflaggedreason.enum';
import { notificationTemplateBrandingOptions } from './microsoft/graph/notificationtemplatebrandingoptions.enum';
import { remoteAssistanceOnboardingStatus } from './microsoft/graph/remoteassistanceonboardingstatus.enum';
import { deviceEnrollmentFailureReason } from './microsoft/graph/deviceenrollmentfailurereason.enum';
import { applicationType } from './microsoft/graph/applicationtype.enum';
import { plannerPreviewType } from './microsoft/graph/plannerpreviewtype.enum';
import { operationStatus } from './microsoft/graph/operationstatus.enum';
import { onenotePatchInsertPosition } from './microsoft/graph/onenotepatchinsertposition.enum';
import { onenotePatchActionType } from './microsoft/graph/onenotepatchactiontype.enum';
import { onenoteSourceService } from './microsoft/graph/onenotesourceservice.enum';
import { onenoteUserRole } from './microsoft/graph/onenoteuserrole.enum';
import { dataPolicyOperationStatus } from './microsoft/graph/datapolicyoperationstatus.enum';
import { status } from './microsoft/graph/status.enum';
import { alertFeedback } from './microsoft/graph/alertfeedback.enum';
import { alertSeverity } from './microsoft/graph/alertseverity.enum';
import { alertStatus } from './microsoft/graph/alertstatus.enum';
import { connectionDirection } from './microsoft/graph/connectiondirection.enum';
import { connectionStatus } from './microsoft/graph/connectionstatus.enum';
import { emailRole } from './microsoft/graph/emailrole.enum';
import { fileHashType } from './microsoft/graph/filehashtype.enum';
import { logonType } from './microsoft/graph/logontype.enum';
import { processIntegrityLevel } from './microsoft/graph/processintegritylevel.enum';
import { registryHive } from './microsoft/graph/registryhive.enum';
import { registryOperation } from './microsoft/graph/registryoperation.enum';
import { registryValueType } from './microsoft/graph/registryvaluetype.enum';
import { securityNetworkProtocol } from './microsoft/graph/securitynetworkprotocol.enum';
import { userAccountSecurityType } from './microsoft/graph/useraccountsecuritytype.enum';
import { callDirection } from './microsoft/graph/calldirection.enum';
import { callState } from './microsoft/graph/callstate.enum';
import { changeType } from './microsoft/graph/changetype.enum';
import { mediaDirection } from './microsoft/graph/mediadirection.enum';
import { mediaState } from './microsoft/graph/mediastate.enum';
import { modality } from './microsoft/graph/modality.enum';
import { rejectReason } from './microsoft/graph/rejectreason.enum';
import { screenSharingRole } from './microsoft/graph/screensharingrole.enum';
import { tone } from './microsoft/graph/tone.enum';
import { teamVisibilityType } from './microsoft/graph/teamvisibilitytype.enum';
import { clonableTeamParts } from './microsoft/graph/clonableteamparts.enum';
import { giphyRatingType } from './microsoft/graph/giphyratingtype.enum';
import { teamsAsyncOperationType } from './microsoft/graph/teamsasyncoperationtype.enum';
import { teamsAsyncOperationStatus } from './microsoft/graph/teamsasyncoperationstatus.enum';
import { teamsAppDistributionMethod } from './microsoft/graph/teamsappdistributionmethod.enum';
import { auditActivityInitiator } from './microsoft/graph/auditactivityinitiator.interface';
import { userIdentity } from './microsoft/graph/useridentity.interface';
import { appIdentity } from './microsoft/graph/appidentity.interface';
import { targetResource } from './microsoft/graph/targetresource.interface';
import { modifiedProperty } from './microsoft/graph/modifiedproperty.interface';
import { keyValue } from './microsoft/graph/keyvalue.interface';
import { signInStatus } from './microsoft/graph/signinstatus.interface';
import { deviceDetail } from './microsoft/graph/devicedetail.interface';
import { signInLocation } from './microsoft/graph/signinlocation.interface';
import { geoCoordinates } from './microsoft/graph/geocoordinates.interface';
import { appliedConditionalAccessPolicy } from './microsoft/graph/appliedconditionalaccesspolicy.interface';
import { invitedUserMessageInfo } from './microsoft/graph/invitedusermessageinfo.interface';
import { recipient } from './microsoft/graph/recipient.interface';
import { emailAddress } from './microsoft/graph/emailaddress.interface';
import { assignedLicense } from './microsoft/graph/assignedlicense.interface';
import { assignedPlan } from './microsoft/graph/assignedplan.interface';
import { licenseAssignmentState } from './microsoft/graph/licenseassignmentstate.interface';
import { onPremisesExtensionAttributes } from './microsoft/graph/onpremisesextensionattributes.interface';
import { onPremisesProvisioningError } from './microsoft/graph/onpremisesprovisioningerror.interface';
import { passwordProfile } from './microsoft/graph/passwordprofile.interface';
import { provisionedPlan } from './microsoft/graph/provisionedplan.interface';
import { mailboxSettings } from './microsoft/graph/mailboxsettings.interface';
import { automaticRepliesSetting } from './microsoft/graph/automaticrepliessetting.interface';
import { dateTimeTimeZone } from './microsoft/graph/datetimetimezone.interface';
import { localeInfo } from './microsoft/graph/localeinfo.interface';
import { workingHours } from './microsoft/graph/workinghours.interface';
import { timeZoneBase } from './microsoft/graph/timezonebase.interface';
import { alternativeSecurityId } from './microsoft/graph/alternativesecurityid.interface';
import { domainState } from './microsoft/graph/domainstate.interface';
import { servicePlanInfo } from './microsoft/graph/serviceplaninfo.interface';
import { licenseProcessingState } from './microsoft/graph/licenseprocessingstate.interface';
import { licenseUnitsDetail } from './microsoft/graph/licenseunitsdetail.interface';
import { privacyProfile } from './microsoft/graph/privacyprofile.interface';
import { verifiedDomain } from './microsoft/graph/verifieddomain.interface';
import { settingValue } from './microsoft/graph/settingvalue.interface';
import { settingTemplateValue } from './microsoft/graph/settingtemplatevalue.interface';
import { ComplexExtensionValue } from './microsoft/graph/complexextensionvalue.interface';
import { physicalAddress } from './microsoft/graph/physicaladdress.interface';
import { identity } from './microsoft/graph/identity.interface';
import { identitySet } from './microsoft/graph/identityset.interface';
import { educationStudent } from './microsoft/graph/educationstudent.interface';
import { educationTeacher } from './microsoft/graph/educationteacher.interface';
import { educationTerm } from './microsoft/graph/educationterm.interface';
import { root } from './microsoft/graph/root.interface';
import { sharepointIds } from './microsoft/graph/sharepointids.interface';
import { siteCollection } from './microsoft/graph/sitecollection.interface';
import { listInfo } from './microsoft/graph/listinfo.interface';
import { systemFacet } from './microsoft/graph/systemfacet.interface';
import { quota } from './microsoft/graph/quota.interface';
import { audio } from './microsoft/graph/audio.interface';
import { deleted } from './microsoft/graph/deleted.interface';
import { file } from './microsoft/graph/file.interface';
import { hashes } from './microsoft/graph/hashes.interface';
import { fileSystemInfo } from './microsoft/graph/filesysteminfo.interface';
import { folder } from './microsoft/graph/folder.interface';
import { folderView } from './microsoft/graph/folderview.interface';
import { image } from './microsoft/graph/image.interface';
import { package } from './microsoft/graph/package.interface';
import { photo } from './microsoft/graph/photo.interface';
import { publicationFacet } from './microsoft/graph/publicationfacet.interface';
import { remoteItem } from './microsoft/graph/remoteitem.interface';
import { itemReference } from './microsoft/graph/itemreference.interface';
import { shared } from './microsoft/graph/shared.interface';
import { specialFolder } from './microsoft/graph/specialfolder.interface';
import { searchResult } from './microsoft/graph/searchresult.interface';
import { video } from './microsoft/graph/video.interface';
import { workbookSessionInfo } from './microsoft/graph/workbooksessioninfo.interface';
import { Json } from './microsoft/graph/json.interface';
import { workbookFilterCriteria } from './microsoft/graph/workbookfiltercriteria.interface';
import { workbookIcon } from './microsoft/graph/workbookicon.interface';
import { workbookSortField } from './microsoft/graph/workbooksortfield.interface';
import { workbookWorksheetProtectionOptions } from './microsoft/graph/workbookworksheetprotectionoptions.interface';
import { workbookFilterDatetime } from './microsoft/graph/workbookfilterdatetime.interface';
import { workbookRangeReference } from './microsoft/graph/workbookrangereference.interface';
import { attendeeBase } from './microsoft/graph/attendeebase.interface';
import { locationConstraint } from './microsoft/graph/locationconstraint.interface';
import { location } from './microsoft/graph/location.interface';
import { outlookGeoCoordinates } from './microsoft/graph/outlookgeocoordinates.interface';
import { locationConstraintItem } from './microsoft/graph/locationconstraintitem.interface';
import { meetingTimeSuggestionsResult } from './microsoft/graph/meetingtimesuggestionsresult.interface';
import { meetingTimeSuggestion } from './microsoft/graph/meetingtimesuggestion.interface';
import { attendeeAvailability } from './microsoft/graph/attendeeavailability.interface';
import { timeSlot } from './microsoft/graph/timeslot.interface';
import { timeConstraint } from './microsoft/graph/timeconstraint.interface';
import { customTimeZone } from './microsoft/graph/customtimezone.interface';
import { standardTimeZoneOffset } from './microsoft/graph/standardtimezoneoffset.interface';
import { daylightTimeZoneOffset } from './microsoft/graph/daylighttimezoneoffset.interface';
import { reminder } from './microsoft/graph/reminder.interface';
import { mailTips } from './microsoft/graph/mailtips.interface';
import { automaticRepliesMailTips } from './microsoft/graph/automaticrepliesmailtips.interface';
import { mailTipsError } from './microsoft/graph/mailtipserror.interface';
import { convertIdResult } from './microsoft/graph/convertidresult.interface';
import { genericError } from './microsoft/graph/genericerror.interface';
import { timeZoneInformation } from './microsoft/graph/timezoneinformation.interface';
import { internetMessageHeader } from './microsoft/graph/internetmessageheader.interface';
import { itemBody } from './microsoft/graph/itembody.interface';
import { followupFlag } from './microsoft/graph/followupflag.interface';
import { scheduleInformation } from './microsoft/graph/scheduleinformation.interface';
import { scheduleItem } from './microsoft/graph/scheduleitem.interface';
import { freeBusyError } from './microsoft/graph/freebusyerror.interface';
import { responseStatus } from './microsoft/graph/responsestatus.interface';
import { patternedRecurrence } from './microsoft/graph/patternedrecurrence.interface';
import { recurrencePattern } from './microsoft/graph/recurrencepattern.interface';
import { recurrenceRange } from './microsoft/graph/recurrencerange.interface';
import { attendee } from './microsoft/graph/attendee.interface';
import { scoredEmailAddress } from './microsoft/graph/scoredemailaddress.interface';
import { phone } from './microsoft/graph/phone.interface';
import { website } from './microsoft/graph/website.interface';
import { personType } from './microsoft/graph/persontype.interface';
import { messageRulePredicates } from './microsoft/graph/messagerulepredicates.interface';
import { sizeRange } from './microsoft/graph/sizerange.interface';
import { messageRuleActions } from './microsoft/graph/messageruleactions.interface';
import { booleanColumn } from './microsoft/graph/booleancolumn.interface';
import { calculatedColumn } from './microsoft/graph/calculatedcolumn.interface';
import { choiceColumn } from './microsoft/graph/choicecolumn.interface';
import { currencyColumn } from './microsoft/graph/currencycolumn.interface';
import { dateTimeColumn } from './microsoft/graph/datetimecolumn.interface';
import { defaultColumnValue } from './microsoft/graph/defaultcolumnvalue.interface';
import { lookupColumn } from './microsoft/graph/lookupcolumn.interface';
import { numberColumn } from './microsoft/graph/numbercolumn.interface';
import { personOrGroupColumn } from './microsoft/graph/personorgroupcolumn.interface';
import { textColumn } from './microsoft/graph/textcolumn.interface';
import { contentTypeOrder } from './microsoft/graph/contenttypeorder.interface';
import { accessAction } from './microsoft/graph/accessaction.interface';
import { itemActionStat } from './microsoft/graph/itemactionstat.interface';
import { incompleteData } from './microsoft/graph/incompletedata.interface';
import { contentTypeInfo } from './microsoft/graph/contenttypeinfo.interface';
import { sharingInvitation } from './microsoft/graph/sharinginvitation.interface';
import { sharingLink } from './microsoft/graph/sharinglink.interface';
import { thumbnail } from './microsoft/graph/thumbnail.interface';
import { driveItemUploadableProperties } from './microsoft/graph/driveitemuploadableproperties.interface';
import { driveRecipient } from './microsoft/graph/driverecipient.interface';
import { itemPreviewInfo } from './microsoft/graph/itempreviewinfo.interface';
import { uploadSession } from './microsoft/graph/uploadsession.interface';
import { extensionSchemaProperty } from './microsoft/graph/extensionschemaproperty.interface';
import { deviceAndAppManagementAssignmentTarget } from './microsoft/graph/deviceandappmanagementassignmenttarget.interface';
import { mobileAppAssignmentSettings } from './microsoft/graph/mobileappassignmentsettings.interface';
import { mimeContent } from './microsoft/graph/mimecontent.interface';
import { fileEncryptionInfo } from './microsoft/graph/fileencryptioninfo.interface';
import { allLicensedUsersAssignmentTarget } from './microsoft/graph/alllicensedusersassignmenttarget.interface';
import { groupAssignmentTarget } from './microsoft/graph/groupassignmenttarget.interface';
import { exclusionGroupAssignmentTarget } from './microsoft/graph/exclusiongroupassignmenttarget.interface';
import { allDevicesAssignmentTarget } from './microsoft/graph/alldevicesassignmenttarget.interface';
import { iosLobAppAssignmentSettings } from './microsoft/graph/ioslobappassignmentsettings.interface';
import { iosStoreAppAssignmentSettings } from './microsoft/graph/iosstoreappassignmentsettings.interface';
import { iosVppAppAssignmentSettings } from './microsoft/graph/iosvppappassignmentsettings.interface';
import { microsoftStoreForBusinessAppAssignmentSettings } from './microsoft/graph/microsoftstoreforbusinessappassignmentsettings.interface';
import { androidMinimumOperatingSystem } from './microsoft/graph/androidminimumoperatingsystem.interface';
import { iosDeviceType } from './microsoft/graph/iosdevicetype.interface';
import { iosMinimumOperatingSystem } from './microsoft/graph/iosminimumoperatingsystem.interface';
import { windowsMinimumOperatingSystem } from './microsoft/graph/windowsminimumoperatingsystem.interface';
import { vppLicensingType } from './microsoft/graph/vpplicensingtype.interface';
import { appConfigurationSettingItem } from './microsoft/graph/appconfigurationsettingitem.interface';
import { deviceManagementSettings } from './microsoft/graph/devicemanagementsettings.interface';
import { intuneBrand } from './microsoft/graph/intunebrand.interface';
import { rgbColor } from './microsoft/graph/rgbcolor.interface';
import { report } from './microsoft/graph/report.interface';
import { appListItem } from './microsoft/graph/applistitem.interface';
import { omaSetting } from './microsoft/graph/omasetting.interface';
import { omaSettingInteger } from './microsoft/graph/omasettinginteger.interface';
import { omaSettingFloatingPoint } from './microsoft/graph/omasettingfloatingpoint.interface';
import { omaSettingString } from './microsoft/graph/omasettingstring.interface';
import { omaSettingDateTime } from './microsoft/graph/omasettingdatetime.interface';
import { omaSettingStringXml } from './microsoft/graph/omasettingstringxml.interface';
import { omaSettingBoolean } from './microsoft/graph/omasettingboolean.interface';
import { omaSettingBase64 } from './microsoft/graph/omasettingbase64.interface';
import { mediaContentRatingAustralia } from './microsoft/graph/mediacontentratingaustralia.interface';
import { mediaContentRatingCanada } from './microsoft/graph/mediacontentratingcanada.interface';
import { mediaContentRatingFrance } from './microsoft/graph/mediacontentratingfrance.interface';
import { mediaContentRatingGermany } from './microsoft/graph/mediacontentratinggermany.interface';
import { mediaContentRatingIreland } from './microsoft/graph/mediacontentratingireland.interface';
import { mediaContentRatingJapan } from './microsoft/graph/mediacontentratingjapan.interface';
import { mediaContentRatingNewZealand } from './microsoft/graph/mediacontentratingnewzealand.interface';
import { mediaContentRatingUnitedKingdom } from './microsoft/graph/mediacontentratingunitedkingdom.interface';
import { mediaContentRatingUnitedStates } from './microsoft/graph/mediacontentratingunitedstates.interface';
import { iosNetworkUsageRule } from './microsoft/graph/iosnetworkusagerule.interface';
import { iosHomeScreenItem } from './microsoft/graph/ioshomescreenitem.interface';
import { iosHomeScreenPage } from './microsoft/graph/ioshomescreenpage.interface';
import { iosNotificationSettings } from './microsoft/graph/iosnotificationsettings.interface';
import { iosHomeScreenFolder } from './microsoft/graph/ioshomescreenfolder.interface';
import { iosHomeScreenFolderPage } from './microsoft/graph/ioshomescreenfolderpage.interface';
import { iosHomeScreenApp } from './microsoft/graph/ioshomescreenapp.interface';
import { windowsFirewallNetworkProfile } from './microsoft/graph/windowsfirewallnetworkprofile.interface';
import { bitLockerRemovableDrivePolicy } from './microsoft/graph/bitlockerremovabledrivepolicy.interface';
import { defenderDetectedMalwareActions } from './microsoft/graph/defenderdetectedmalwareactions.interface';
import { windows10NetworkProxyServer } from './microsoft/graph/windows10networkproxyserver.interface';
import { edgeSearchEngineBase } from './microsoft/graph/edgesearchenginebase.interface';
import { edgeSearchEngineCustom } from './microsoft/graph/edgesearchenginecustom.interface';
import { edgeSearchEngine } from './microsoft/graph/edgesearchengine.interface';
import { sharedPCAccountManagerPolicy } from './microsoft/graph/sharedpcaccountmanagerpolicy.interface';
import { windowsUpdateInstallScheduleType } from './microsoft/graph/windowsupdateinstallscheduletype.interface';
import { windowsUpdateScheduledInstall } from './microsoft/graph/windowsupdatescheduledinstall.interface';
import { windowsUpdateActiveHoursInstall } from './microsoft/graph/windowsupdateactivehoursinstall.interface';
import { deviceActionResult } from './microsoft/graph/deviceactionresult.interface';
import { configurationManagerClientEnabledFeatures } from './microsoft/graph/configurationmanagerclientenabledfeatures.interface';
import { deviceHealthAttestationState } from './microsoft/graph/devicehealthattestationstate.interface';
import { deviceConfigurationSettingState } from './microsoft/graph/deviceconfigurationsettingstate.interface';
import { settingSource } from './microsoft/graph/settingsource.interface';
import { deviceCompliancePolicySettingState } from './microsoft/graph/devicecompliancepolicysettingstate.interface';
import { deviceEnrollmentPlatformRestriction } from './microsoft/graph/deviceenrollmentplatformrestriction.interface';
import { updateWindowsDeviceAccountActionParameter } from './microsoft/graph/updatewindowsdeviceaccountactionparameter.interface';
import { windowsDeviceAccount } from './microsoft/graph/windowsdeviceaccount.interface';
import { windowsDefenderScanActionResult } from './microsoft/graph/windowsdefenderscanactionresult.interface';
import { deleteUserFromSharedAppleDeviceActionResult } from './microsoft/graph/deleteuserfromsharedappledeviceactionresult.interface';
import { deviceGeoLocation } from './microsoft/graph/devicegeolocation.interface';
import { locateDeviceActionResult } from './microsoft/graph/locatedeviceactionresult.interface';
import { remoteLockActionResult } from './microsoft/graph/remotelockactionresult.interface';
import { resetPasscodeActionResult } from './microsoft/graph/resetpasscodeactionresult.interface';
import { deviceOperatingSystemSummary } from './microsoft/graph/deviceoperatingsystemsummary.interface';
import { deviceExchangeAccessStateSummary } from './microsoft/graph/deviceexchangeaccessstatesummary.interface';
import { windowsDeviceADAccount } from './microsoft/graph/windowsdeviceadaccount.interface';
import { windowsDeviceAzureADAccount } from './microsoft/graph/windowsdeviceazureadaccount.interface';
import { mobileAppIdentifier } from './microsoft/graph/mobileappidentifier.interface';
import { managedAppDiagnosticStatus } from './microsoft/graph/managedappdiagnosticstatus.interface';
import { keyValuePair } from './microsoft/graph/keyvaluepair.interface';
import { windowsInformationProtectionResourceCollection } from './microsoft/graph/windowsinformationprotectionresourcecollection.interface';
import { windowsInformationProtectionDataRecoveryCertificate } from './microsoft/graph/windowsinformationprotectiondatarecoverycertificate.interface';
import { windowsInformationProtectionApp } from './microsoft/graph/windowsinformationprotectionapp.interface';
import { windowsInformationProtectionProxiedDomainCollection } from './microsoft/graph/windowsinformationprotectionproxieddomaincollection.interface';
import { proxiedDomain } from './microsoft/graph/proxieddomain.interface';
import { windowsInformationProtectionIPRangeCollection } from './microsoft/graph/windowsinformationprotectioniprangecollection.interface';
import { ipRange } from './microsoft/graph/iprange.interface';
import { androidMobileAppIdentifier } from './microsoft/graph/androidmobileappidentifier.interface';
import { iosMobileAppIdentifier } from './microsoft/graph/iosmobileappidentifier.interface';
import { managedAppPolicyDeploymentSummaryPerApp } from './microsoft/graph/managedapppolicydeploymentsummaryperapp.interface';
import { windowsInformationProtectionStoreApp } from './microsoft/graph/windowsinformationprotectionstoreapp.interface';
import { windowsInformationProtectionDesktopApp } from './microsoft/graph/windowsinformationprotectiondesktopapp.interface';
import { iPv6Range } from './microsoft/graph/ipv6range.interface';
import { iPv4Range } from './microsoft/graph/ipv4range.interface';
import { rolePermission } from './microsoft/graph/rolepermission.interface';
import { resourceAction } from './microsoft/graph/resourceaction.interface';
import { plannerAppliedCategories } from './microsoft/graph/plannerappliedcategories.interface';
import { plannerAssignments } from './microsoft/graph/plannerassignments.interface';
import { plannerExternalReference } from './microsoft/graph/plannerexternalreference.interface';
import { plannerChecklistItem } from './microsoft/graph/plannerchecklistitem.interface';
import { plannerAssignment } from './microsoft/graph/plannerassignment.interface';
import { plannerExternalReferences } from './microsoft/graph/plannerexternalreferences.interface';
import { plannerChecklistItems } from './microsoft/graph/plannerchecklistitems.interface';
import { plannerOrderHintsByAssignee } from './microsoft/graph/plannerorderhintsbyassignee.interface';
import { plannerUserIds } from './microsoft/graph/planneruserids.interface';
import { plannerCategoryDescriptions } from './microsoft/graph/plannercategorydescriptions.interface';
import { resourceVisualization } from './microsoft/graph/resourcevisualization.interface';
import { resourceReference } from './microsoft/graph/resourcereference.interface';
import { sharingDetail } from './microsoft/graph/sharingdetail.interface';
import { insightIdentity } from './microsoft/graph/insightidentity.interface';
import { usageDetails } from './microsoft/graph/usagedetails.interface';
import { notebookLinks } from './microsoft/graph/notebooklinks.interface';
import { externalLink } from './microsoft/graph/externallink.interface';
import { sectionLinks } from './microsoft/graph/sectionlinks.interface';
import { pageLinks } from './microsoft/graph/pagelinks.interface';
import { onenoteOperationError } from './microsoft/graph/onenoteoperationerror.interface';
import { diagnostic } from './microsoft/graph/diagnostic.interface';
import { onenotePatchContentCommand } from './microsoft/graph/onenotepatchcontentcommand.interface';
import { onenotePagePreview } from './microsoft/graph/onenotepagepreview.interface';
import { onenotePagePreviewLinks } from './microsoft/graph/onenotepagepreviewlinks.interface';
import { recentNotebook } from './microsoft/graph/recentnotebook.interface';
import { recentNotebookLinks } from './microsoft/graph/recentnotebooklinks.interface';
import { CopyNotebookModel } from './microsoft/graph/copynotebookmodel.interface';
import { imageInfo } from './microsoft/graph/imageinfo.interface';
import { visualInfo } from './microsoft/graph/visualinfo.interface';
import { cloudAppSecurityState } from './microsoft/graph/cloudappsecuritystate.interface';
import { fileSecurityState } from './microsoft/graph/filesecuritystate.interface';
import { fileHash } from './microsoft/graph/filehash.interface';
import { alertHistoryState } from './microsoft/graph/alerthistorystate.interface';
import { hostSecurityState } from './microsoft/graph/hostsecuritystate.interface';
import { malwareState } from './microsoft/graph/malwarestate.interface';
import { networkConnection } from './microsoft/graph/networkconnection.interface';
import { process } from './microsoft/graph/process.interface';
import { registryKeyState } from './microsoft/graph/registrykeystate.interface';
import { alertTrigger } from './microsoft/graph/alerttrigger.interface';
import { userSecurityState } from './microsoft/graph/usersecuritystate.interface';
import { securityVendorInformation } from './microsoft/graph/securityvendorinformation.interface';
import { vulnerabilityState } from './microsoft/graph/vulnerabilitystate.interface';
import { averageComparativeScore } from './microsoft/graph/averagecomparativescore.interface';
import { controlScore } from './microsoft/graph/controlscore.interface';
import { complianceInformation } from './microsoft/graph/complianceinformation.interface';
import { certificationControl } from './microsoft/graph/certificationcontrol.interface';
import { secureScoreControlStateUpdate } from './microsoft/graph/securescorecontrolstateupdate.interface';
import { callMediaState } from './microsoft/graph/callmediastate.interface';
import { resultInfo } from './microsoft/graph/resultinfo.interface';
import { participantInfo } from './microsoft/graph/participantinfo.interface';
import { mediaConfig } from './microsoft/graph/mediaconfig.interface';
import { chatInfo } from './microsoft/graph/chatinfo.interface';
import { meetingInfo } from './microsoft/graph/meetinginfo.interface';
import { toneInfo } from './microsoft/graph/toneinfo.interface';
import { invitationParticipantInfo } from './microsoft/graph/invitationparticipantinfo.interface';
import { meetingParticipants } from './microsoft/graph/meetingparticipants.interface';
import { meetingParticipantInfo } from './microsoft/graph/meetingparticipantinfo.interface';
import { audioConferencing } from './microsoft/graph/audioconferencing.interface';
import { mediaStream } from './microsoft/graph/mediastream.interface';
import { commsNotification } from './microsoft/graph/commsnotification.interface';
import { commsNotifications } from './microsoft/graph/commsnotifications.interface';
import { appHostedMediaConfig } from './microsoft/graph/apphostedmediaconfig.interface';
import { serviceHostedMediaConfig } from './microsoft/graph/servicehostedmediaconfig.interface';
import { mediaInfo } from './microsoft/graph/mediainfo.interface';
import { organizerMeetingInfo } from './microsoft/graph/organizermeetinginfo.interface';
import { prompt } from './microsoft/graph/prompt.interface';
import { mediaPrompt } from './microsoft/graph/mediaprompt.interface';
import { teamMemberSettings } from './microsoft/graph/teammembersettings.interface';
import { teamGuestSettings } from './microsoft/graph/teamguestsettings.interface';
import { teamMessagingSettings } from './microsoft/graph/teammessagingsettings.interface';
import { teamFunSettings } from './microsoft/graph/teamfunsettings.interface';
import { teamClassSettings } from './microsoft/graph/teamclasssettings.interface';
import { teamsTabConfiguration } from './microsoft/graph/teamstabconfiguration.interface';
import { operationError } from './microsoft/graph/operationerror.interface';
import { entity } from './microsoft/graph/entity.interface';
import { directoryAudit } from './microsoft/graph/directoryaudit.interface';
import { signIn } from './microsoft/graph/signin.interface';
import { restrictedSignIn } from './microsoft/graph/restrictedsignin.interface';
import { auditLogRoot } from './microsoft/graph/auditlogroot.interface';
import { invitation } from './microsoft/graph/invitation.interface';
import { directoryObject } from './microsoft/graph/directoryobject.interface';
import { user } from './microsoft/graph/user.interface';
import { licenseDetails } from './microsoft/graph/licensedetails.interface';
import { outlookUser } from './microsoft/graph/outlookuser.interface';
import { outlookItem } from './microsoft/graph/outlookitem.interface';
import { message } from './microsoft/graph/message.interface';
import { mailFolder } from './microsoft/graph/mailfolder.interface';
import { calendar } from './microsoft/graph/calendar.interface';
import { calendarGroup } from './microsoft/graph/calendargroup.interface';
import { event } from './microsoft/graph/event.interface';
import { person } from './microsoft/graph/person.interface';
import { contact } from './microsoft/graph/contact.interface';
import { contactFolder } from './microsoft/graph/contactfolder.interface';
import { inferenceClassification } from './microsoft/graph/inferenceclassification.interface';
import { profilePhoto } from './microsoft/graph/profilephoto.interface';
import { baseItem } from './microsoft/graph/baseitem.interface';
import { drive } from './microsoft/graph/drive.interface';
import { extension } from './microsoft/graph/extension.interface';
import { managedDevice } from './microsoft/graph/manageddevice.interface';
import { managedAppRegistration } from './microsoft/graph/managedappregistration.interface';
import { deviceManagementTroubleshootingEvent } from './microsoft/graph/devicemanagementtroubleshootingevent.interface';
import { plannerUser } from './microsoft/graph/planneruser.interface';
import { officeGraphInsights } from './microsoft/graph/officegraphinsights.interface';
import { userSettings } from './microsoft/graph/usersettings.interface';
import { onenote } from './microsoft/graph/onenote.interface';
import { userActivity } from './microsoft/graph/useractivity.interface';
import { onlineMeeting } from './microsoft/graph/onlinemeeting.interface';
import { group } from './microsoft/graph/group.interface';
import { identityProvider } from './microsoft/graph/identityprovider.interface';
import { administrativeUnit } from './microsoft/graph/administrativeunit.interface';
import { directory } from './microsoft/graph/directory.interface';
import { device } from './microsoft/graph/device.interface';
import { directoryObjectPartnerReference } from './microsoft/graph/directoryobjectpartnerreference.interface';
import { directoryRole } from './microsoft/graph/directoryrole.interface';
import { directoryRoleTemplate } from './microsoft/graph/directoryroletemplate.interface';
import { domain } from './microsoft/graph/domain.interface';
import { domainDnsRecord } from './microsoft/graph/domaindnsrecord.interface';
import { domainDnsCnameRecord } from './microsoft/graph/domaindnscnamerecord.interface';
import { domainDnsMxRecord } from './microsoft/graph/domaindnsmxrecord.interface';
import { domainDnsSrvRecord } from './microsoft/graph/domaindnssrvrecord.interface';
import { domainDnsTxtRecord } from './microsoft/graph/domaindnstxtrecord.interface';
import { domainDnsUnavailableRecord } from './microsoft/graph/domaindnsunavailablerecord.interface';
import { groupSetting } from './microsoft/graph/groupsetting.interface';
import { conversation } from './microsoft/graph/conversation.interface';
import { conversationThread } from './microsoft/graph/conversationthread.interface';
import { site } from './microsoft/graph/site.interface';
import { groupLifecyclePolicy } from './microsoft/graph/grouplifecyclepolicy.interface';
import { plannerGroup } from './microsoft/graph/plannergroup.interface';
import { team } from './microsoft/graph/team.interface';
import { contract } from './microsoft/graph/contract.interface';
import { subscribedSku } from './microsoft/graph/subscribedsku.interface';
import { organization } from './microsoft/graph/organization.interface';
import { groupSettingTemplate } from './microsoft/graph/groupsettingtemplate.interface';
import { educationRoot } from './microsoft/graph/educationroot.interface';
import { educationClass } from './microsoft/graph/educationclass.interface';
import { educationOrganization } from './microsoft/graph/educationorganization.interface';
import { educationSchool } from './microsoft/graph/educationschool.interface';
import { educationUser } from './microsoft/graph/educationuser.interface';
import { itemAnalytics } from './microsoft/graph/itemanalytics.interface';
import { columnDefinition } from './microsoft/graph/columndefinition.interface';
import { contentType } from './microsoft/graph/contenttype.interface';
import { list } from './microsoft/graph/list.interface';
import { listItem } from './microsoft/graph/listitem.interface';
import { driveItem } from './microsoft/graph/driveitem.interface';
import { workbook } from './microsoft/graph/workbook.interface';
import { permission } from './microsoft/graph/permission.interface';
import { subscription } from './microsoft/graph/subscription.interface';
import { thumbnailSet } from './microsoft/graph/thumbnailset.interface';
import { baseItemVersion } from './microsoft/graph/baseitemversion.interface';
import { driveItemVersion } from './microsoft/graph/driveitemversion.interface';
import { workbookApplication } from './microsoft/graph/workbookapplication.interface';
import { workbookNamedItem } from './microsoft/graph/workbooknameditem.interface';
import { workbookTable } from './microsoft/graph/workbooktable.interface';
import { workbookWorksheet } from './microsoft/graph/workbookworksheet.interface';
import { workbookComment } from './microsoft/graph/workbookcomment.interface';
import { workbookFunctions } from './microsoft/graph/workbookfunctions.interface';
import { workbookChart } from './microsoft/graph/workbookchart.interface';
import { workbookChartAxes } from './microsoft/graph/workbookchartaxes.interface';
import { workbookChartDataLabels } from './microsoft/graph/workbookchartdatalabels.interface';
import { workbookChartAreaFormat } from './microsoft/graph/workbookchartareaformat.interface';
import { workbookChartLegend } from './microsoft/graph/workbookchartlegend.interface';
import { workbookChartSeries } from './microsoft/graph/workbookchartseries.interface';
import { workbookChartTitle } from './microsoft/graph/workbookcharttitle.interface';
import { workbookChartFill } from './microsoft/graph/workbookchartfill.interface';
import { workbookChartFont } from './microsoft/graph/workbookchartfont.interface';
import { workbookChartAxis } from './microsoft/graph/workbookchartaxis.interface';
import { workbookChartAxisFormat } from './microsoft/graph/workbookchartaxisformat.interface';
import { workbookChartGridlines } from './microsoft/graph/workbookchartgridlines.interface';
import { workbookChartAxisTitle } from './microsoft/graph/workbookchartaxistitle.interface';
import { workbookChartLineFormat } from './microsoft/graph/workbookchartlineformat.interface';
import { workbookChartAxisTitleFormat } from './microsoft/graph/workbookchartaxistitleformat.interface';
import { workbookChartDataLabelFormat } from './microsoft/graph/workbookchartdatalabelformat.interface';
import { workbookChartGridlinesFormat } from './microsoft/graph/workbookchartgridlinesformat.interface';
import { workbookChartLegendFormat } from './microsoft/graph/workbookchartlegendformat.interface';
import { workbookChartPoint } from './microsoft/graph/workbookchartpoint.interface';
import { workbookChartPointFormat } from './microsoft/graph/workbookchartpointformat.interface';
import { workbookChartSeriesFormat } from './microsoft/graph/workbookchartseriesformat.interface';
import { workbookChartTitleFormat } from './microsoft/graph/workbookcharttitleformat.interface';
import { workbookCommentReply } from './microsoft/graph/workbookcommentreply.interface';
import { workbookFilter } from './microsoft/graph/workbookfilter.interface';
import { workbookFormatProtection } from './microsoft/graph/workbookformatprotection.interface';
import { workbookFunctionResult } from './microsoft/graph/workbookfunctionresult.interface';
import { workbookPivotTable } from './microsoft/graph/workbookpivottable.interface';
import { workbookRange } from './microsoft/graph/workbookrange.interface';
import { workbookRangeFormat } from './microsoft/graph/workbookrangeformat.interface';
import { workbookRangeSort } from './microsoft/graph/workbookrangesort.interface';
import { workbookRangeBorder } from './microsoft/graph/workbookrangeborder.interface';
import { workbookRangeFill } from './microsoft/graph/workbookrangefill.interface';
import { workbookRangeFont } from './microsoft/graph/workbookrangefont.interface';
import { workbookRangeView } from './microsoft/graph/workbookrangeview.interface';
import { workbookTableColumn } from './microsoft/graph/workbooktablecolumn.interface';
import { workbookTableRow } from './microsoft/graph/workbooktablerow.interface';
import { workbookTableSort } from './microsoft/graph/workbooktablesort.interface';
import { workbookWorksheetProtection } from './microsoft/graph/workbookworksheetprotection.interface';
import { outlookCategory } from './microsoft/graph/outlookcategory.interface';
import { singleValueLegacyExtendedProperty } from './microsoft/graph/singlevaluelegacyextendedproperty.interface';
import { multiValueLegacyExtendedProperty } from './microsoft/graph/multivaluelegacyextendedproperty.interface';
import { attachment } from './microsoft/graph/attachment.interface';
import { eventMessage } from './microsoft/graph/eventmessage.interface';
import { messageRule } from './microsoft/graph/messagerule.interface';
import { mailSearchFolder } from './microsoft/graph/mailsearchfolder.interface';
import { inferenceClassificationOverride } from './microsoft/graph/inferenceclassificationoverride.interface';
import { post } from './microsoft/graph/post.interface';
import { fileAttachment } from './microsoft/graph/fileattachment.interface';
import { itemAttachment } from './microsoft/graph/itemattachment.interface';
import { referenceAttachment } from './microsoft/graph/referenceattachment.interface';
import { openTypeExtension } from './microsoft/graph/opentypeextension.interface';
import { columnLink } from './microsoft/graph/columnlink.interface';
import { fieldValueSet } from './microsoft/graph/fieldvalueset.interface';
import { itemActivity } from './microsoft/graph/itemactivity.interface';
import { itemActivityStat } from './microsoft/graph/itemactivitystat.interface';
import { listItemVersion } from './microsoft/graph/listitemversion.interface';
import { sharedDriveItem } from './microsoft/graph/shareddriveitem.interface';
import { schemaExtension } from './microsoft/graph/schemaextension.interface';
import { deviceAppManagement } from './microsoft/graph/deviceappmanagement.interface';
import { managedEBook } from './microsoft/graph/managedebook.interface';
import { mobileApp } from './microsoft/graph/mobileapp.interface';
import { mobileAppCategory } from './microsoft/graph/mobileappcategory.interface';
import { managedDeviceMobileAppConfiguration } from './microsoft/graph/manageddevicemobileappconfiguration.interface';
import { vppToken } from './microsoft/graph/vpptoken.interface';
import { managedAppPolicy } from './microsoft/graph/managedapppolicy.interface';
import { managedAppProtection } from './microsoft/graph/managedappprotection.interface';
import { targetedManagedAppProtection } from './microsoft/graph/targetedmanagedappprotection.interface';
import { iosManagedAppProtection } from './microsoft/graph/iosmanagedappprotection.interface';
import { androidManagedAppProtection } from './microsoft/graph/androidmanagedappprotection.interface';
import { defaultManagedAppProtection } from './microsoft/graph/defaultmanagedappprotection.interface';
import { managedAppConfiguration } from './microsoft/graph/managedappconfiguration.interface';
import { targetedManagedAppConfiguration } from './microsoft/graph/targetedmanagedappconfiguration.interface';
import { windowsInformationProtection } from './microsoft/graph/windowsinformationprotection.interface';
import { mdmWindowsInformationProtectionPolicy } from './microsoft/graph/mdmwindowsinformationprotectionpolicy.interface';
import { windowsInformationProtectionPolicy } from './microsoft/graph/windowsinformationprotectionpolicy.interface';
import { managedAppStatus } from './microsoft/graph/managedappstatus.interface';
import { mobileAppAssignment } from './microsoft/graph/mobileappassignment.interface';
import { mobileAppContentFile } from './microsoft/graph/mobileappcontentfile.interface';
import { managedDeviceMobileAppConfigurationAssignment } from './microsoft/graph/manageddevicemobileappconfigurationassignment.interface';
import { managedDeviceMobileAppConfigurationDeviceStatus } from './microsoft/graph/manageddevicemobileappconfigurationdevicestatus.interface';
import { managedDeviceMobileAppConfigurationUserStatus } from './microsoft/graph/manageddevicemobileappconfigurationuserstatus.interface';
import { managedDeviceMobileAppConfigurationDeviceSummary } from './microsoft/graph/manageddevicemobileappconfigurationdevicesummary.interface';
import { managedDeviceMobileAppConfigurationUserSummary } from './microsoft/graph/manageddevicemobileappconfigurationusersummary.interface';
import { macOSOfficeSuiteApp } from './microsoft/graph/macosofficesuiteapp.interface';
import { managedApp } from './microsoft/graph/managedapp.interface';
import { managedAndroidStoreApp } from './microsoft/graph/managedandroidstoreapp.interface';
import { managedIOSStoreApp } from './microsoft/graph/managediosstoreapp.interface';
import { managedMobileLobApp } from './microsoft/graph/managedmobilelobapp.interface';
import { mobileAppContent } from './microsoft/graph/mobileappcontent.interface';
import { managedAndroidLobApp } from './microsoft/graph/managedandroidlobapp.interface';
import { managedIOSLobApp } from './microsoft/graph/managedioslobapp.interface';
import { mobileLobApp } from './microsoft/graph/mobilelobapp.interface';
import { windowsMobileMSI } from './microsoft/graph/windowsmobilemsi.interface';
import { windowsUniversalAppX } from './microsoft/graph/windowsuniversalappx.interface';
import { androidLobApp } from './microsoft/graph/androidlobapp.interface';
import { iosLobApp } from './microsoft/graph/ioslobapp.interface';
import { microsoftStoreForBusinessApp } from './microsoft/graph/microsoftstoreforbusinessapp.interface';
import { webApp } from './microsoft/graph/webapp.interface';
import { androidStoreApp } from './microsoft/graph/androidstoreapp.interface';
import { iosVppApp } from './microsoft/graph/iosvppapp.interface';
import { iosStoreApp } from './microsoft/graph/iosstoreapp.interface';
import { iosMobileAppConfiguration } from './microsoft/graph/iosmobileappconfiguration.interface';
import { managedEBookAssignment } from './microsoft/graph/managedebookassignment.interface';
import { eBookInstallSummary } from './microsoft/graph/ebookinstallsummary.interface';
import { deviceInstallState } from './microsoft/graph/deviceinstallstate.interface';
import { userInstallStateSummary } from './microsoft/graph/userinstallstatesummary.interface';
import { iosVppEBookAssignment } from './microsoft/graph/iosvppebookassignment.interface';
import { iosVppEBook } from './microsoft/graph/iosvppebook.interface';
import { deviceManagement } from './microsoft/graph/devicemanagement.interface';
import { termsAndConditions } from './microsoft/graph/termsandconditions.interface';
import { deviceConfiguration } from './microsoft/graph/deviceconfiguration.interface';
import { deviceCompliancePolicy } from './microsoft/graph/devicecompliancepolicy.interface';
import { softwareUpdateStatusSummary } from './microsoft/graph/softwareupdatestatussummary.interface';
import { deviceCompliancePolicyDeviceStateSummary } from './microsoft/graph/devicecompliancepolicydevicestatesummary.interface';
import { deviceCompliancePolicySettingStateSummary } from './microsoft/graph/devicecompliancepolicysettingstatesummary.interface';
import { deviceConfigurationDeviceStateSummary } from './microsoft/graph/deviceconfigurationdevicestatesummary.interface';
import { iosUpdateDeviceStatus } from './microsoft/graph/iosupdatedevicestatus.interface';
import { deviceCategory } from './microsoft/graph/devicecategory.interface';
import { deviceManagementExchangeConnector } from './microsoft/graph/devicemanagementexchangeconnector.interface';
import { deviceEnrollmentConfiguration } from './microsoft/graph/deviceenrollmentconfiguration.interface';
import { onPremisesConditionalAccessSettings } from './microsoft/graph/onpremisesconditionalaccesssettings.interface';
import { mobileThreatDefenseConnector } from './microsoft/graph/mobilethreatdefenseconnector.interface';
import { deviceManagementPartner } from './microsoft/graph/devicemanagementpartner.interface';
import { applePushNotificationCertificate } from './microsoft/graph/applepushnotificationcertificate.interface';
import { managedDeviceOverview } from './microsoft/graph/manageddeviceoverview.interface';
import { detectedApp } from './microsoft/graph/detectedapp.interface';
import { notificationMessageTemplate } from './microsoft/graph/notificationmessagetemplate.interface';
import { roleDefinition } from './microsoft/graph/roledefinition.interface';
import { roleAssignment } from './microsoft/graph/roleassignment.interface';
import { deviceAndAppManagementRoleAssignment } from './microsoft/graph/deviceandappmanagementroleassignment.interface';
import { resourceOperation } from './microsoft/graph/resourceoperation.interface';
import { remoteAssistancePartner } from './microsoft/graph/remoteassistancepartner.interface';
import { telecomExpenseManagementPartner } from './microsoft/graph/telecomexpensemanagementpartner.interface';
import { windowsInformationProtectionAppLearningSummary } from './microsoft/graph/windowsinformationprotectionapplearningsummary.interface';
import { windowsInformationProtectionNetworkLearningSummary } from './microsoft/graph/windowsinformationprotectionnetworklearningsummary.interface';
import { termsAndConditionsAssignment } from './microsoft/graph/termsandconditionsassignment.interface';
import { termsAndConditionsAcceptanceStatus } from './microsoft/graph/termsandconditionsacceptancestatus.interface';
import { reportRoot } from './microsoft/graph/reportroot.interface';
import { deviceConfigurationAssignment } from './microsoft/graph/deviceconfigurationassignment.interface';
import { deviceConfigurationDeviceStatus } from './microsoft/graph/deviceconfigurationdevicestatus.interface';
import { deviceConfigurationUserStatus } from './microsoft/graph/deviceconfigurationuserstatus.interface';
import { deviceConfigurationDeviceOverview } from './microsoft/graph/deviceconfigurationdeviceoverview.interface';
import { deviceConfigurationUserOverview } from './microsoft/graph/deviceconfigurationuseroverview.interface';
import { settingStateDeviceSummary } from './microsoft/graph/settingstatedevicesummary.interface';
import { deviceCompliancePolicyAssignment } from './microsoft/graph/devicecompliancepolicyassignment.interface';
import { deviceComplianceScheduledActionForRule } from './microsoft/graph/devicecompliancescheduledactionforrule.interface';
import { deviceComplianceDeviceStatus } from './microsoft/graph/devicecompliancedevicestatus.interface';
import { deviceComplianceUserStatus } from './microsoft/graph/devicecomplianceuserstatus.interface';
import { deviceComplianceDeviceOverview } from './microsoft/graph/devicecompliancedeviceoverview.interface';
import { deviceComplianceUserOverview } from './microsoft/graph/devicecomplianceuseroverview.interface';
import { deviceComplianceActionItem } from './microsoft/graph/devicecomplianceactionitem.interface';
import { androidCustomConfiguration } from './microsoft/graph/androidcustomconfiguration.interface';
import { androidGeneralDeviceConfiguration } from './microsoft/graph/androidgeneraldeviceconfiguration.interface';
import { androidWorkProfileCustomConfiguration } from './microsoft/graph/androidworkprofilecustomconfiguration.interface';
import { androidWorkProfileGeneralDeviceConfiguration } from './microsoft/graph/androidworkprofilegeneraldeviceconfiguration.interface';
import { iosCertificateProfile } from './microsoft/graph/ioscertificateprofile.interface';
import { iosCustomConfiguration } from './microsoft/graph/ioscustomconfiguration.interface';
import { iosGeneralDeviceConfiguration } from './microsoft/graph/iosgeneraldeviceconfiguration.interface';
import { iosUpdateConfiguration } from './microsoft/graph/iosupdateconfiguration.interface';
import { macOSCustomConfiguration } from './microsoft/graph/macoscustomconfiguration.interface';
import { macOSGeneralDeviceConfiguration } from './microsoft/graph/macosgeneraldeviceconfiguration.interface';
import { appleDeviceFeaturesConfigurationBase } from './microsoft/graph/appledevicefeaturesconfigurationbase.interface';
import { iosDeviceFeaturesConfiguration } from './microsoft/graph/iosdevicefeaturesconfiguration.interface';
import { macOSDeviceFeaturesConfiguration } from './microsoft/graph/macosdevicefeaturesconfiguration.interface';
import { windows10EndpointProtectionConfiguration } from './microsoft/graph/windows10endpointprotectionconfiguration.interface';
import { windows10GeneralConfiguration } from './microsoft/graph/windows10generalconfiguration.interface';
import { windowsDefenderAdvancedThreatProtectionConfiguration } from './microsoft/graph/windowsdefenderadvancedthreatprotectionconfiguration.interface';
import { editionUpgradeConfiguration } from './microsoft/graph/editionupgradeconfiguration.interface';
import { windows10CustomConfiguration } from './microsoft/graph/windows10customconfiguration.interface';
import { windows10EnterpriseModernAppManagementConfiguration } from './microsoft/graph/windows10enterprisemodernappmanagementconfiguration.interface';
import { sharedPCConfiguration } from './microsoft/graph/sharedpcconfiguration.interface';
import { windows10SecureAssessmentConfiguration } from './microsoft/graph/windows10secureassessmentconfiguration.interface';
import { windowsPhone81CustomConfiguration } from './microsoft/graph/windowsphone81customconfiguration.interface';
import { windowsUpdateForBusinessConfiguration } from './microsoft/graph/windowsupdateforbusinessconfiguration.interface';
import { windows81GeneralConfiguration } from './microsoft/graph/windows81generalconfiguration.interface';
import { windowsPhone81GeneralConfiguration } from './microsoft/graph/windowsphone81generalconfiguration.interface';
import { windows10TeamGeneralConfiguration } from './microsoft/graph/windows10teamgeneralconfiguration.interface';
import { androidCompliancePolicy } from './microsoft/graph/androidcompliancepolicy.interface';
import { androidWorkProfileCompliancePolicy } from './microsoft/graph/androidworkprofilecompliancepolicy.interface';
import { iosCompliancePolicy } from './microsoft/graph/ioscompliancepolicy.interface';
import { macOSCompliancePolicy } from './microsoft/graph/macoscompliancepolicy.interface';
import { windows10CompliancePolicy } from './microsoft/graph/windows10compliancepolicy.interface';
import { windows10MobileCompliancePolicy } from './microsoft/graph/windows10mobilecompliancepolicy.interface';
import { windows81CompliancePolicy } from './microsoft/graph/windows81compliancepolicy.interface';
import { windowsPhone81CompliancePolicy } from './microsoft/graph/windowsphone81compliancepolicy.interface';
import { deviceComplianceSettingState } from './microsoft/graph/devicecompliancesettingstate.interface';
import { deviceConfigurationState } from './microsoft/graph/deviceconfigurationstate.interface';
import { deviceCompliancePolicyState } from './microsoft/graph/devicecompliancepolicystate.interface';
import { enrollmentConfigurationAssignment } from './microsoft/graph/enrollmentconfigurationassignment.interface';
import { deviceEnrollmentLimitConfiguration } from './microsoft/graph/deviceenrollmentlimitconfiguration.interface';
import { deviceEnrollmentPlatformRestrictionsConfiguration } from './microsoft/graph/deviceenrollmentplatformrestrictionsconfiguration.interface';
import { deviceEnrollmentWindowsHelloForBusinessConfiguration } from './microsoft/graph/deviceenrollmentwindowshelloforbusinessconfiguration.interface';
import { managedMobileApp } from './microsoft/graph/managedmobileapp.interface';
import { targetedManagedAppPolicyAssignment } from './microsoft/graph/targetedmanagedapppolicyassignment.interface';
import { managedAppOperation } from './microsoft/graph/managedappoperation.interface';
import { managedAppPolicyDeploymentSummary } from './microsoft/graph/managedapppolicydeploymentsummary.interface';
import { windowsInformationProtectionAppLockerFile } from './microsoft/graph/windowsinformationprotectionapplockerfile.interface';
import { iosManagedAppRegistration } from './microsoft/graph/iosmanagedappregistration.interface';
import { androidManagedAppRegistration } from './microsoft/graph/androidmanagedappregistration.interface';
import { managedAppStatusRaw } from './microsoft/graph/managedappstatusraw.interface';
import { localizedNotificationMessage } from './microsoft/graph/localizednotificationmessage.interface';
import { deviceAndAppManagementRoleDefinition } from './microsoft/graph/deviceandappmanagementroledefinition.interface';
import { enrollmentTroubleshootingEvent } from './microsoft/graph/enrollmenttroubleshootingevent.interface';
import { plannerTask } from './microsoft/graph/plannertask.interface';
import { plannerPlan } from './microsoft/graph/plannerplan.interface';
import { planner } from './microsoft/graph/planner.interface';
import { plannerBucket } from './microsoft/graph/plannerbucket.interface';
import { plannerTaskDetails } from './microsoft/graph/plannertaskdetails.interface';
import { plannerAssignedToTaskBoardTaskFormat } from './microsoft/graph/plannerassignedtotaskboardtaskformat.interface';
import { plannerProgressTaskBoardTaskFormat } from './microsoft/graph/plannerprogresstaskboardtaskformat.interface';
import { plannerBucketTaskBoardTaskFormat } from './microsoft/graph/plannerbuckettaskboardtaskformat.interface';
import { plannerPlanDetails } from './microsoft/graph/plannerplandetails.interface';
import { trending } from './microsoft/graph/trending.interface';
import { sharedInsight } from './microsoft/graph/sharedinsight.interface';
import { usedInsight } from './microsoft/graph/usedinsight.interface';
import { onenoteEntityBaseModel } from './microsoft/graph/onenoteentitybasemodel.interface';
import { onenoteEntitySchemaObjectModel } from './microsoft/graph/onenoteentityschemaobjectmodel.interface';
import { onenoteEntityHierarchyModel } from './microsoft/graph/onenoteentityhierarchymodel.interface';
import { notebook } from './microsoft/graph/notebook.interface';
import { onenoteSection } from './microsoft/graph/onenotesection.interface';
import { sectionGroup } from './microsoft/graph/sectiongroup.interface';
import { onenotePage } from './microsoft/graph/onenotepage.interface';
import { onenoteResource } from './microsoft/graph/onenoteresource.interface';
import { operation } from './microsoft/graph/operation.interface';
import { onenoteOperation } from './microsoft/graph/onenoteoperation.interface';
import { dataPolicyOperation } from './microsoft/graph/datapolicyoperation.interface';
import { activityHistoryItem } from './microsoft/graph/activityhistoryitem.interface';
import { security } from './microsoft/graph/security.interface';
import { alert } from './microsoft/graph/alert.interface';
import { secureScoreControlProfile } from './microsoft/graph/securescorecontrolprofile.interface';
import { secureScore } from './microsoft/graph/securescore.interface';
import { cloudCommunications } from './microsoft/graph/cloudcommunications.interface';
import { call } from './microsoft/graph/call.interface';
import { participant } from './microsoft/graph/participant.interface';
import { commsOperation } from './microsoft/graph/commsoperation.interface';
import { inviteParticipantsOperation } from './microsoft/graph/inviteparticipantsoperation.interface';
import { muteParticipantOperation } from './microsoft/graph/muteparticipantoperation.interface';
import { playPromptOperation } from './microsoft/graph/playpromptoperation.interface';
import { recordOperation } from './microsoft/graph/recordoperation.interface';
import { subscribeToToneOperation } from './microsoft/graph/subscribetotoneoperation.interface';
import { unmuteParticipantOperation } from './microsoft/graph/unmuteparticipantoperation.interface';
import { appCatalogs } from './microsoft/graph/appcatalogs.interface';
import { teamsApp } from './microsoft/graph/teamsapp.interface';
import { channel } from './microsoft/graph/channel.interface';
import { teamsAppInstallation } from './microsoft/graph/teamsappinstallation.interface';
import { teamsAsyncOperation } from './microsoft/graph/teamsasyncoperation.interface';
import { teamsAppDefinition } from './microsoft/graph/teamsappdefinition.interface';
import { teamsTab } from './microsoft/graph/teamstab.interface';

export const MsGraphConfig: ODataConfig = {
  baseUrl: 'https://graph.microsoft.com/v1.0/',
  metadataUrl: 'https://graph.microsoft.com/v1.0/$metadata',
  withCredentials: true,
  creation: new Date('2019-10-09T08:32:25.7485154-03:00'),
  version: '4.0',
  enums: {
    'microsoft.graph.riskLevel': riskLevel,
    'microsoft.graph.appliedConditionalAccessPolicyResult': appliedConditionalAccessPolicyResult,
    'microsoft.graph.conditionalAccessStatus': conditionalAccessStatus,
    'microsoft.graph.groupType': groupType,
    'microsoft.graph.operationResult': operationResult,
    'microsoft.graph.riskState': riskState,
    'microsoft.graph.riskDetail': riskDetail,
    'microsoft.graph.riskEventType': riskEventType,
    'microsoft.graph.educationUserRole': educationUserRole,
    'microsoft.graph.educationExternalSource': educationExternalSource,
    'microsoft.graph.educationGender': educationGender,
    'microsoft.graph.attendeeType': attendeeType,
    'microsoft.graph.activityDomain': activityDomain,
    'microsoft.graph.freeBusyStatus': freeBusyStatus,
    'microsoft.graph.locationType': locationType,
    'microsoft.graph.physicalAddressType': physicalAddressType,
    'microsoft.graph.locationUniqueIdType': locationUniqueIdType,
    'microsoft.graph.dayOfWeek': dayOfWeek,
    'microsoft.graph.automaticRepliesStatus': automaticRepliesStatus,
    'microsoft.graph.externalAudienceScope': externalAudienceScope,
    'microsoft.graph.mailTipsType': mailTipsType,
    'microsoft.graph.recipientScopeType': recipientScopeType,
    'microsoft.graph.exchangeIdFormat': exchangeIdFormat,
    'microsoft.graph.timeZoneStandard': timeZoneStandard,
    'microsoft.graph.bodyType': bodyType,
    'microsoft.graph.importance': importance,
    'microsoft.graph.inferenceClassificationType': inferenceClassificationType,
    'microsoft.graph.followupFlagStatus': followupFlagStatus,
    'microsoft.graph.meetingMessageType': meetingMessageType,
    'microsoft.graph.calendarColor': calendarColor,
    'microsoft.graph.responseType': responseType,
    'microsoft.graph.sensitivity': sensitivity,
    'microsoft.graph.recurrencePatternType': recurrencePatternType,
    'microsoft.graph.weekIndex': weekIndex,
    'microsoft.graph.recurrenceRangeType': recurrenceRangeType,
    'microsoft.graph.eventType': eventType,
    'microsoft.graph.selectionLikelihoodInfo': selectionLikelihoodInfo,
    'microsoft.graph.phoneType': phoneType,
    'microsoft.graph.websiteType': websiteType,
    'microsoft.graph.categoryColor': categoryColor,
    'microsoft.graph.messageActionFlag': messageActionFlag,
    'microsoft.graph.installIntent': installIntent,
    'microsoft.graph.mobileAppPublishingState': mobileAppPublishingState,
    'microsoft.graph.windowsArchitecture': windowsArchitecture,
    'microsoft.graph.managedAppAvailability': managedAppAvailability,
    'microsoft.graph.mobileAppContentFileUploadState': mobileAppContentFileUploadState,
    'microsoft.graph.windowsDeviceType': windowsDeviceType,
    'microsoft.graph.vppTokenAccountType': vppTokenAccountType,
    'microsoft.graph.microsoftStoreForBusinessLicenseType': microsoftStoreForBusinessLicenseType,
    'microsoft.graph.complianceStatus': complianceStatus,
    'microsoft.graph.mdmAppConfigKeyType': mdmAppConfigKeyType,
    'microsoft.graph.installState': installState,
    'microsoft.graph.windows10EditionType': windows10EditionType,
    'microsoft.graph.appListType': appListType,
    'microsoft.graph.androidRequiredPasswordType': androidRequiredPasswordType,
    'microsoft.graph.webBrowserCookieSettings': webBrowserCookieSettings,
    'microsoft.graph.androidWorkProfileRequiredPasswordType': androidWorkProfileRequiredPasswordType,
    'microsoft.graph.androidWorkProfileCrossProfileDataSharingType': androidWorkProfileCrossProfileDataSharingType,
    'microsoft.graph.androidWorkProfileDefaultAppPermissionPolicyType': androidWorkProfileDefaultAppPermissionPolicyType,
    'microsoft.graph.ratingAustraliaMoviesType': ratingAustraliaMoviesType,
    'microsoft.graph.ratingAustraliaTelevisionType': ratingAustraliaTelevisionType,
    'microsoft.graph.ratingCanadaMoviesType': ratingCanadaMoviesType,
    'microsoft.graph.ratingCanadaTelevisionType': ratingCanadaTelevisionType,
    'microsoft.graph.ratingFranceMoviesType': ratingFranceMoviesType,
    'microsoft.graph.ratingFranceTelevisionType': ratingFranceTelevisionType,
    'microsoft.graph.ratingGermanyMoviesType': ratingGermanyMoviesType,
    'microsoft.graph.ratingGermanyTelevisionType': ratingGermanyTelevisionType,
    'microsoft.graph.ratingIrelandMoviesType': ratingIrelandMoviesType,
    'microsoft.graph.ratingIrelandTelevisionType': ratingIrelandTelevisionType,
    'microsoft.graph.ratingJapanMoviesType': ratingJapanMoviesType,
    'microsoft.graph.ratingJapanTelevisionType': ratingJapanTelevisionType,
    'microsoft.graph.ratingNewZealandMoviesType': ratingNewZealandMoviesType,
    'microsoft.graph.ratingNewZealandTelevisionType': ratingNewZealandTelevisionType,
    'microsoft.graph.ratingUnitedKingdomMoviesType': ratingUnitedKingdomMoviesType,
    'microsoft.graph.ratingUnitedKingdomTelevisionType': ratingUnitedKingdomTelevisionType,
    'microsoft.graph.ratingUnitedStatesMoviesType': ratingUnitedStatesMoviesType,
    'microsoft.graph.ratingUnitedStatesTelevisionType': ratingUnitedStatesTelevisionType,
    'microsoft.graph.ratingAppsType': ratingAppsType,
    'microsoft.graph.requiredPasswordType': requiredPasswordType,
    'microsoft.graph.iosNotificationAlertType': iosNotificationAlertType,
    'microsoft.graph.stateManagementSetting': stateManagementSetting,
    'microsoft.graph.firewallPreSharedKeyEncodingMethodType': firewallPreSharedKeyEncodingMethodType,
    'microsoft.graph.firewallCertificateRevocationListCheckMethodType': firewallCertificateRevocationListCheckMethodType,
    'microsoft.graph.firewallPacketQueueingMethodType': firewallPacketQueueingMethodType,
    'microsoft.graph.appLockerApplicationControlType': appLockerApplicationControlType,
    'microsoft.graph.applicationGuardBlockFileTransferType': applicationGuardBlockFileTransferType,
    'microsoft.graph.applicationGuardBlockClipboardSharingType': applicationGuardBlockClipboardSharingType,
    'microsoft.graph.bitLockerEncryptionMethod': bitLockerEncryptionMethod,
    'microsoft.graph.diagnosticDataSubmissionMode': diagnosticDataSubmissionMode,
    'microsoft.graph.edgeCookiePolicy': edgeCookiePolicy,
    'microsoft.graph.visibilitySetting': visibilitySetting,
    'microsoft.graph.defenderThreatAction': defenderThreatAction,
    'microsoft.graph.weeklySchedule': weeklySchedule,
    'microsoft.graph.defenderMonitorFileActivity': defenderMonitorFileActivity,
    'microsoft.graph.defenderPromptForSampleSubmission': defenderPromptForSampleSubmission,
    'microsoft.graph.defenderScanType': defenderScanType,
    'microsoft.graph.defenderCloudBlockLevelType': defenderCloudBlockLevelType,
    'microsoft.graph.windowsStartMenuAppListVisibilityType': windowsStartMenuAppListVisibilityType,
    'microsoft.graph.windowsStartMenuModeType': windowsStartMenuModeType,
    'microsoft.graph.windowsSpotlightEnablementSettings': windowsSpotlightEnablementSettings,
    'microsoft.graph.automaticUpdateMode': automaticUpdateMode,
    'microsoft.graph.safeSearchFilterType': safeSearchFilterType,
    'microsoft.graph.edgeSearchEngineType': edgeSearchEngineType,
    'microsoft.graph.prereleaseFeatures': prereleaseFeatures,
    'microsoft.graph.editionUpgradeLicenseType': editionUpgradeLicenseType,
    'microsoft.graph.windowsDeliveryOptimizationMode': windowsDeliveryOptimizationMode,
    'microsoft.graph.sharedPCAccountDeletionPolicyType': sharedPCAccountDeletionPolicyType,
    'microsoft.graph.sharedPCAllowedAccountType': sharedPCAllowedAccountType,
    'microsoft.graph.windowsUpdateType': windowsUpdateType,
    'microsoft.graph.internetSiteSecurityLevel': internetSiteSecurityLevel,
    'microsoft.graph.siteSecurityLevel': siteSecurityLevel,
    'microsoft.graph.windowsUserAccountControlSettings': windowsUserAccountControlSettings,
    'microsoft.graph.miracastChannel': miracastChannel,
    'microsoft.graph.welcomeScreenMeetingInformation': welcomeScreenMeetingInformation,
    'microsoft.graph.deviceComplianceActionType': deviceComplianceActionType,
    'microsoft.graph.deviceThreatProtectionLevel': deviceThreatProtectionLevel,
    'microsoft.graph.policyPlatformType': policyPlatformType,
    'microsoft.graph.iosUpdatesInstallStatus': iosUpdatesInstallStatus,
    'microsoft.graph.deviceManagementExchangeConnectorSyncType': deviceManagementExchangeConnectorSyncType,
    'microsoft.graph.mdmAuthority': mdmAuthority,
    'microsoft.graph.windowsHelloForBusinessPinUsage': windowsHelloForBusinessPinUsage,
    'microsoft.graph.enablement': enablement,
    'microsoft.graph.vppTokenState': vppTokenState,
    'microsoft.graph.vppTokenSyncStatus': vppTokenSyncStatus,
    'microsoft.graph.deviceManagementExchangeConnectorStatus': deviceManagementExchangeConnectorStatus,
    'microsoft.graph.deviceManagementExchangeConnectorType': deviceManagementExchangeConnectorType,
    'microsoft.graph.mobileThreatPartnerTenantState': mobileThreatPartnerTenantState,
    'microsoft.graph.deviceManagementPartnerTenantState': deviceManagementPartnerTenantState,
    'microsoft.graph.deviceManagementPartnerAppType': deviceManagementPartnerAppType,
    'microsoft.graph.actionState': actionState,
    'microsoft.graph.managedDeviceOwnerType': managedDeviceOwnerType,
    'microsoft.graph.complianceState': complianceState,
    'microsoft.graph.managementAgentType': managementAgentType,
    'microsoft.graph.deviceEnrollmentType': deviceEnrollmentType,
    'microsoft.graph.deviceRegistrationState': deviceRegistrationState,
    'microsoft.graph.deviceManagementExchangeAccessState': deviceManagementExchangeAccessState,
    'microsoft.graph.deviceManagementExchangeAccessStateReason': deviceManagementExchangeAccessStateReason,
    'microsoft.graph.managedDevicePartnerReportedHealthState': managedDevicePartnerReportedHealthState,
    'microsoft.graph.deviceManagementSubscriptionState': deviceManagementSubscriptionState,
    'microsoft.graph.managedAppDataStorageLocation': managedAppDataStorageLocation,
    'microsoft.graph.managedAppDataTransferLevel': managedAppDataTransferLevel,
    'microsoft.graph.managedAppClipboardSharingLevel': managedAppClipboardSharingLevel,
    'microsoft.graph.managedAppPinCharacterSet': managedAppPinCharacterSet,
    'microsoft.graph.managedAppDataEncryptionType': managedAppDataEncryptionType,
    'microsoft.graph.windowsInformationProtectionEnforcementLevel': windowsInformationProtectionEnforcementLevel,
    'microsoft.graph.windowsInformationProtectionPinCharacterRequirements': windowsInformationProtectionPinCharacterRequirements,
    'microsoft.graph.managedAppFlaggedReason': managedAppFlaggedReason,
    'microsoft.graph.notificationTemplateBrandingOptions': notificationTemplateBrandingOptions,
    'microsoft.graph.remoteAssistanceOnboardingStatus': remoteAssistanceOnboardingStatus,
    'microsoft.graph.deviceEnrollmentFailureReason': deviceEnrollmentFailureReason,
    'microsoft.graph.applicationType': applicationType,
    'microsoft.graph.plannerPreviewType': plannerPreviewType,
    'microsoft.graph.operationStatus': operationStatus,
    'microsoft.graph.onenotePatchInsertPosition': onenotePatchInsertPosition,
    'microsoft.graph.onenotePatchActionType': onenotePatchActionType,
    'microsoft.graph.onenoteSourceService': onenoteSourceService,
    'microsoft.graph.onenoteUserRole': onenoteUserRole,
    'microsoft.graph.dataPolicyOperationStatus': dataPolicyOperationStatus,
    'microsoft.graph.status': status,
    'microsoft.graph.alertFeedback': alertFeedback,
    'microsoft.graph.alertSeverity': alertSeverity,
    'microsoft.graph.alertStatus': alertStatus,
    'microsoft.graph.connectionDirection': connectionDirection,
    'microsoft.graph.connectionStatus': connectionStatus,
    'microsoft.graph.emailRole': emailRole,
    'microsoft.graph.fileHashType': fileHashType,
    'microsoft.graph.logonType': logonType,
    'microsoft.graph.processIntegrityLevel': processIntegrityLevel,
    'microsoft.graph.registryHive': registryHive,
    'microsoft.graph.registryOperation': registryOperation,
    'microsoft.graph.registryValueType': registryValueType,
    'microsoft.graph.securityNetworkProtocol': securityNetworkProtocol,
    'microsoft.graph.userAccountSecurityType': userAccountSecurityType,
    'microsoft.graph.callDirection': callDirection,
    'microsoft.graph.callState': callState,
    'microsoft.graph.changeType': changeType,
    'microsoft.graph.mediaDirection': mediaDirection,
    'microsoft.graph.mediaState': mediaState,
    'microsoft.graph.modality': modality,
    'microsoft.graph.rejectReason': rejectReason,
    'microsoft.graph.screenSharingRole': screenSharingRole,
    'microsoft.graph.tone': tone,
    'microsoft.graph.teamVisibilityType': teamVisibilityType,
    'microsoft.graph.clonableTeamParts': clonableTeamParts,
    'microsoft.graph.giphyRatingType': giphyRatingType,
    'microsoft.graph.teamsAsyncOperationType': teamsAsyncOperationType,
    'microsoft.graph.teamsAsyncOperationStatus': teamsAsyncOperationStatus,
    'microsoft.graph.teamsAppDistributionMethod': teamsAppDistributionMethod
  },
  models: {
    
  },
  collections: {
    
  }
}