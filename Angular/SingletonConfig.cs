using ODataApiGen.Abstracts;
using System.Text.Json;

namespace ODataApiGen.Angular
{
    public class SingletonConfig : AngularRenderable, DotLiquid.ILiquidizable
  {
    public ServiceSingleton Service { get; private set; }
    public SingletonConfig(ServiceSingleton service, ApiOptions options) : base(options)
    {
      Service = service;
      this.AddDependency(service);
    }
    public override string FileName => this.Service.FileName + ".config";
    public override string Name => this.Service.Name + "SingletonConfig";
    public bool HasAnnotations => this.Service.Annotations.Count() > 0;
    public string Annotations => JsonSerializer.Serialize(this.Service.Annotations.Select(annot => annot.ToDictionary()), new JsonSerializerOptions() { WriteIndented = true });
    public string SingletonName => this.Service.SingletonName;
    public string SingletonType => this.Service.SingletonType;
    // Imports
    public override IEnumerable<string> ImportTypes => new List<string> { };
    public override IEnumerable<Import> Imports => GetImportRecords();
    public override string Namespace => this.Service.Namespace;
    public override string Directory => this.Namespace.Replace('.', Path.DirectorySeparatorChar);
    public object ToLiquid()
    {
      return new
      {
        this.FullName,
        this.SingletonName,
        this.SingletonType,
        Name = this.ImportedName,
        Service = new
        {
            this.Service.Name,
        }
      };
    }
  }
}