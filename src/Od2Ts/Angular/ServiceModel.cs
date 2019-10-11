using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Od2Ts.Models;

namespace Od2Ts.Angular
{
    public class ServiceModel : Service
    {
        public ServiceModel(EntitySet type, bool refe) : base(type, refe)
        {
        }
        public override IEnumerable<Import> Imports => GetImportRecords();
        public string ModelName => this.Model.Name;
        public string CollectionName => this.Collection.Name;
    }
}