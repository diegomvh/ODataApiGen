import { EnumConfig } from 'angular-odata';

//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

export const {{Name}} = {
  name: "{{EdmEnumName}}",{% if Flags %}
  flags: true,{% endif %}
  members: {{EnumName}}
} as EnumConfig<{{EnumName}}>;