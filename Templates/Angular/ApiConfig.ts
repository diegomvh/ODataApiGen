import { ApiConfig } from 'angular-odata';

{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}
export const {{Name}} = {
  type: "{{ContainerType}}",
  annotations: {{Annotations}},
} as ApiConfig;