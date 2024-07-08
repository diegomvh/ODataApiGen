using ODataApiGen.Models;
using ODataApiGen.Abstracts;
using System.Text.Json;

namespace ODataApiGen.Flutter
{
    public class Container : FlutterRenderable, DotLiquid.ILiquidizable
  {
    public Models.EntityContainer EdmEntityContainer { get; private set; }
    public Flutter.ServiceContainer Service { get; private set; }
    public ICollection<Flutter.Service> Services { get; } = new List<Flutter.Service>();
    public ICollection<Flutter.EntitySetConfig> EntitySetConfigs { get; } = new List<Flutter.EntitySetConfig>();
    public Container(EntityContainer container, ApiOptions options) : base(options)
    {
      this.EdmEntityContainer = container;
      this.Service = new Flutter.ServiceContainer(this, options);
      foreach (var eset in container.EntitySets)
      {
        Service service = new Flutter.ServiceEntitySet(eset, options);
        this.Services.Add(service);
        var config = new Flutter.EntitySetConfig(service, options);
        this.EntitySetConfigs.Add(config);
      }
      foreach (var s in container.Singletons)
      {
        var service = new Flutter.ServiceSingleton(s, options);
        this.Services.Add(service);
        var config = new Flutter.EntitySetConfig(service, options);
        this.EntitySetConfigs.Add(config);
      }
    }
    public bool HasAnnotations => this.EdmEntityContainer.Annotations.Count() > 0;
    public string Annotations => JsonSerializer.Serialize(this.EdmEntityContainer.Annotations.Select(annot => annot.ToDictionary()), new JsonSerializerOptions() { WriteIndented = true });
    public override string FileName => this.EdmEntityContainer.Name.Dasherize() + ".container";
    public override string Name => Utils.ToDartName(this.EdmEntityContainer.Name, DartElement.Class) + "Container";
    public string ContainerType => this.EdmEntityContainer.NamespaceQualifiedName;
    public string ContainerName => this.EdmEntityContainer.Name;
    public string ApiName => this.Options.Name;
    // Imports
    public override IEnumerable<string> ImportTypes => new List<string> { this.ContainerType };
    public override IEnumerable<Import> Imports => GetImportRecords();
    public override string Directory => this.EdmEntityContainer.Namespace.Replace('.', Path.DirectorySeparatorChar);
    public void ResolveDependencies(IEnumerable<Flutter.Enum> enums, IEnumerable<Flutter.Entity> entities, IEnumerable<Flutter.Model> models, IEnumerable<Flutter.Collection> collections)
    {
      // Services
      foreach (var service in Services)
      {
        var inter = entities.FirstOrDefault(m => m.EdmStructuredType.IsTypeOf(service.EntityType));
        if (inter != null)
        {
          service.SetEntity(inter);
          //service.AddDependency(inter);
        }
        var model = models.FirstOrDefault(m => m.EdmStructuredType.NamespaceQualifiedName == service.EntityType);
        if (model != null)
        {
          service.SetModel(model);
          //service.AddDependency(model);
        }
        var collection = collections.FirstOrDefault(m => m.EdmStructuredType.NamespaceQualifiedName == service.EntityType);
        if (collection != null)
        {
          service.SetCollection(collection);
          //service.AddDependency(collection);
        }
      }

      this.AddDependencies(this.EntitySetConfigs);
    }
    public IEnumerable<string> GetAllDirectories()
    {
      return new string[] { this.Service.Directory }
          .Union(this.Services.Select(s => s.Directory))
          .Union(this.EntitySetConfigs.Select(s => s.Directory));
    }
    public IEnumerable<Renderable> Renderables
    {
      get
      {
        var renderables = new List<Renderable>();
        renderables.Add(this.Service);
        renderables.AddRange(this.Services);
        renderables.AddRange(this.EntitySetConfigs);
        return renderables;
      }
    }
    public object ToLiquid()
    {
      return new
      {
        Name = this.ImportedName,
        ContainerName = this.ContainerName,
        ContainerType = this.ContainerType
      };
    }
  }
}