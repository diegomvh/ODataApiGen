using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Od2Ts.Models;

namespace Od2Ts.Angular
{
    public class ServiceModel : Service
    {
        public ServiceModel(EntitySet type) : base(type)
        {
        }
        public override IEnumerable<Import> Imports => GetImportRecords();
        public string ModelType => this.Model.Type;
        public string ModelName => this.Model.Name;
        public string CollectionType => this.Collection.Type;
        public string CollectionName => this.Collection.Name;
    }
}