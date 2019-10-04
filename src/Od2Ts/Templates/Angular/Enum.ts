{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}
{% capture splitNewLine %},
  {% endcapture %}
export enum {{Name}} {
  {{ Members | join: splitNewLine}}
}
