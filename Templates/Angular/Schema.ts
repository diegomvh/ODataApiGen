import { SchemaConfig } from 'angular-odata';

//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

export const {{Name}} = {
  namespace: "{{Namespace}}",
  enums: [{% for config in EnumConfigs %}{{config.Name}}{% unless forloop.last %},
    {% endunless %}{% endfor %}],
  entities: [{% for config in EntityConfigs %}{{config.Name}}{% unless forloop.last %},
    {% endunless %}{% endfor %}],
  callables: [{% for config in CallablesConfigs %}{
    name: '{{config.Name}}',{% if config.HasPath %}
    path: "{{config.Path}}",{% endif %}
    bound: {{config.Bound}},
    composable: {{config.Composable}},{% if config.HasParameters %}
    parameters: { {{ config.Parameters | parameters }} },{% endif %}{% if config.Return != null %}
    return: "{{config.Return}}"{% endif %}
  }{% unless forloop.last %}, {% endunless %}{% endfor %}],
  containers: [{% for container in Containers %}{{container.Name}}{% unless forloop.last %},
    {% endunless %}{% endfor %}]
} as SchemaConfig;