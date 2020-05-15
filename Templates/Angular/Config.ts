//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

export const {{Name}} = {
  baseUrl: '{{Package.BaseUrl}}',
  metadataUrl: '{{Package.MetadataUrl}}',
  withCredentials: {{Package.WithCredentials}},
  stringAsEnum: {{Package.StringAsEnum}},
  creation: new Date('{{Package.Creation | date: "o"}}'),
  version: '{{Package.Version}}',
  apis: {
    {% for api in Apis %}{{api}}{% unless forloop.last %},
    {% endunless %}{% endfor %}},
  enums: {
    {% for enum in Enums %}{{enum}}{% unless forloop.last %},
    {% endunless %}{% endfor %}},
  entities: {
    {% for entity in Entities %}{{entity}}{% unless forloop.last %},
    {% endunless %}{% endfor %}},
  services: {
    {% for service in Services %}{{service}}{% unless forloop.last %},
    {% endunless %}{% endfor %}}
}