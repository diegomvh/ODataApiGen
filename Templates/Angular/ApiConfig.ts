import { ApiConfig, EDM_PARSERS } from 'angular-odata';

//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

export const {{Name}} = {
  name: '{{Package.Name}}',
  serviceRootUrl: '{{Package.ServiceRootUrl}}',
  creation: new Date('{{Package.Creation | date: "o"}}'),
  options: {
    version: '{{Package.Version}}'
  },
  schemas: [
    {% for schema in Package.Schemas %}{{schema.Name}}{% unless forloop.last %},
    {% endunless %}{% endfor %}
  ],
  parsers: EDM_PARSERS
} as ApiConfig;