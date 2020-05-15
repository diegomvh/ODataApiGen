import { ServiceConfig } from 'angular-odata';

//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

export const {{Name}} = {
  type: "{{ServiceType}}",
  annotations: {{Annotations}}
} as ServiceConfig;