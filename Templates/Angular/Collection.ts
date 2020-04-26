{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}

export class {{Name}}<E extends {{Model.Interface.Name}}, M extends {{Model.Name}}<E>> extends {{BaseCollection.Name}}<E, M> {}
