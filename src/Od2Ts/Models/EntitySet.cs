using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Od2Ts.Interfaces;

namespace Od2Ts.Models
{
    public class EntitySet : IHasImports
    {
        public EntitySet(XElement xElement,
        IEnumerable<CustomAction> customActions, IEnumerable<CustomFunction> customFunctions)
        {
            EntitySetName = xElement.Attribute("Name")?.Value;
            Name = char.ToUpper(EntitySetName[0]) + EntitySetName.Substring(1) + "ODataService";
            EntityType = xElement.Attribute("EntityType")?.Value;
            NameSpace =
                xElement.Ancestors().FirstOrDefault(a => a.Attribute("Namespace") != null)?.Attribute("Namespace").Value;
            CustomActions = customActions.Where(a => a.BindingParameter == EntityType);
            CustomFunctions = customFunctions.Where(a => a.BindingParameter == EntityType);
        }

        public string Name { get; private set; }
        public string NameSpace { get; private set; }
        public string EntityType { get; private set; }
        public string EntitySetName { get; private set; }

        private Uri _uri;
        public Uri Uri => _uri ?? (_uri = new Uri("r://" + NameSpace.Replace(".", Path.DirectorySeparatorChar.ToString()) + Path.DirectorySeparatorChar + Name, UriKind.Absolute));

        public IEnumerable<Uri> Imports(bool useInterface)
        {
            var list = new List<Uri>
                {
                    new Uri("r://" + EntityType.Replace(".", Path.DirectorySeparatorChar.ToString()), UriKind.Absolute),
                    new Uri("r://ODataContext", UriKind.Absolute)
                };
            list.AddRange(CustomActions.SelectMany(a => a.Imports(useInterface)));
            list.AddRange(CustomFunctions.SelectMany(a => a.Imports(useInterface)));
            return list.Distinct();
        }

        public IEnumerable<CustomAction> CustomActions { get; set; }
        public IEnumerable<CustomFunction> CustomFunctions { get; set; }
    }
}
