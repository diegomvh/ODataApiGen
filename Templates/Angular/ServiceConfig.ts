import { ServiceConfig } from 'angular-odata';

{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}
export const {{Name}} = {
  type: "{{ServiceType}}",
  annotations: {{Annotations}}
} as ServiceConfig;