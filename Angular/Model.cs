using ODataApiGen.Models;
using DotLiquid;
using ODataApiGen.Abstracts;

namespace ODataApiGen.Angular
{
    public class ModelField : ILiquidizable
  {
    protected Models.Property Value { get; set; }
    protected Angular.StructuredType Structured { get; set; }
    public ModelField(ODataApiGen.Models.Property prop, Angular.StructuredType structured)
    {
      this.Value = prop;
      this.Structured = structured;
    }
    public string Name
    {
      get
      {
        var required = !(Value is NavigationProperty || Value.Nullable);
        var name = Utils.IsValidTypescriptName(Value.Name) ? Value.Name : $"\"{Value.Name}\"";
        return name + (!required ? "?" : "!");
      }
    }

    public string Type
    {
      get
      {
        var pkg = Program.Package as Angular.Package;
        var type = "any";
        if (this.Value.IsEnumType)
        {
          var e = pkg.FindEnum(this.Value.Type);
          type = e.ImportedName;
          type = type + (Value.IsCollection ? "[]" : "");
          //if (Value.Nullable) { type = type + " | null"; }
        }
        else if (Value.IsEdmType)
        {
          type = this.Structured.ToTypescriptType(Value.Type);
          type = type + (Value.IsCollection ? "[]" : "");
          //if (type != "string" && Value.Nullable && !Value.IsCollection) { type = type + " | null"; }
        }
        else if (this.Value.Type != null)
        {
          if (Value.IsCollection)
          {
            var entity = pkg.FindEntity(this.Value.Type);
            var model = pkg.FindModel(this.Value.Type);
            var collection = pkg.FindCollection(this.Value.Type);
            type = $"{collection.ImportedName}<{entity.ImportedName}, {model.ImportedName}<{entity.ImportedName}>>";
          }
          else
          {
            var entity = pkg.FindEntity(this.Value.Type);
            var model = pkg.FindModel(this.Value.Type);
            type = $"{model.ImportedName}<{entity.ImportedName}>";
          }
        }
        else if (this.Value is NavigationProperty)
        {
          var nav = this.Value as NavigationProperty;
          if (nav.Many)
          {
            var entity = pkg.FindEntity(nav.ToEntityType);
            var model = pkg.FindModel(nav.ToEntityType);
            var collection = pkg.FindCollection(nav.ToEntityType);
            type = $"{collection.ImportedName}<{entity.ImportedName}, {model.ImportedName}<{entity.ImportedName}>>";
          }
          else
          {
            var entity = pkg.FindEntity(nav.ToEntityType);
            var model = pkg.FindModel(nav.ToEntityType);
            type = $"{model.ImportedName}<{entity.ImportedName}>";
          }
        }
        return type;
      }
    }

