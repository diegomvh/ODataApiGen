import { NgModule } from '@angular/core';
import { InvitationsService } from './microsoft/graph/invitations.service';
import { UsersService } from './microsoft/graph/users.service';
import { IdentityProvidersService } from './microsoft/graph/identityproviders.service';
import { DirectoryObjectsService } from './microsoft/graph/directoryobjects.service';
import { DevicesService } from './microsoft/graph/devices.service';
import { DomainsService } from './microsoft/graph/domains.service';
import { DomainDnsRecordsService } from './microsoft/graph/domaindnsrecords.service';
import { GroupsService } from './microsoft/graph/groups.service';
import { DirectoryRolesService } from './microsoft/graph/directoryroles.service';
import { DirectoryRoleTemplatesService } from './microsoft/graph/directoryroletemplates.service';
import { OrganizationService } from './microsoft/graph/organization.service';
import { GroupSettingsService } from './microsoft/graph/groupsettings.service';
import { GroupSettingTemplatesService } from './microsoft/graph/groupsettingtemplates.service';
import { SubscribedSkusService } from './microsoft/graph/subscribedskus.service';
import { ContractsService } from './microsoft/graph/contracts.service';
import { WorkbooksService } from './microsoft/graph/workbooks.service';
import { DrivesService } from './microsoft/graph/drives.service';
import { SharesService } from './microsoft/graph/shares.service';
import { SitesService } from './microsoft/graph/sites.service';
import { SchemaExtensionsService } from './microsoft/graph/schemaextensions.service';
import { GroupLifecyclePoliciesService } from './microsoft/graph/grouplifecyclepolicies.service';
import { DataPolicyOperationsService } from './microsoft/graph/datapolicyoperations.service';
import { SubscriptionsService } from './microsoft/graph/subscriptions.service';
import { TeamsService } from './microsoft/graph/teams.service';


@NgModule({
  providers: [
    InvitationsService,
    UsersService,
    IdentityProvidersService,
    DirectoryObjectsService,
    DevicesService,
    DomainsService,
    DomainDnsRecordsService,
    GroupsService,
    DirectoryRolesService,
    DirectoryRoleTemplatesService,
    OrganizationService,
    GroupSettingsService,
    GroupSettingTemplatesService,
    SubscribedSkusService,
    ContractsService,
    WorkbooksService,
    DrivesService,
    SharesService,
    SitesService,
    SchemaExtensionsService,
    GroupLifecyclePoliciesService,
    DataPolicyOperationsService,
    SubscriptionsService,
    TeamsService
  ]
})
export class MsGraphModule { }