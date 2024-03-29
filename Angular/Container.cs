using System.Collections.Generic;
using System.Linq;
using ODataApiGen.Models;
using System.IO;
using ODataApiGen.Abstracts;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ODataApiGen.Angular
{
  public class Container : AngularRenderable, DotLiquid.ILiquidizable
  {
    public Models.EntityContainer EdmEntityContainer { get; private set; }
    public Angular.ServiceContainer Service { get; private set; }
    public ICollection<Angular.Service> Services { get; } = new List<Angular.Service>();
    public ICollection<Angular.EntitySetConfig> EntitySetConfigs { get; } = new List<Angular.EntitySetConfig>();
    public Container(EntityContainer container, ApiOptions options) : base(options)
    {
      this.EdmEntityContainer = container;
      this.Service = new Angular.ServiceContainer(this, options);
      foreach (var eset in container.EntitySets)
      {
        Service service = new Angular.ServiceEntitySet(eset, options);
        this.Services.Add(service);
        var config = new Angular.EntitySetConfig(service, options);
        this.EntitySetConfigs.Add(config);
      }
      foreach (var s in container.Singletons)
      {
        var service = new Angular.ServiceSingleton(s, options);
        this.Services.Add(service);
        var config = new Angular.EntitySetConfig(service, options);
        this.EntitySetConfigs.Add(config);
      }
    }
    public bool HasAnnotations => this.EdmEntityContainer.Annotations.Count() > 0;
    public string Annotations => JsonSerializer.Serialize(this.EdmEntityContainer.Annotations.Select(annot => annot.ToDictionary()), new JsonSerializerOptions() { WriteIndented = true });
    public override string FileName => this.EdmEntityContainer.Name.ToLower() + ".container";
    public override string Name => Utils.ToTypescriptName(this.EdmEntityContainer.Name, TypeScriptElement.Class) + "Container";
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
        Type = this.Type,
        ContainerName = this.ContainerName,
        ContainerType = this.ContainerType
      };
    }
  }
}