    public string Resource()
    {
      var pkg = Program.Package as Angular.Package;
      var resourceName = $"$${this.Value.Name}";
      if (this.Value is NavigationProperty)
      {
        var nav = this.Value as NavigationProperty;
        var entity = (this.Value.Type != null) ?
            pkg.FindEntity(this.Value.Type) :
            pkg.FindEntity(nav.ToEntityType);
        // resource
        return $@"public {resourceName}() {{
    return this.navigationProperty<{entity.ImportedName}>('{this.Value.Name}');
  }}";
      }
      else
      {
        // resource
        return $@"public {resourceName}() {{
    return this.property<{this.Type}>('{this.Value.Name}');
  }}";
      }
    }

    public string GetAttribute()
    {
      var pkg = Program.Package as Angular.Package;
      var getterName = $"${this.Value.Name}";
      if (this.Value is NavigationProperty)
      {
        var nav = this.Value as NavigationProperty;
        var entity = (this.Value.Type != null) ?
          pkg.FindEntity(this.Value.Type) :
            pkg.FindEntity(nav.ToEntityType);
        return $@"public {getterName}() {{
    return this.getAttribute<{entity.ImportedName}>('{this.Value.Name}') as {this.Type};
  }}";
      }
      else
      {
        return $@"public {getterName}() {{
    return this.getAttribute<{this.Type}>('{this.Value.Name}') as {this.Type};
  }}";
      }
    }

    public string FetchAttribute()
    {
      var pkg = Program.Package as Angular.Package;
      var fetchName = $"{this.Value.Name}$";
      if (this.Value is NavigationProperty)
      {
        var nav = this.Value as NavigationProperty;
        var entity = (this.Value.Type != null) ?
            pkg.FindEntity(this.Value.Type) :
            pkg.FindEntity(nav.ToEntityType);
        return $@"public {fetchName}(options?: ODataQueryArgumentsOptions<{entity.ImportedName}>) {{
      return this.fetchAttribute<{entity.ImportedName}>('{this.Value.Name}', options) as Observable<{this.Type}>;
    }}";
      }
      else
      {
        return $@"public {fetchName}(options?: ODataQueryArgumentsOptions<{this.Type}>) {{
    return this.fetchAttribute<{this.Type}>('{this.Value.Name}', options) as Observable<{this.Type}>;
  }}";
      }
    }
    public string SetterReference()
    {
      var pkg = Program.Package as Angular.Package;
      var nav = this.Value as NavigationProperty;
      var setterName = $"{this.Value.Name}$$";
      var entity = (this.Value.Type != null) ?
          pkg.FindEntity(this.Value.Type) :
          pkg.FindEntity(nav.ToEntityType);
      // setter
      return $@"public {setterName}(model: {this.Type} | null, options?: ODataOptions) {{
    return this.setReference<{entity.ImportedName}>('{this.Value.Name}', model, options);
  }}";
    }
    public object ToLiquid()
    {
      return new
      {
        Name = this.Name,
        Type = this.Type,
        Resource = this.Resource(),
        Getter = this.GetAttribute(),
        Setter = this.NeedReference ? this.SetterReference() : "",
        Fetch = this.FetchAttribute()
      };
    }
    public bool IsGeo => this.Value.Type.StartsWith("Edm.Geography") || this.Value.Type.StartsWith("Edm.Geometry");
    public bool NeedReference => this.Value is NavigationProperty;
  }
  public class Model : StructuredType
  {
    public Angular.Entity Entity { get; private set; }

    public Model(Models.StructuredType type, Angular.Entity entity, ApiOptions options) : base(type, options)
    {
      this.Entity = entity;
    }
    public Angular.Collection Collection { get; private set; }

    public void SetCollection(Collection collection)
    {
      this.Collection = collection;
    }
    public override string FileName => this.EdmStructuredType.Name.ToLower() + ".model";
    public override string Name => Utils.ToTypescriptName(this.EdmStructuredType.Name, TypeScriptElement.Class) + "Model";
    public override IEnumerable<string> ImportTypes
    {
      get
      {
        var list = new List<string> {
                    this.EdmStructuredType.NamespaceQualifiedName
                };
        list.AddRange(this.EdmStructuredType.Properties.Select(a => a.Type));
        if (this.EdmEntityType != null)
        {
          list.AddRange(this.EdmEntityType.Properties.Select(a => a.Type));
          list.AddRange(this.EdmEntityType.NavigationProperties.Select(a => a.Type));
          list.AddRange(this.EdmEntityType.NavigationProperties.Select(a => a.ToEntityType));
          list.AddRange(this.EdmEntityType.Actions.SelectMany(a => this.CallableNamespaces(a)));
          list.AddRange(this.EdmEntityType.Functions.SelectMany(a => this.CallableNamespaces(a)));
        }
        var service = Program.Metadata.EntitySets.FirstOrDefault(s => this.EdmStructuredType.IsTypeOf(s.EntityType));
        if (service != null)
        {
          list.AddRange(service.NavigationPropertyBindings.Select(b => b.NavigationProperty.Type));
          list.AddRange(service.NavigationPropertyBindings.Select(b => b.PropertyType).Where(t => t != null).Select(t => t.NamespaceQualifiedName));
        }

        return list.Where(t => !String.IsNullOrWhiteSpace(t) && !t.StartsWith("Edm.")).Distinct();
      }
    }
    public IEnumerable<Angular.ModelField> Fields
    {
      get
      {
        var props = this.EdmStructuredType.Properties.ToList();
        if (this.EdmStructuredType is EntityType)
          props.AddRange((this.EdmStructuredType as EntityType).NavigationProperties);
        return props.Select(prop => new Angular.ModelField(prop, this));
      }
    }
    public IEnumerable<string> Actions
    {
      get
      {
        if (this.EdmEntityType != null)
        {
          var modelActions = this.EdmEntityType.Actions.Where(a => !a.IsCollection);
          return modelActions.Count() > 0 ? this.RenderCallables(modelActions) : Enumerable.Empty<string>();
        }
        return Enumerable.Empty<string>();
      }
    }
    public IEnumerable<string> Functions
    {
      get
      {
        if (this.EdmEntityType != null)
        {
          var modelFunctions = this.EdmEntityType.Functions.Where(a => !a.IsCollection);
          return modelFunctions.Count() > 0 ? this.RenderCallables(modelFunctions) : Enumerable.Empty<string>();
        }
        return Enumerable.Empty<string>();
      }
    }
    public IEnumerable<string> Navigations
    {
      get
      {
        var service = Program.Metadata.EntitySets.FirstOrDefault(s => this.EdmStructuredType.IsTypeOf(s.EntityType));
        if (service != null)
        {
          var properties = new List<NavigationProperty>();
          var entity = this.EdmEntityType;
          while (true)
          {
            properties.AddRange(entity.NavigationProperties);
            if (String.IsNullOrEmpty(entity.BaseType))
              break;
            entity = Program.Metadata.FindEntityType(entity.BaseType);
          }
          var bindings = service.NavigationPropertyBindings
              .Where(binding => properties.All(n => n.Name != binding.NavigationProperty.Name));
          return this.RenderNavigationPropertyBindings(bindings);
        }
        return Enumerable.Empty<string>();
      }
    }
    public IEnumerable<Angular.ModelField> GeoFields => this.Fields.Where(p => p.IsGeo);
    public IEnumerable<Angular.ModelField> SetterFields => this.Fields.Where(p => p.NeedReference);
    public IEnumerable<Angular.ModelField> GetterFields => this.Fields.Where(p => p.NeedReference);
    public bool HasGeoFields => this.Options.GeoJson && this.GeoFields.Count() > 0;
    public override object ToLiquid()
    {
      return new
      {
        Name = this.ImportedName,
        this.NamespaceQualifiedName,
        Entity = new
        {
          Name = this.Entity.ImportedName
        }
      };
    }
  }
}