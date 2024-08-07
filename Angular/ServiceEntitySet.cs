using ODataApiGen.Abstracts;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public class ServiceEntitySet : Service
  {
    public EntitySet EdmEntitySet { get; private set; }
    public ServiceEntitySet(EntitySet entitySet, ApiOptions options) : base(options)
    {
      EdmEntitySet = entitySet;
    }
    public override IEnumerable<string> ImportTypes
    {
      get
      {
        var parameters = new List<Models.Parameter>();
        foreach (var cal in this.EdmEntitySet.Actions)
          parameters.AddRange(cal.Parameters);
        foreach (var cal in this.EdmEntitySet.Functions)
          parameters.AddRange(cal.Parameters);

        var list = new List<string> {
                    this.EdmEntitySet.EntityType
                };
        list.AddRange(parameters.Select(p => p.Type));
        list.AddRange(this.EdmEntitySet.Actions.SelectMany(a => this.CallableNamespaces(a)));
        list.AddRange(this.EdmEntitySet.Functions.SelectMany(a => this.CallableNamespaces(a)));
        list.AddRange(this.EdmEntitySet.NavigationPropertyBindings.Select(b => b.NavigationProperty.Type));
        list.AddRange(this.EdmEntitySet.NavigationPropertyBindings.Select(b => b.PropertyType).Where(t => t != null).Select(t => t.NamespaceQualifiedName));
        if (this.EdmEntityType != null)
        {
          list.AddRange(this.EdmEntityType.Actions.SelectMany(a => this.CallableNamespaces(a)));
          list.AddRange(this.EdmEntityType.Functions.SelectMany(a => this.CallableNamespaces(a)));
        }
        if (this.HasEntity)
        {
          list.AddRange(this.Entity.EdmStructuredType.Properties.Select(a => a.Type));
        }
        if (this.HasModel)
        {
          list.AddRange(this.Model.EdmStructuredType.Properties.Select(a => a.Type));
        }
        return list.Where(t => !String.IsNullOrWhiteSpace(t) && !t.StartsWith("Edm.")).Distinct();
      }
    }

    public override IEnumerable<Import> Imports => GetImportRecords();
    public string EntitySetName => this.EdmEntitySet.Name;
    public override string EntityType => this.EdmEntitySet.EntityType;
    public override string ServiceType => this.EdmEntitySet.NamespaceQualifiedName;
    public override string Name => Utils.ToTypescriptName(this.EdmEntitySet.Name, TypeScriptElement.Class) + "Service";
    public override string EdmNamespace => this.EdmEntitySet.Namespace;
    public override string FileName => this.EdmEntitySet.Name.Dasherize() + ".service";
    public IEnumerable<string> Actions => this.RenderCallables(this.EdmEntitySet.Actions.Union(this.EdmEntityType.Actions));
    public IEnumerable<string> Functions => this.RenderCallables(this.EdmEntitySet.Functions.Union(this.EdmEntityType.Functions));
    public IEnumerable<string> Navigations => this.RenderNavigationPropertyBindings(this.EdmEntitySet.NavigationPropertyBindings);
    public override IEnumerable<Models.Annotation> Annotations => this.EdmEntitySet.Annotations;
  }
}
