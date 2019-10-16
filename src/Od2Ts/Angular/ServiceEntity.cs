using System;
using System.Collections.Generic;
using System.Linq;
using Od2Ts.Models;

namespace Od2Ts.Angular
{
    public class ServiceEntity : Service
    {
        public ServiceEntity(EntitySet type, bool refe) : base(type, refe)
        {
        }
        public override IEnumerable<Import> Imports => GetImportRecords();
        public string ResolveKey
        {
            get
            {
                var model = this.Model;
                var keys = model.EdmStructuredType.Keys.ToList();
                var baseModel = model.Base;
                while (baseModel != null)
                {
                    keys.AddRange(model.Base.EdmStructuredType.Keys);
                    baseModel = baseModel.Base;
                }
                switch (keys.Count())
                {
                    case 0:
                        return "";
                    case 1:
                        return $"entity.{keys.First().Name}";
                    default:
                        var parts = keys.Select(k =>
                            !String.IsNullOrEmpty(k.Alias) ?
                                $"{k.Alias}: entity.{k.Name.Replace('/', '.')}" :
                                $"{k.Name}: entity.{k.Name}");
                        return $"{{{String.Join(", ", parts)}}}";
                }
            }
        }

        public string EntityName => this.Model.Name;
        public string EntityType => this.Model.Type;
        public IEnumerable<string> Actions => this.RenderCallables(this.EdmEntitySet.CustomActions);
        public IEnumerable<string> Functions => this.RenderCallables(this.EdmEntitySet.CustomFunctions);
        public IEnumerable<string> Navigations => this.RenderReferences(this.Model.EdmStructuredType.NavigationProperties);
    }
}