using ODataApiGen.Abstracts;
using System.Text.Json;

namespace ODataApiGen.Angular
{
    public class EntitySetConfig : AngularRenderable, DotLiquid.ILiquidizable
  {
    public ServiceEntitySet Service { get; private set; }
    public EntitySetConfig(ServiceEntitySet service, ApiOptions options) : base(options)
    {
      Service = service;
      this.AddDependency(service);
    }
    public override string FileName => this.Service.FileName + ".config";
    public override string Name => this.Service.Name + "EntitySetConfig";
    public bool HasAnnotations => this.Service.Annotations.Count() > 0;
    public string Annotations => JsonSerializer.Serialize(this.Service.Annotations.Select(annot => annot.ToDictionary()), new JsonSerializerOptions() { WriteIndented = true });
    public string EntitySetName => this.Service.EntitySetName;
    public string EntityType => this.Service.EntityType;
    // Imports
    public override IEnumerable<string> ImportTypes => new List<string> { };
    public override IEnumerable<Import> Imports => GetImportRecords();
    public override string Directory => this.Service.EdmNamespace.Replace('.', Path.DirectorySeparatorChar);
    public object ToLiquid()
    {
      return new
      {
        this.EntitySetName,
        this.EntityType,
        Name = this.ImportedName,
        Service = new
        {
            this.Service.Name,
        }
      };
    }
  }
}