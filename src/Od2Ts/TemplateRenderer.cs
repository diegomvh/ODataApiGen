using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Od2Ts.Abstracts;

namespace Od2Ts
{
    public class TemplateRenderer
    {
        private ILogger Logger { get; } = Program.CreateLogger<TemplateRenderer>();
        public string Output { get; private set; }
        public TemplateRenderer(string output)
        {
            this.Output = output;
        }

        private void DoRender(Renderable entity)
        {
            var fileName = entity.FileName;
            var directory = entity.Directory;

            File.WriteAllText($"{Output}{Path.DirectorySeparatorChar}{directory}{Path.DirectorySeparatorChar}{fileName}.ts", entity.Render());
        }

        public void Render(Package package) {
            foreach (var renderable in package.Renderables)
            {
                DoRender(renderable);
            }
        }
    }
}
