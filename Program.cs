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
        public static bool PurgeOutput { get; set; }
        public static bool Secure { get; set; }
        public static bool StringAsEnum { get; set; }
        public static bool Models { get; set; }

        static void Main(string[] args)
        {
            LoggerFactory
                .AddConsole()
                .AddDebug();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("application.trippinentity.json")
                .AddCommandLine(args, new Dictionary<string, string>() {
                    {"-MetadataPath", "MetadataPath"},
                    {"-EndpointName", "EndpointName"},
                    {"-Models", "Models"}
                });
            Configuration = builder.Build();

            MetadataPath = Configuration.GetValue<string>("MetadataPath");
            EndpointName = Configuration.GetValue<string>("EndpointName");
            Output = Configuration.GetValue<string>("Output");
            Secure = Configuration.GetValue<bool>("Secure");
            PurgeOutput = Configuration.GetValue<bool>("PurgeOutput");
            StringAsEnum = Configuration.GetValue<bool>("StringAsEnum");
            Models = Configuration.GetValue<bool>("Models");
            
            var directoryManager = new DirectoryManager(Output);
            var templateRenderer = new Renderer(Output);

            var metadataReader = new MetadataReader(
                System.Xml.Linq.XDocument.Load(MetadataPath));

            directoryManager.PrepareOutput(PurgeOutput);
            var package = new Angular.Package(EndpointName, MetadataPath, Secure, StringAsEnum, Models, "4.0");
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
