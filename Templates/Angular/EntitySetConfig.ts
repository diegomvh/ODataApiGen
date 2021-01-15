import { EntitySetConfig } from 'angular-odata';

//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

//#region ODataApi EntitySetConfig
export const {{Name}} = {
  name: "{{EntitySetName}}",
  entityType: "{{EntityType}}",
  service: {{Service.Name}},
  annotations: {{Annotations}}
} as EntitySetConfig;
//#endregion