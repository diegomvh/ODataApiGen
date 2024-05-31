using ODataApiGen.Abstracts;
using System.Text.Json;

namespace ODataApiGen.Flutter
{
    public class EntitySetConfig : FlutterRenderable, DotLiquid.ILiquidizable
  {
    public Flutter.Service Service { get; private set; }
    public EntitySetConfig(Flutter.Service service, ApiOptions options) : base(options)
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
    public override string Namespace => this.Service.Namespace;
    public override string Directory => this.Namespace.Replace('.', Path.DirectorySeparatorChar);
    public object ToLiquid()
    {
      return new
      {
        Name = this.ImportedName,
        Type = this.Type,
        EntitySetName = this.EntitySetName,
        EntityType = this.EntityType,
        Service = new
        {
          Name = this.Service.Name,
        }
      };
    }
  }
}