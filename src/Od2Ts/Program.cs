using System;
using System.IO;
using Od2Ts.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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

            Configuration.GetSection("Templates").Bind(templateRenderer);
            templateRenderer.LoadTemplates();

            var xml = Loader.Load(MetadataPath);
            var metadataReader = new MetadataReader(xml);

            directoryManager.PrepareOutput(PurgeOutput);

            Logger.LogInformation("Preparing namespace structure");
            directoryManager.PrepareNamespaceFolders(metadataReader.EnumTypes);
            directoryManager.PrepareNamespaceFolders(metadataReader.EntitySets);
            directoryManager.PrepareNamespaceFolders(metadataReader.EntityTypes);
            directoryManager.PrepareNamespaceFolders(metadataReader.ComplexTypes);

            directoryManager.DirectoryCopy("./StaticContent", Output, true);

            templateRenderer.CreateContext(MetadataPath, "4.0");

            templateRenderer.CreateEntityTypes(metadataReader.EntityTypes);
            templateRenderer.CreateComplexTypes(metadataReader.ComplexTypes);

            templateRenderer.CreateEnums(metadataReader.EnumTypes);

            templateRenderer.CreateServicesForEntitySets(metadataReader.EntitySets);

            var module = new AngularModule(EndpointName, metadataReader.EntityTypes, metadataReader.EntitySets);
            templateRenderer.CreateAngularModule(module);
            templateRenderer.CreateAngularIndex(module);
        }
    }
}
