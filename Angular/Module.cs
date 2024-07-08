using ODataApiGen.Abstracts;

namespace ODataApiGen.Angular
{
    public class Module : AngularRenderable
    {
        public Angular.Package Package {get; private set;}
        public Module(Package package, ApiOptions options) : base(options)
        {
            Package = package;
        }
        public override string Name => this.Package.Name + "Module";
        public override string FileName => this.Package.Name.Dasherize() + ".module";
        public override string Directory => "";
        public IEnumerable<Service> Services => this.Package.Schemas.SelectMany(s => s.Containers.Select(c => c.Service))
        .Union(this.Package.Schemas.SelectMany(s => s.Containers.SelectMany(c => c.Services)));
        // Imports and Exports
        public override IEnumerable<string> ImportTypes => this.Package.Schemas.SelectMany(s => s.Containers.SelectMany(c => c.Services)).Select(a => a.ServiceType);
        public override IEnumerable<Import> Imports => GetImportRecords();
    }
}
