using System;
using System.IO;
using DotLiquid;
using DotLiquid.FileSystems;
using Microsoft.Extensions.Logging;
using ODataApiGen.Abstracts;

namespace ODataApiGen
{
    public class Renderer
    {
        private ILogger Logger { get; } = Program.CreateLogger<Renderer>();
        public string StaticPath = $"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}Static";
        public string TemplatesPath = $"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}Templates";
        public string Output { get; private set; }
        public Renderer(string output)
        {
            //Template.FileSystem = new LocalFileSystem(TemplatesPath);
            this.Output = output;
        }

        private void DoRender(Renderable entity)
        {
            var templateName = entity.GetType().Name;
            var template = Template.Parse(File.ReadAllText($"{TemplatesPath}{Path.DirectorySeparatorChar}Angular{Path.DirectorySeparatorChar}{templateName}.ts"));
            var text = template.Render(Hash.FromAnonymousObject(entity, true));

            var path = $"{Output}{Path.DirectorySeparatorChar}";
            if (!String.IsNullOrWhiteSpace(entity.Directory))
                path += $"{entity.Directory}{Path.DirectorySeparatorChar}";
            path += $"{entity.FileName}.ts";
            path = Path.GetFullPath(path);

            if (!File.Exists(path) || entity.Overwrite) {
                System.Console.WriteLine($"Writing: {path}");
                File.WriteAllText(path, text);
            } else {
                System.Console.WriteLine($"Skip: {path}");
            }
        }

        public void Render(Package package) {
            foreach (var renderable in package.Renderables)
            {
                DoRender(renderable);
            }
        }
    }
}
