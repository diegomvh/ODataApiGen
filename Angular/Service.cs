using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotLiquid;
using ODataApiGen.Abstracts;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
  public abstract class Service : AngularRenderable, ILiquidizable
  {
    public Models.EntityType EdmEntityType => this.HasModel ? this.Model.EdmEntityType :
        this.HasEntity ? this.Entity.EdmEntityType :
        null;
    public Service(ApiOptions options) : base(options) { }

    public Angular.Entity Entity { get; private set; }
    public void SetEntity(Angular.Entity entity)
    {
      this.Entity = entity;
    }
    public bool HasEntity => this.Entity != null;
    public string EntityName => this.HasEntity ? this.Entity.ImportedName : String.Empty;
    public Angular.Model Model { get; private set; }
    public void SetModel(Angular.Model model)
    {
      this.Model = model;
    }
    public bool HasModel => this.Model != null;
    public string ModelName => this.HasModel ? this.Model.ImportedName : String.Empty;
    public Angular.Collection Collection { get; private set; }
    public void SetCollection(Angular.Collection collection)
    {
      this.Collection = collection;
    }
    public bool HasCollection => this.Collection != null;
    public string CollectionName => this.HasCollection ? this.Collection.ImportedName : String.Empty;
    public abstract string EntitySetName { get; }
    public abstract string EntityType { get; }
    public abstract IEnumerable<Models.Annotation> Annotations { get; }
    public override string Directory => this.Namespace.Replace('.', Path.DirectorySeparatorChar);
    protected IEnumerable<string> RenderCallables(IEnumerable<Callable> allCallables)
    {
      var names = allCallables.GroupBy(c => c.Name).Select(c => c.Key);
      foreach (var name in names)
      {
        var callables = allCallables.Where(c => c.Name == name);
        var overload = callables.Count() > 1;
        var callable = callables.FirstOrDefault();
        var methodName = name[0].ToString().ToLower() + name.Substring(1);
        var callMethodName = "call" + name[0].ToString().ToUpper() + name.Substring(1);

        var callableFullName = $"{callable.Namespace}.{callable.Name}";

        var typescriptType = this.ToTypescriptType(callable.ReturnType);
        var callableReturnType = String.IsNullOrEmpty(callable.ReturnType) ?
            "" :
        callable.IsEdmReturnType ?
            $" as Observable<ODataProperty<{typescriptType}>>" :
        callable.IsEnumReturnType ?
            $" as Observable<ODataProperty<{typescriptType}>>" :
        callable.ReturnsCollection ?
            $" as Observable<ODataEntities<{typescriptType}>>" :
            $" as Observable<ODataEntity<{typescriptType}>>";

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
          }
        }
        parameters = parameters.Where(p => !p.IsBinding).GroupBy(p => p.Name).Select(g => g.First()).ToList();

        var baseMethodName = !callable.IsBound ?
            $"client.{callable.Type.ToLower()}" :
            callable.IsCollection
            ? $"entities().{callable.Type.ToLower()}"
            : $"entity(key).{callable.Type.ToLower()}";

        var boundArgs = new List<string>();
        if (callable.IsBound && !callable.IsCollection)
          boundArgs.Add($"key: EntityKey<{EntityName}>");

        var args = new List<string>(boundArgs);

        var arguments = parameters.Select(p =>
            $"{p.Name}" +
            (optionals.Any(o => o == p.Name) ? "?" : "") +
            $": {this.ToTypescriptType(p.Type)}" +
            (p.IsCollection ? "[]" : ""));

        args.AddRange(arguments);
        args.Add($"options?: ODataQueryArgumentsOptions<{typescriptType}>");

        var type = "null";
        if (parameters.Count() > 0)
        {
          type = $"{{{String.Join(", ", arguments)}}}";
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
        callable.IsEnumReturnType ?
            $"property" :
        callable.ReturnsCollection ?
            $"entities" :
            $"entity";

        // Function
        yield return $"public {methodName}({String.Join(", ", boundArgs)}): OData{callable.Type}Resource<{type}, {typescriptType}> {{ " +
            $"\n    return this.{baseMethodName}<{type}, {typescriptType}>('{callableFullName}'{(!callable.IsBound ? ", this.apiNameOrEntityType" : "")});" +
            "\n  }";

        // Call
        yield return $"public {callMethodName}({String.Join(", ", args)}) {{" +
            $"\n    return this.call{callable.Type}<{type}, {typescriptType}>(" +
            $"\n      {values}, " +
            $"\n      this.{methodName}({(callable.IsBound && !callable.IsCollection ? "key" : "")}), " +
            $"\n      '{responseType}', options){callableReturnType};" +
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

        var entity = (Program.Package as Angular.Package).FindEntity(navEntity.FullName);
        if (propertyEntity != null && bindingEntity.IsBaseOf(propertyEntity))
        {
          var castName = $"as{propertyEntity.Name}";
          if (!casts.Contains(propertyEntity.FullName))
          {
            // Cast
            entity = (Program.Package as Angular.Package).FindEntity(propertyEntity.FullName);
            yield return $@"public {castName}(): ODataEntitySetResource<{entity.ImportedName}> {{
    return this.entities().cast<{entity.ImportedName}>('{propertyEntity.FullName}');
  }}";
            casts.Add(propertyEntity.FullName);
          }
        }
        else
        {
          //TODO collection and model name
          var returnType = isCollection ? $"ODataEntities<{entity.ImportedName}>" : $"ODataEntity<{entity.ImportedName}>";
          var responseType = isCollection ? $"entities" : $"entity";
          var navMethodName = nav.Name.Substring(0, 1).ToLower() + nav.Name.Substring(1);
          var fetchMethodName = "fetch" + nav.Name.Substring(0, 1).ToUpper() + nav.Name.Substring(1);
          var createMethodName = isCollection ? $"add{entity.Name}To{nav.Name.Substring(0, 1).ToUpper() + nav.Name.Substring(1)}" : $"set{entity.Name}As{nav.Name.Substring(0, 1).ToUpper() + nav.Name.Substring(1)}";
          var deleteMethodName = isCollection ? $"remove{entity.Name}From{nav.Name.Substring(0, 1).ToUpper() + nav.Name.Substring(1)}" : $"unset{entity.Name}As{nav.Name.Substring(0, 1).ToUpper() + nav.Name.Substring(1)}";

          var castEntity = (Program.Package as Angular.Package).FindEntity(propertyEntity.FullName);

          // Navigation
          yield return $"public {navMethodName}(key: EntityKey<{EntityName}>): ODataNavigationPropertyResource<{entity.ImportedName}> {{ " +
              $"\n    return this.entity(key).navigationProperty<{entity.ImportedName}>('{binding.PropertyName}'); " +
              "\n  }";

          // Fetch
          yield return $"public {fetchMethodName}(key: EntityKey<{EntityName}>, options?: ODataQueryArgumentsOptions<{entity.ImportedName}>) {{" +
              $"\n    return this.fetchNavigationProperty<{entity.ImportedName}>(" +
              $"\n      this.{navMethodName}(key), " +
              $"\n      '{responseType}', options) as Observable<{returnType}>;" +
               "\n  }";

          // Link
          yield return $"public {createMethodName}(key: EntityKey<{EntityName}>, target: ODataEntityResource<{returnType}>, {{etag}}: {{etag?: string}} = {{}}): Observable<any> {{" +
              $"\n    return this.{navMethodName}(key).reference()" +
              $"\n      .{(isCollection ? "add" : "set")}(target{(isCollection ? "" : ", {etag}")});" +
               "\n  }";

          // Unlink
          yield return $@"public {deleteMethodName}(key: EntityKey<{EntityName}>, {{target, etag}}: {{target?: ODataEntityResource<{returnType}>, etag?: string}} = {{}}): Observable<any> {{" +
          $"\n    return this.{navMethodName}(key).reference()" +
          $"\n      .{(isCollection ? "remove(target)" : "unset({etag})")};" +
           "\n  }";
        }
      }
    }
    public object ToLiquid()
    {
      return new
      {
        Name = this.ImportedName
      };
    }

  }
}