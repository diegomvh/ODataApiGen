using System.Collections.Generic;
using System.Linq;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public class Model : Structured 
    {
        public Angular.Entity Entity { get; private set; }
        public Angular.BaseModel BaseModel { get; private set; }

        public Model(StructuredType type, Angular.Entity entity, Angular.BaseModel baseModel) : base(type) {
            this.Entity = entity;
            this.Dependencies.Add(entity);
            this.BaseModel = baseModel;
            this.Dependencies.Add(baseModel);
        }
        public Angular.Collection Collection {get; private set;}

        public void SetCollection(Collection collection)
        {
            this.Collection = collection;
        }
        public override string FileName => this.EdmStructuredType.Name.ToLower() + ".model";
        public override string Name => this.EdmStructuredType.Name + "Model";
        public override bool Overwrite => false;
        public override IEnumerable<string> ImportTypes
        {
            get
            {
                var list = new List<string> {
                    this.EntityType
                };
                list.AddRange(this.EdmStructuredType.Properties.Select(a => a.Type));
                list.AddRange(this.EdmStructuredType.Actions.SelectMany(a => this.CallableNamespaces(a)));
                list.AddRange(this.EdmStructuredType.Functions.SelectMany(a => this.CallableNamespaces(a)));
                if (this.EdmStructuredType is EntityType)
                    list.AddRange((this.EdmStructuredType as EntityType).NavigationProperties.Select(a => a.Type));
                return list;
            }
        }
        public override IEnumerable<string> ExportTypes => new string[] { this.Name };

        public override IEnumerable<Angular.StructuredProperty> Properties => Enumerable.Empty<Angular.StructuredProperty>();
        public IEnumerable<string> Actions => Enumerable.Empty<string>();
        public IEnumerable<string> Functions => Enumerable.Empty<string>();
        public IEnumerable<string> Navigations => Enumerable.Empty<string>();
        public override object ToLiquid()
        {
            return new {
                Name = this.Name,
                Type = this.Type,
                EntityType = this.EntityType,
                Interface = new {
                    Name = this.Entity.Name
                }
            };
        }
    }
}