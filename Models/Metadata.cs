using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Extensions.Logging;

namespace ODataApiGen.Models
{
    public class Metadata 
    {
        private static ILogger Logger {get;} = Program.LoggerFactory.CreateLogger<Metadata>();
        public List<Schema> Schemas { get; private set; }
        public string Namespace => 
            this.Schemas.Select(s => s.Namespace).OrderBy(n => n.Length).FirstOrDefault();
        public IEnumerable<EnumType> EnumTypes => this.Schemas.SelectMany(s => s.EnumTypes);
        public IEnumerable<ComplexType> ComplexTypes => this.Schemas.SelectMany(s => s.ComplexTypes);
        public IEnumerable<EntityType> EntityTypes => this.Schemas.SelectMany(s => s.EntityTypes);
        public IEnumerable<Function> Functions => this.Schemas.SelectMany(s => s.Functions);
        public IEnumerable<Action> Actions => this.Schemas.SelectMany(s => s.Actions);
        public IEnumerable<KeyValuePair<string, List<Annotation>>> Annotations => this.Schemas.SelectMany(s => s.Annotations);
        public IEnumerable<Function> UnboundFunctions => this.Schemas.SelectMany(s => s.Functions).Where(f => !f.IsBound);
        public IEnumerable<Action> UnboundActions => this.Schemas.SelectMany(s => s.Actions).Where(f => !f.IsBound);

        #region Static Loaders
        public static List<Schema> ReadSchemas(XDocument xdoc)
        {
            Logger.LogDebug("Parsing entity types...");
            var schemas = new List<Schema>();
            var elements = xdoc.Descendants().Where(a => a.Name.LocalName == "Schema");
            
            foreach (var xElement in elements)
            {
                var entity = new Schema(xElement);
                schemas.Add(entity);
                Logger.LogInformation($"Schema Type '{entity.Namespace}' parsed");
            }
            return schemas;
        }
        #endregion
        public Metadata(XDocument xDoc) 
        {
            this.Schemas = Metadata.ReadSchemas(xDoc);
            foreach (var schema in this.Schemas) {
                schema.ResolveFunctions(this.Functions);
                schema.ResolveActions(this.Actions);
                schema.ResolveAnnotations(this.Annotations);
            }
        }
    }
}
