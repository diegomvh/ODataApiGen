{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}
{% capture splitNewLine %},
  {% endcapture %}
export const ISFLAGS_{{Name | upcase}} = {{Flags}};
export enum {{Name}} {
  {{ Members | join: splitNewLine}}
}
