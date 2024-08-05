using ODataApiGen.Models;
using ODataApiGen.Abstracts;

namespace ODataApiGen.Angular
{
    public abstract class StructuredType : AngularRenderable, DotLiquid.ILiquidizable
  {
    public EntityType EdmEntityType => this.EdmStructuredType as Models.EntityType;
    public Models.StructuredType EdmStructuredType { get; private set; }
    public StructuredType(Models.StructuredType type, ApiOptions options) : base(options)
    {
      EdmStructuredType = type;
    }

    public StructuredType Base { get; private set; }
    public void SetBase(StructuredType b)
    {
      this.Base = b;
    }

    // Imports
    public override IEnumerable<string> ImportTypes
    {
      get
      {
        var list = new List<string>();
        if (this.EdmEntityType != null)
        {
          list.AddRange((this.EdmEntityType as EntityType).Properties.Select(a => a.Type));
          list.AddRange((this.EdmEntityType as EntityType).NavigationProperties.Select(a => a.Type));
          list.AddRange((this.EdmEntityType as EntityType).NavigationProperties.Select(a => a.ToEntityType));
          list.AddRange(this.EdmEntityType.Actions.Select(a => a.Type));
          list.AddRange(this.EdmEntityType.Functions.Select(a => a.Type));
        }
        /*For Not-EDM types (e.g. enums with namespaces, complex types*/
        list.AddRange(this.EdmStructuredType.Properties
            .Where(a => !a.IsEdmType)
            .Select(a => a.Type));
        if (this.Base != null)
          list.Add(this.Base.EdmStructuredType.NamespaceQualifiedName);
        return list.Where(t => !String.IsNullOrWhiteSpace(t) && !t.StartsWith("Edm.")).Distinct();
      }
    }
    public override string Directory => this.EdmStructuredType.Namespace.Replace('.', Path.DirectorySeparatorChar);
    public string EntitySetName => Program.Metadata.Schemas.SelectMany(s => s.EntityContainers).SelectMany(c => c.EntitySets).FirstOrDefault(s => s.EntityType == this.EdmStructuredType.NamespaceQualifiedName)?.Name;
    public string FullName => this.EdmStructuredType.NamespaceQualifiedName; 
    public bool OpenType => this.EdmStructuredType.OpenType;
    public override IEnumerable<Import> Imports => GetImportRecords();

