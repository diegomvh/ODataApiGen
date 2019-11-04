using System.IO;
using DotLiquid;
using DotLiquid.FileSystems;
using Microsoft.Extensions.Logging;
using Od2Ts.Abstracts;

namespace Od2Ts
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

            var fileName = entity.FileName;
            var directory = entity.Directory;

            File.WriteAllText($"{Output}{Path.DirectorySeparatorChar}{directory}{Path.DirectorySeparatorChar}{fileName}.ts", text);
        }

        public void Render(Package package) {
            foreach (var renderable in package.Renderables)
            {
                DoRender(renderable);
            }
        }
    }
}
