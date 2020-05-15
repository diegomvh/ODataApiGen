using System;
using System.IO;
using ODataApiGen.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ODataApiGen
{
    class Program
    {
        public static ILoggerFactory LoggerFactory { get; private set; }
        public static ILogger Logger { get; private set; }
        public static IConfiguration Configuration { get; set; }
        public static Metadata Metadata { get; set; }
        public static string Name { get; set; }
        public static string Output { get; set; }
        public static bool Purge { get; set; }
        public static bool WithCredentials { get; set; }
        public static bool StringAsEnum { get; set; }
        public static bool Models { get; set; }

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
                    {"-Output", "Output"},
                    {"-WithCredentials", "WithCredentials"},
                    {"-StringAsEnum", "StringAsEnum"},
                    {"-Models", "Models"}
                });
            Configuration = builder.Build();

            Name = Configuration.GetValue<string>("Name");
            Output = Configuration.GetValue<string>("Output");
            Output = $"{Output}{Path.DirectorySeparatorChar}{Name.ToLower()}";
            var directories = new DirectoryManager(Output);
            var renderer = new Renderer(Output);

            var metadata = Configuration.GetValue<string>("Metadata");
            Metadata = new Metadata(System.Xml.Linq.XDocument.Load(metadata));

            Purge = Configuration.GetValue<bool>("Purge");
            directories.PrepareOutput(Purge);

            WithCredentials = Configuration.GetValue<bool>("WithCredentials");
            StringAsEnum = Configuration.GetValue<bool>("StringAsEnum");
            Models = Configuration.GetValue<bool>("Models");
            var package = new Angular.Package(Name, metadata, WithCredentials, StringAsEnum, Models, "4.0");
            package.LoadMetadata(Program.Metadata);
            package.ResolveDependencies();

            Logger.LogInformation("Preparing namespace structure");
            directories.PrepareFolders(package.GetAllDirectories());

            Logger.LogInformation("Copy static content");
            directories.DirectoryCopy($"{renderer.StaticPath}{Path.DirectorySeparatorChar}Angular", Output, true);

            Logger.LogInformation("Render");
            renderer.Render(package);
        }
    }
}
