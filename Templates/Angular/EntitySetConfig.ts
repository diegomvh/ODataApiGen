import { EntitySetConfig } from 'angular-odata';

//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

export const {{Name}} = {
  name: "{{ServiceName}}",
  annotations: {{Annotations}}
} as EntitySetConfig;