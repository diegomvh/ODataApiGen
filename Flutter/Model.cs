using ODataApiGen.Models;
using DotLiquid;
using ODataApiGen.Abstracts;

namespace ODataApiGen.Flutter
{
    public class ModelField : ILiquidizable
  {
    protected Models.Property Value { get; set; }
    protected Flutter.StructuredType Structured { get; set; }
    public ModelField(ODataApiGen.Models.Property prop, Flutter.StructuredType structured)
    {
      this.Value = prop;
      this.Structured = structured;
    }
    public string Name
    {
      get
      {
        var required = !(Value is NavigationProperty || Value.Nullable);
        var name = Utils.IsValidTypeScrtiptName(Value.Name) ? Value.Name : $"\"{Value.Name}\"";
        return name + (!required ? "?" : "!");
        /*
        var navigation = Value is NavigationProperty;
        var name = Utils.IsValidTypeScrtiptName(Value.Name) ? Value.Name : $"\"{Value.Name}\"";
        return name + (navigation ? "?" : "!");
        */
      }
    }

    public string Type
    {
      get
      {
        var pkg = Program.Package as Flutter.Package;
        var nullable = Value.Nullable;
        var type = "any";
        if (this.Value.IsEnumType)
        {
          var e = pkg.FindEnum(this.Value.Type);
          type = e.ImportedName;
        }
        else if (Value.IsEdmType)
        {
          type = this.Structured.ToTypescriptType(Value.Type);
          type = type + (Value.IsCollection ? "[]" : "");
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
        /*
        if (nullable)
        {
          type = type + " | null";
        }
        */
        return type;
      }
    }
    public string Resource()
    {
      var pkg = Program.Package as Flutter.Package;
      var resourceName = $"${this.Value.Name}";
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
        var prop = this.Value;
        // resource
        return $@"public {resourceName}() {{
    return this.property<{this.Type}>('{this.Value.Name}');
  }}";
      }
    }
    public string SetterReference()
    {
      var pkg = Program.Package as Flutter.Package;
      var nav = this.Value as NavigationProperty;
      var name = this.Value.Name.Substring(0, 1).ToUpper() + this.Value.Name.Substring(1);
      var setterName = $"set{name}";
      var entity = (this.Value.Type != null) ?
          pkg.FindEntity(this.Value.Type) :
          pkg.FindEntity(nav.ToEntityType);
      // setter
      return $@"public {setterName}(model: {this.Type} | null, options?: ODataOptions) {{
    return this.setReference<{entity.ImportedName}>('{this.Value.Name}', model, options);
  }}";
    }
    public string GetterReference()
    {
      var pkg = Program.Package as Flutter.Package;
      var nav = this.Value as NavigationProperty;
      var name = this.Value.Name.Substring(0, 1).ToUpper() + this.Value.Name.Substring(1);
      var getterName = $"get{name}";
      var entity = (this.Value.Type != null) ?
          pkg.FindEntity(this.Value.Type) :
          pkg.FindEntity(nav.ToEntityType);
      // setter
      return $@"public {getterName}() {{
    return this.getReference<{entity.ImportedName}>('{this.Value.Name}') as {this.Type};
  }}";
    }
    public string GetterValue()
    {
      var pkg = Program.Package as Flutter.Package;
      var prop = this.Value as Property;
      var name = this.Value.Name.Substring(0, 1).ToUpper() + this.Value.Name.Substring(1);
      var getterName = $"get{name}";
      // getter
      return $@"public {getterName}(options?: ODataOptions) {{
    return this.getValue<{this.Type}>('{this.Value.Name}', options) as Observable<{this.Type}>;
  }}";
    }
    public object ToLiquid()
    {
      return new
      {
        Name = this.Name,
        Type = this.Type,
        Resource = this.Resource(),
        Setter = this.NeedReference ? this.SetterReference() : "",
        Getter = this.NeedReference ? this.GetterReference() : this.GetterValue()
      };
    }
    public bool IsGeo => this.Value.Type.StartsWith("Edm.Geography") || this.Value.Type.StartsWith("Edm.Geometry");
    public bool NeedReference => this.Value is NavigationProperty;
  }
  public class Model : StructuredType
  {
    public Flutter.Entity Entity { get; private set; }

    public Model(Models.StructuredType type, Flutter.Entity entity, ApiOptions options) : base(type, options)
    {
      this.Entity = entity;
    }
    public Flutter.Collection Collection { get; private set; }

    public void SetCollection(Collection collection)
    {
      this.Collection = collection;
    }
    public override string FileName => this.EdmStructuredType.Name.ToLower() + ".model";
    public override string Name => Utils.ToDartName(this.EdmStructuredType.Name, DartElement.Class) + "Model";
    public override IEnumerable<string> ImportTypes
    {
      get
      {
        var list = new List<string> {
                    this.EdmStructuredType.FullName
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
          list.AddRange(service.NavigationPropertyBindings.Select(b => b.PropertyType).Where(t => t != null).Select(t => t.FullName));
        }

        return list.Where(t => !String.IsNullOrWhiteSpace(t) && !t.StartsWith("Edm.")).Distinct();
      }
    }
    public IEnumerable<Flutter.ModelField> Fields
    {
      get
      {
        var props = this.EdmStructuredType.Properties.ToList();
        if (this.EdmStructuredType is EntityType)
          props.AddRange((this.EdmStructuredType as EntityType).NavigationProperties);
        return props.Select(prop => new Flutter.ModelField(prop, this));
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
    public IEnumerable<Flutter.ModelField> GeoFields => this.Fields.Where(p => p.IsGeo);
    public IEnumerable<Flutter.ModelField> SetterFields => this.Fields.Where(p => p.NeedReference);
    public IEnumerable<Flutter.ModelField> GetterFields => this.Fields.Where(p => p.NeedReference);
    public bool HasGeoFields => this.Options.GeoJson && this.GeoFields.Count() > 0;
    public override object ToLiquid()
    {
      return new
      {
        Name = this.ImportedName,
        Type = this.Type,
        Entity = new
        {
          Name = this.Entity.ImportedName
        }
      };
    }
  }
}