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

            Configuration.GetSection("Templates").Bind(templateRenderer);
            templateRenderer.LoadTemplates();

            var xml = Loader.Load(MetadataPath);
            var metadataReader = new MetadataReader(xml);

            directoryManager.PrepareOutput(PurgeOutput);

            Logger.LogInformation("Preparing namespace structure");
            var enums = metadataReader.EnumTypes.Select(en => new Angular.Enum(en));
            directoryManager.PrepareNamespaceFolders(enums);
            
            var services = metadataReader.EntitySets.Select(es => new Angular.Service(es));
            directoryManager.PrepareNamespaceFolders(services);
            
            var types = metadataReader.EntityTypes.Select(entity => new Angular.Model(entity));
            directoryManager.PrepareNamespaceFolders(types);

            types = metadataReader.ComplexTypes.Select(complex => new Angular.Model(complex));
            directoryManager.PrepareNamespaceFolders(types);

            directoryManager.DirectoryCopy("./StaticContent", Output, true);

            templateRenderer.CreateContext(MetadataPath, "4.0");

            templateRenderer.CreateEntityTypes(metadataReader.EntityTypes);
            templateRenderer.CreateComplexTypes(metadataReader.ComplexTypes);

            templateRenderer.CreateEnums(metadataReader.EnumTypes);

            templateRenderer.CreateServicesForEntitySets(metadataReader.EntitySets);

            templateRenderer.CreateModule(EndpointName, metadataReader.EntityTypes, metadataReader.EntitySets);
            templateRenderer.CreateIndex(EndpointName, metadataReader.EntityTypes, metadataReader.EntitySets);
        }
    }
}
