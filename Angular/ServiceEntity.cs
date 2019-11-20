using System;
using System.Collections.Generic;
using System.Linq;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public class ServiceEntity : Service
    {
        public ServiceEntity(EntitySet type) : base(type) { }
        public ServiceEntity(Singleton type) : base(type) { }
        public override IEnumerable<Import> Imports => GetImportRecords();

        public string EntityName => this.Entity.Name;
        public string EntityType => this.Entity.Type;
        public IEnumerable<string> Actions =>  this.RenderCallables(this.EdmEntitySet != null ? this.EdmEntitySet.Actions : this.EdmSingleton.Actions);
        public IEnumerable<string> Functions => this.RenderCallables(this.EdmEntitySet != null ? this.EdmEntitySet.Functions : this.EdmSingleton.Functions);
        public IEnumerable<string> Navigations => this.RenderReferences(this.Entity.EdmStructuredType.NavigationProperties);
    }
}