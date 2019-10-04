import { NgModule } from '@angular/core';
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}

@NgModule({
  providers: [
    {% for service in Services %}{{service.Name}}{% unless forloop.last %},
    {% endunless %}{% endfor %}
  ]
})
export class {{Name}} { }