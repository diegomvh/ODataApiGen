using System;
using System.IO;
using ODataApiGen.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace ODataApiGen
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
                .AddJsonFile("application.trippinentity.json")
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

            Metadata = Configuration.GetValue<string>("Metadata");
            var metadata = new Metadata(System.Xml.Linq.XDocument.Load(Metadata));

            Purge = Configuration.GetValue<bool>("Purge");
            directories.PrepareOutput(Purge);

            WithCredentials = Configuration.GetValue<bool>("WithCredentials");
            StringAsEnum = Configuration.GetValue<bool>("StringAsEnum");
            Models = Configuration.GetValue<bool>("Models");
            var package = new Angular.Package(Name, Metadata, WithCredentials, StringAsEnum, Models, "4.0");
            package.LoadMetadata(metadata);
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
