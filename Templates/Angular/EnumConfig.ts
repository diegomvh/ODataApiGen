import { EnumConfig } from 'angular-odata';

//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

export const {{Name}} = {
  name: "{{EnumName}}",{% if Flags %}
  flags: true,{% endif %}
  members: {{EnumName}}
} as EnumConfig<{{EnumEnum}}>;