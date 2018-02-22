using System;
using System.IO;
using Od2Ts.Models;
using Microsoft.Extensions.Configuration;

namespace Od2Ts
{
    class Program
    {
        public static IConfiguration Configuration {get; set;}
        public static string MetadataPath {get; set;}
        public static string EndpointName {get; set;}
        public static string Output {get; set;}
        public static bool PurgeOutput {get; set;}

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("application.json");
            Configuration = builder.Build();
            
            MetadataPath = Configuration.GetValue<string>("MetadataPath");
            EndpointName = Configuration.GetValue<string>("EndpointName");
            Output = Configuration.GetValue<string>("Output");
            PurgeOutput = Configuration.GetValue<bool>("PurgeOutput");

            var templateRenderer = new TemplateRenderer(Output);

            Configuration.GetSection("Templates").Bind(templateRenderer);
            if (true) {
                Configuration.GetSection("AngularTemplates").Bind(templateRenderer);
            }
            else
            {
                Configuration.GetSection("AureliaTemplates").Bind(templateRenderer);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
