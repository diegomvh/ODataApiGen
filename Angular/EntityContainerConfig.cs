using ODataApiGen.Models;
using ODataApiGen.Abstracts;
using System.Text.Json;

namespace ODataApiGen.Angular
{
    public class EntityContainerConfig : AngularRenderable, DotLiquid.ILiquidizable
  {
    public EntityContainer EdmEntityContainer { get; private set; }
    public ServiceContainer Service { get; private set; }
    public ICollection<Service> Services { get; } = new List<Angular.Service>();
    public ICollection<EntitySetConfig> EntitySetConfigs { get; } = new List<Angular.EntitySetConfig>();
    public EntityContainerConfig(EntityContainer container, ApiOptions options) : base(options)
    {
      this.EdmEntityContainer = container;
      this.Service = new ServiceContainer(this, options);
      foreach (var eset in container.EntitySets)
      {
        Service service = new ServiceEntitySet(eset, options);
        this.Services.Add(service);
        var config = new EntitySetConfig(service, options);
        this.EntitySetConfigs.Add(config);
      }
      foreach (var s in container.Singletons)
      {
        var service = new ServiceSingleton(s, options);
        this.Services.Add(service);
        var config = new EntitySetConfig(service, options);
        this.EntitySetConfigs.Add(config);
      }
    }
    public bool HasAnnotations => this.EdmEntityContainer.Annotations.Count() > 0;
    public string Annotations => JsonSerializer.Serialize(this.EdmEntityContainer.Annotations.Select(annot => annot.ToDictionary()), new JsonSerializerOptions() { WriteIndented = true });
    public override string FileName => this.EdmEntityContainer.Name.ToLower() + ".entitycontainer.config";
    public override string Name => Utils.ToTypescriptName(this.EdmEntityContainer.Name, TypeScriptElement.Class) + "EntityContainerConfig";
    public string ContainerType => this.EdmEntityContainer.FullName;
    public string ContainerName => this.EdmEntityContainer.Name;
    public string ApiName => this.Options.Name;
    // Imports
    public override IEnumerable<string> ImportTypes => new List<string> { this.ContainerType };
    public override IEnumerable<Import> Imports => GetImportRecords();
    public override string Namespace => this.EdmEntityContainer.Namespace;
    public override string Directory => this.Namespace.Replace('.', Path.DirectorySeparatorChar);
    public void ResolveDependencies(IEnumerable<Angular.Enum> enums, IEnumerable<Angular.Entity> entities, IEnumerable<Angular.Model> models, IEnumerable<Angular.Collection> collections)
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
        var model = models.FirstOrDefault(m => m.EdmStructuredType.FullName == service.EntityType);
        if (model != null)
        {
          service.SetModel(model);
          //service.AddDependency(model);
        }
        var collection = collections.FirstOrDefault(m => m.EdmStructuredType.FullName == service.EntityType);
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
        var renderables = new List<Renderable>
        {
            this.Service
        };
        renderables.AddRange(this.Services);
        renderables.AddRange(this.EntitySetConfigs);
        return renderables;
      }
    }
    public object ToLiquid()
    {
      return new
      {
        this.Type,
        this.ContainerName,
        this.ContainerType,
        Name = this.ImportedName
      };
    }
  }
}