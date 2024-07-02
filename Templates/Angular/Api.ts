//#region ODataApiGen ApiConfig
export const {{Name}} = {
  EnumTypes: {
    {% for enum in EnumTypes %}{{enum.Name}}: '{{enum.FullName}}'{% unless forloop.last %},
    {% endunless %}{% endfor %}
  },
  ComplexTypes: {
    {% for complex in ComplexTypes %}{{complex.Name}}: '{{complex.FullName}}'{% unless forloop.last %},
    {% endunless %}{% endfor %}
  },
  EntityTypes: {
    {% for entity in EntityTypes %}{{entity.Name}}: '{{entity.FullName}}'{% unless forloop.last %},
    {% endunless %}{% endfor %}
  },
  EntitySets: {
    {% for entitySet in EntitySets %}{{entitySet.Name}}: '{{entitySet.FullName}}'{% unless forloop.last %},
    {% endunless %}{% endfor %}
  },
  Singletons: {
    {% for singleton in Singletons %}{{singleton.Name}}: '{{singleton.FullName}}'{% unless forloop.last %},
    {% endunless %}{% endfor %}
  },
  Functions: {
    {% for function in Functions %}{{function.Name}}: '{{function.FullName}}'{% unless forloop.last %},
    {% endunless %}{% endfor %}
  },
  Actions: {
    {% for action in Actions %}{{action.Name}}: '{{action.FullName}}'{% unless forloop.last %},
    {% endunless %}{% endfor %}
  }
};
//#endregion