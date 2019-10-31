using System;
using System.IO;
using Od2Ts.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Od2Ts
{
    class Program
    {
        public static ILoggerFactory LoggerFactory { get; } = new LoggerFactory();
        public static ILogger CreateLogger<T>() => LoggerFactory.CreateLogger<T>();
        public static ILogger Logger { get; } = Program.CreateLogger<Program>();
        public static IConfiguration Configuration { get; set; }
        public static string Metadata { get; set; }
        public static string Name { get; set; }
        public static string Output { get; set; }
        public static bool Purge { get; set; }
        public static bool WithCredentials { get; set; }
        public static bool StringAsEnum { get; set; }
        public static bool Models { get; set; }

        static void Main(string[] args)
        {
            LoggerFactory
                .AddConsole()
                .AddDebug();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("application.trippinmodel.json")
                .AddCommandLine(args, new Dictionary<string, string>() {
                    {"-Name", "Name"},
                    {"-Metadata", "MetadataPath"},
                    {"-Purge", "Purge"},
                    {"-Output", "Output"},
                    {"-WithCredentials", "WithCredentials"},
                    {"-StringAsEnum", "StringAsEnum"},
                    {"-Models", "Models"}
                });
            Configuration = builder.Build();

            Metadata = Configuration.GetValue<string>("Metadata");
            Name = Configuration.GetValue<string>("Name");
            Output = Configuration.GetValue<string>("Output");
            Purge = Configuration.GetValue<bool>("Purge");
            WithCredentials = Configuration.GetValue<bool>("WithCredentials");
            StringAsEnum = Configuration.GetValue<bool>("StringAsEnum");
            Models = Configuration.GetValue<bool>("Models");
            
            var directoryManager = new DirectoryManager(Output);
            var templateRenderer = new Renderer(Output);

            var metadataReader = new MetadataReader(
                System.Xml.Linq.XDocument.Load(Metadata));

            directoryManager.PrepareOutput(Purge);
            var package = new Angular.Package(Name, Metadata, WithCredentials, StringAsEnum, Models, "4.0");
            package.LoadMetadata(metadataReader);
            package.ResolveDependencies();

            Logger.LogInformation("Preparing namespace structure");
            directoryManager.PrepareFolders(package.GetAllDirectories());
            
            Logger.LogInformation("Copy static content");
            directoryManager.DirectoryCopy("./StaticContent", Output, true);

            Logger.LogInformation("Render");
            templateRenderer.Render(package);
        }
    }
}
