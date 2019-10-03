{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}

export enum {{Name}} {
    {% for memebr in members %}{{member}}{% endfor %}
}