    protected IEnumerable<string> RenderCallables(IEnumerable<Callable> allCallables)
    {
      var names = allCallables.GroupBy(c => c.Name).Select(c => c.Key);
      foreach (var name in names)
      {
        var callables = allCallables.Where(c => c.Name == name);
        var overload = callables.Count() > 1;
        var callable = callables.FirstOrDefault();
        var methodName = name.Substring(0, 1).ToLower() + name.Substring(1);

        var callableNamespaceQualifiedName = callable.IsBound ? $"{callable.Namespace}.{callable.Name}" : callable.Name;

        var typescriptType = this.ToTypescriptType(callable.ReturnType);
        var callableReturnType = String.IsNullOrEmpty(callable.ReturnType) ?
            "" :
        callable.IsEdmReturnType ?
            $" as Observable<{typescriptType}>" :
        callable.IsEnumReturnType ?
            $" as Observable<{typescriptType}>" :
        callable.ReturnsCollection ?
            $" as Observable<{typescriptType}Collection<{typescriptType}, {typescriptType}Model<{typescriptType}>>>" :
            $" as Observable<{typescriptType}Model<{typescriptType}>>";

        var parameters = new List<Models.Parameter>();
        var optionals = new List<string>();
        foreach (var cal in callables)
        {
          foreach (var param in cal.Parameters)
          {
            if (parameters.All(p => p.Name != param.Name))
              parameters.Add(param);
            if (optionals.All(o => o != param.Name) && !callables.All(c => c.Parameters.Any(p => p.Name == param.Name)))
              optionals.Add(param.Name);
            if (param.HasAnnotation("Org.OData.Core.V1.OptionalParameter")) 
              optionals.Add(param.Name);
          }
        }
        parameters = parameters.Where(p => !p.IsBinding).GroupBy(p => p.Name).Select(g => g.First()).ToList();

        var arguments = parameters
          .Where(p => !optionals.Contains(p.Name))
          .Union(parameters.Where(p => optionals.Contains(p.Name)))
          .Select(p =>
            $"{p.Name}" +
            (optionals.Any(o => o == p.Name) ? "?" : "") +
            $": {this.ToTypescriptType(p.Type)}" +
            (p.IsCollection ? "[]" : ""));

        var args = new List<string>(arguments);
        if (callable.IsEdmReturnType || callable.IsEnumReturnType) {
          args.Add($"options?: ODataOptions & {{alias?: boolean}}");
        } else if (callable.Type == "Function") {
          args.Add($"options?: ODataFunctionOptions<{typescriptType}>");
        } else {
          args.Add($"options?: ODataActionOptions<{typescriptType}>");
        }

        var types = "null";
        if (parameters.Count() > 0)
        {
          types = $"{{{String.Join(", ", arguments)}}}";
        }

        var values = "null";
        if (parameters.Count() > 0)
        {
          values = $"{{{String.Join(", ", parameters.Select(p => p.Name))}}}";
        }

        var responseType = String.IsNullOrEmpty(callable.ReturnType) ?
            "none" :
        callable.IsEdmReturnType ?
            $"property" :
        callable.ReturnsCollection ?
            $"collection" :
            $"model";
        yield return $"public {methodName}({String.Join(", ", args)}) {{" +
            $"\n    return this.call{callable.Type}<{types}, {typescriptType}>('{callableNamespaceQualifiedName}', {values}, '{responseType}', options){callableReturnType};" +
            "\n  }";
      }
    }
    protected IEnumerable<string> RenderNavigationPropertyBindings(IEnumerable<Models.NavigationPropertyBinding> bindings)
    {
      var casts = new List<string>();
      foreach (var binding in bindings)
      {
        var isCollection = binding.NavigationProperty.IsCollection;
        var nav = binding.NavigationProperty;
        var navEntity = nav.EntityType;
        var bindingEntity = binding.EntityType;
        var propertyEntity = binding.PropertyType;

        var entity = (Program.Package as Angular.Package).FindEntity(navEntity.NamespaceQualifiedName);
        if (propertyEntity != null && bindingEntity.IsBaseOf(propertyEntity) && bindingEntity.HierarchyLevelOf(propertyEntity) == 1)
        {
          var castName = $"as{propertyEntity.Name}";
          if (!casts.Contains(propertyEntity.NamespaceQualifiedName))
          {
            // Cast
            entity = (Program.Package as Angular.Package).FindEntity(propertyEntity.NamespaceQualifiedName);
            yield return $@"public {castName}() {{
    return this.cast<{entity.ImportedName}, {entity.Name}Model<{entity.ImportedName}>>('{propertyEntity.NamespaceQualifiedName}');
  }}";
            casts.Add(propertyEntity.NamespaceQualifiedName);
          }
        }
        else
        {
          //TODO collection and model name
          var returnType = isCollection ? $"ODataCollection<{entity.ImportedName}, ODataModel<{entity.ImportedName}>>" : $"ODataModel<{entity.ImportedName}>";
          var responseType = isCollection ? $"collection" : $"model";
          var methodName = $"as{propertyEntity.Name}" + nav.Name.Substring(0, 1).ToUpper() + nav.Name.Substring(1);
          var castEntity = (Program.Package as Angular.Package).FindEntity(propertyEntity.NamespaceQualifiedName);

          // Navigation
          yield return $@"public {methodName}(options?: ODataQueryArgumentsOptions<{entity.ImportedName}>) {{
    return this.fetchNavigationProperty<{entity.ImportedName}>('{binding.Path}', '{responseType}', options) as Observable<{returnType}>;
  }}";
        }
      }
    }
    public abstract object ToLiquid();
  }
}