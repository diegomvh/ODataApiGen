using ODataApiGen.Abstracts;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public class ServiceSingleton : Service
  {
    public Singleton EdmSingleton { get; private set; }

    public ServiceSingleton(Singleton type, ApiOptions options) : base(options)
    {
      EdmSingleton = type;
    }
    public override string Name => Utils.ToTypescriptName(this.EdmSingleton.Name, TypeScriptElement.Class) + "Service";
    public override string EdmNamespace => this.EdmSingleton.Namespace;
    public override string FileName => this.EdmSingleton.Name.Dasherize() + ".service";
    // Imports
    public override IEnumerable<Import> Imports => GetImportRecords();
    public override IEnumerable<string> ImportTypes
    {
      get
      {
        var parameters = new List<Models.Parameter>();
        foreach (var cal in this.EdmSingleton.Actions)
          parameters.AddRange(cal.Parameters);
        foreach (var cal in this.EdmSingleton.Functions)
          parameters.AddRange(cal.Parameters);

        var list = new List<string> {
                    this.EdmSingleton.Type
                };
        list.AddRange(parameters.Select(p => p.Type));
        list.AddRange(this.EdmSingleton.Actions.SelectMany(a => this.CallableNamespaces(a)));
        list.AddRange(this.EdmSingleton.Functions.SelectMany(a => this.CallableNamespaces(a)));
        if (this.Entity != null)
        {
          list.AddRange(this.Entity.EdmStructuredType.Properties.Select(a => a.Type));
          if (this.Entity.EdmStructuredType is EntityType)
            list.AddRange((this.Entity.EdmStructuredType as EntityType).NavigationProperties.Select(a => a.Type));
        }
        if (this.Model != null)
        {
          list.AddRange(this.Model.EdmStructuredType.Properties.Select(a => a.Type));
          if (this.Model.EdmStructuredType is EntityType)
            list.AddRange((this.Model.EdmStructuredType as EntityType).NavigationProperties.Select(a => a.Type));
        }
        return list;
      }
    }

    public string SingletonName => this.EdmSingleton.Name;
    public string SingletonType => this.EdmSingleton.Type;
    public override string EntityType => this.EdmSingleton.Type;
    public override IEnumerable<Annotation> Annotations => this.EdmSingleton.Annotations;
    public override string ServiceType => this.EdmSingleton.NamespaceQualifiedName;
    public IEnumerable<string> Actions => this.RenderCallables(this.EdmSingleton.Actions);
    public IEnumerable<string> Functions => this.RenderCallables(this.EdmSingleton.Functions);
  }
}