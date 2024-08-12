using ODataApiGen.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ODataApiGen.Abstracts;

namespace ODataApiGen
{
  class Program
  {
    public static ILoggerFactory? LoggerFactory { get; private set; }
    public static ILogger? Logger { get; private set; }
    public static IConfiguration? Configuration { get; set; }
    public static Metadata? Metadata { get; set; }
    public static Package? Package { get; set; }

    static void Main(string[] args)
    {
      LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder =>
          builder
              .AddFilter("Microsoft", LogLevel.Warning)
              .AddFilter("System", LogLevel.Warning)
              .AddFilter("ODataApiGen.Program", LogLevel.Debug)
              .AddConsole()
          );
      Logger = LoggerFactory.CreateLogger<Program>();

      var builder = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("application.json")
          .AddCommandLine(args, new Dictionary<string, string>() {
            {"-Name", "Name"},
            {"-Metadata", "Metadata"},
            {"-Purge", "Purge"},
            {"-GeoJson", "GeoJson"},
            {"-Output", "Output"},
            {"-Models", "Models"}
          });
      Configuration = builder.Build();

      var name = Configuration.GetValue<string>("Name");
      var output = Configuration.GetValue<string>("Output");
      var type = Configuration.GetValue<string>("Type");
      output = $"{output}{Path.DirectorySeparatorChar}{name.Dasherize()}";
      var directories = new DirectoryManager(output);
      var renderer = new Renderer(type, output);

      var metadata = Configuration.GetValue<string>("Metadata");
      var serviceRootUrl = metadata.StartsWith("http") ? metadata.TrimEnd("$metadata".ToCharArray()) : "";
      Metadata = new Metadata(System.Xml.Linq.XDocument.Load(metadata));

      var purge = Configuration.GetValue<bool>("Purge");
      directories.PrepareOutput(purge);

      var options = new ApiOptions()
      {
        Name = name,
        ServiceRootUrl = serviceRootUrl,
        Version = Metadata.Version,
        Models = Configuration.GetValue<bool>("Models"),
        GeoJson = Configuration.GetValue<bool>("GeoJson"),
      };
      Package = type == "Angular" ? new Angular.Package(options) : new Flutter.Package(options);
      Package.Build();
      Package.ResolveDependencies();

      Logger.LogInformation("Preparing namespace structure");
      directories.PrepareFolders(Package.GetAllDirectories());

      Logger.LogInformation("Copy static content");
      directories.DirectoryCopy($"{renderer.StaticPath}{Path.DirectorySeparatorChar}{type}", output, true);

      Logger.LogInformation("Render");
      renderer.Render(Package);
    }
  }
}
