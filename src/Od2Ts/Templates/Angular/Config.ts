import { ODataConfig } from 'angular-odata';

{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}
export const {{Name}}: ODataConfig = {
  baseUrl: '{{Package.BaseUrl}}',
  metadataUrl: '{{Package.MetadataUrl}}',
  withCredentials: {{Package.WithCredentials}},
  creation: new Date('{{Package.Creation | date: "o"}}'),
  version: '{{Package.Version}}',
  types: {
    {% for type in Types %}{{type}}{% unless forloop.last %},
    {% endunless %}{% endfor %}
  }
}