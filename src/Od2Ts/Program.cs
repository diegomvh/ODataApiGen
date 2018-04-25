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
        public static string MetadataPath { get; set; }
        public static string EndpointName { get; set; }
        public static string Output { get; set; }
        public static bool UseIntrefaces { get; set; }
        public static bool PurgeOutput { get; set; }

        static void Main(string[] args)
        {
            LoggerFactory
                .AddConsole()
                .AddDebug();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("application.json")
                .AddCommandLine(args, new Dictionary<string, string>() {
                    {"-MetadataPath", "MetadataPath"},
                    {"-EndpointName", "EndpointName"},
                    {"-UseInterfaces", "UseInterfaces"}
                });
            Configuration = builder.Build();

            MetadataPath = Configuration.GetValue<string>("MetadataPath");
            EndpointName = Configuration.GetValue<string>("EndpointName");
            Output = Configuration.GetValue<string>("Output");
            PurgeOutput = Configuration.GetValue<bool>("PurgeOutput");
            UseIntrefaces = Configuration.GetValue<bool>("UseInterfaces");
            
            var directoryManager = new DirectoryManager(Output);
            var templateRenderer = new TemplateRenderer(Output, UseIntrefaces);

            var metadataReader = new MetadataReader(
                System.Xml.Linq.XDocument.Load(MetadataPath));

            directoryManager.PrepareOutput(PurgeOutput);
            var module = new Angular.Module(EndpointName, UseIntrefaces);
            module.AddEnums(metadataReader.EnumTypes);
            module.AddModels(metadataReader.EntityTypes);
            module.AddModels(metadataReader.ComplexTypes);
            module.AddServices(metadataReader.EntitySets);

            Logger.LogInformation("Preparing namespace structure");
            directoryManager.PrepareNamespaceFolders(module.GetAllNamespaces());
            
            Logger.LogInformation("Copy static content");
            directoryManager.DirectoryCopy("./StaticContent", Output, true);

            Logger.LogInformation("Render");
            templateRenderer.CreateContext(MetadataPath, "4.0");
            templateRenderer.CreateModels(module);
            templateRenderer.CreateEnums(module);
            templateRenderer.CreateServices(module);
            templateRenderer.CreateModule(module);
            templateRenderer.CreateIndex(module);
        }
    }
}
