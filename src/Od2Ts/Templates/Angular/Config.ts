{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}

export const {{Name}} = {
  baseUrl: '{{Package.BaseUrl}}',
  metadataUrl: '{{Package.MetadataUrl}}',
  withCredentials: {{Package.WithCredentials}},
  creation: '{{Package.Creation | date: "o"}}',
  version: '{{Package.Version}}'
}
