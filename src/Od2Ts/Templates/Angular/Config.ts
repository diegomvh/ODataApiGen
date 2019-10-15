import { ODataConfig } from 'angular-odata';

{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}
export const {{Name}}: ODataConfig = {
  baseUrl: '{{Package.BaseUrl}}',
  metadataUrl: '{{Package.MetadataUrl}}',
  withCredentials: {{Package.WithCredentials}},
  creation: new Date('{{Package.Creation | date: "o"}}'),
  version: '{{Package.Version}}',
  enums: {
    {% for enum in Enums %}{{enum}}{% unless forloop.last %},
    {% endunless %}{% endfor %}},
  models: {
    {% for model in Models %}{{model}}{% unless forloop.last %},
    {% endunless %}{% endfor %}},
  collections: {
    {% for col in Collections %}{{col}}{% unless forloop.last %},
    {% endunless %}{% endfor %}},
  schemas: {
    {% for schema in Schemas %}{{schema}}{% unless forloop.last %},
    {% endunless %}{% endfor %}}
}