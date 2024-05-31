using ODataApiGen.Abstracts;
using ODataApiGen.Models;

namespace ODataApiGen.Flutter
{
    public class ServiceEntitySet : Service
  {
    public Models.EntitySet EdmEntitySet { get; private set; }
    public ServiceEntitySet(EntitySet type, ApiOptions options) : base(options)
    {
      EdmEntitySet = type;
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
        list.AddRange(this.EdmEntitySet.NavigationPropertyBindings.Select(b => b.PropertyType).Where(t => t != null).Select(t => t.FullName));
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
    public override string EntitySetName => this.EdmEntitySet.Name;
    public override string EntityType => this.EdmEntitySet.EntityType;
    public string ServiceType => this.EdmEntitySet.FullName;
    public override string Name => Utils.ToDartName(this.EdmEntitySet.Name, DartElement.Class) + "Service";
    public override string Namespace => this.EdmEntitySet.Namespace;
    public override string FileName => this.EdmEntitySet.Name.ToLower() + ".service";
    public IEnumerable<string> Actions => this.RenderCallables(this.EdmEntitySet.Actions.Union(this.EdmEntityType.Actions));
    public IEnumerable<string> Functions => this.RenderCallables(this.EdmEntitySet.Functions.Union(this.EdmEntityType.Functions));
    public IEnumerable<string> Navigations => this.RenderNavigationPropertyBindings(this.EdmEntitySet.NavigationPropertyBindings);
    public override IEnumerable<Models.Annotation> Annotations => this.EdmEntitySet.Annotations;
  }
}
