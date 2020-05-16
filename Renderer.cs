using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using DotLiquid;
using DotLiquid.FileSystems;
using Microsoft.Extensions.Logging;
using ODataApiGen.Abstracts;

namespace ODataApiGen
{
    class FileChunk {
        public string Name {get; set;}
        public string Content {get; set;}
    }
    public class Renderer
    {
        private ILogger Logger { get; } = Program.LoggerFactory.CreateLogger<Renderer>();
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
            var content = template.Render(Hash.FromAnonymousObject(entity, true));

            var path = $"{Output}{Path.DirectorySeparatorChar}";
            if (!String.IsNullOrWhiteSpace(entity.Directory))
                path += $"{entity.Directory}{Path.DirectorySeparatorChar}";
            path += $"{entity.FileName}.ts";
            path = Path.GetFullPath(path);

            if (!File.Exists(path)) {
                Logger.LogDebug($"Writing: {path}");
                File.WriteAllText(path, content, System.Text.Encoding.UTF8);
            } else {
                // Merge regions
                Logger.LogDebug($"Merge: {path}");
                var chunks = this.Chunkenizer(content);
                content = String.Empty;
                var current = File.ReadAllText(path, System.Text.Encoding.UTF8);
                var currentChunks = this.Chunkenizer(current);
                foreach (var chunk in currentChunks) {
                    if (!String.IsNullOrEmpty(chunk.Name)) {
                        content += chunks.FirstOrDefault(c => c.Name == chunk.Name)?.Content;
                    } else {
                        content += chunk.Content;
                    }
                }
                File.WriteAllText(path, content, System.Text.Encoding.UTF8);
            }
        }

        private IEnumerable<FileChunk> Chunkenizer(string text) {
            var chunks = new List<FileChunk>();
            while (true) {
                var start = Regex.Match(text, @"//#region ODataApi (\w+)");
                if (!start.Success)
                    break;
                chunks.Add(new FileChunk() {
                    Content = text.Substring(0, start.Index)
                });
                text = text.Substring(start.Index);
                var end = Regex.Match(text, @"//#endregion");
                if (!end.Success) 
                    break;
                chunks.Add(new FileChunk() { 
                    Name = start.Groups[1].Value, 
                    Content = text.Substring(0, end.Index + end.Length)
                });
                text = text.Substring(end.Index + end.Length);
            }
            chunks.Add(new FileChunk() {
                Content = text
            });
            return chunks;
        }

        public void Render(Package package) {
            foreach (var renderable in package.Renderables)
            {
                DoRender(renderable);
            }
        }
    }
}
