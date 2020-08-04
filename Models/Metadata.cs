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
        public string Version { get; private set; }
        public List<Schema> Schemas { get; private set; }
        public string Namespace => 
            this.Schemas.Select(s => s.Namespace).OrderBy(n => n.Length).FirstOrDefault();
        public IEnumerable<EnumType> EnumTypes => this.Schemas.SelectMany(s => s.EnumTypes);
        public EnumType FindEnumType(string type) {
            return this.EnumTypes.FirstOrDefault(e => e.IsTypeOf(type));
        }
        public IEnumerable<ComplexType> ComplexTypes => this.Schemas.SelectMany(s => s.ComplexTypes);
        public ComplexType FindComplexType(string type) {
            return this.ComplexTypes.FirstOrDefault(c => c.IsTypeOf(type));
        }
        public IEnumerable<EntityType> EntityTypes => this.Schemas.SelectMany(s => s.EntityTypes);
        public EntityType FindEntityType(string type) {
            return this.EntityTypes.FirstOrDefault(c => c.IsTypeOf(type));
        }
        public IEnumerable<Function> Functions => this.Schemas.SelectMany(s => s.Functions);
        public IEnumerable<Action> Actions => this.Schemas.SelectMany(s => s.Actions);
        public IEnumerable<Association> Associations => this.Schemas.SelectMany(s => s.Associations);
        public IEnumerable<EntitySet> EntitySets => this.Schemas.SelectMany(s => s.EntityContainers.SelectMany(c => c.EntitySets));
        public IEnumerable<KeyValuePair<string, List<Annotation>>> Annotations => this.Schemas.SelectMany(s => s.Annotations);

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
            this.Version = xDoc.Descendants().FirstOrDefault(a => a.Name.LocalName == "Edmx").Attribute("Version")?.Value;
            if (this.Version == "1.0") {
                this.Version = xDoc.Descendants().FirstOrDefault(a => a.Name.LocalName == "DataServices").Attributes().FirstOrDefault(a => a.Name.LocalName == "DataServiceVersion")?.Value;
            }
            this.Schemas = Metadata.ReadSchemas(xDoc);
            foreach (var schema in this.Schemas) {
                schema.ResolveFunctions(this.Functions);
                schema.ResolveActions(this.Actions);
                schema.ResolveAssociations(this.Associations);
                schema.ResolveAnnotations(this.Annotations);
            }
        }
    }
}
