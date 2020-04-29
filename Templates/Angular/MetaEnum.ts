import { MetaEnum } from 'angular-odata';

{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}
export const {{Name}} = {
  type: "{{EnumType}}",{% if Flags %}
  flags: true,{% endif %}
  members: {{EnumName}}
} as MetaEnum<{{EnumName}}>;