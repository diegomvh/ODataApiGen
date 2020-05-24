//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

export const {{Name}} = {
  serviceRootUrl: '{{Package.ServiceRootUrl}}',
  metadataUrl: '{{Package.MetadataUrl}}',
  creation: new Date('{{Package.Creation | date: "o"}}'),
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