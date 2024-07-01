//#region ODataApiGen ApiConfig
export const {{Name}} = {
  EnumTypes: {
    {% for config in EnumTypeConfigs %}{{config.EnumName}}: '{{config.Type}}'{% unless forloop.last %},
    {% endunless %}{% endfor %}
  },
  StructuredTypes: {
    {% for config in StructuredTypeConfigs %}{{config.EntityName}}: '{{config.Type}}'{% unless forloop.last %},
    {% endunless %}{% endfor %}
  },
  EntitySets: {
    {% for config in EntitySetConfigs %}{{config.EntitySetName}}: '{{config.EntityType}}'{% unless forloop.last %},
    {% endunless %}{% endfor %}
  }
};
//#endregion