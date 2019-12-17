using System;
using System.Xml.Linq;

namespace ODataApiGen.Models.Annotations
{
    public class Annotation 
    {
        public Annotation(XElement element)
        {
            Term = element.Attribute("Term")?.Value;
        }

        public string Term { get; set; }
    }
}
/*
Org.OData.Core.V1.Permissions
Org.OData.Core.V1.Computed
Org.OData.Core.V1.Immutable
Org.OData.Core.V1.ResourcePath
Org.OData.Core.V1.OptimisticConcurrency
Org.OData.Core.V1.DereferenceableIDs
Org.OData.Core.V1.ConventionalIDs
Org.OData.Measures.V1.ISOCurrency
Org.OData.Measures.V1.Scale
Org.OData.Capabilities.V1.NavigationRestrictions
Org.OData.Capabilities.V1.SearchRestrictions
Org.OData.Capabilities.V1.InsertRestrictions
Org.OData.Capabilities.V1.SearchRestrictions
Org.OData.Capabilities.V1.InsertRestrictions
Org.OData.Capabilities.V1.DeleteRestrictions
Org.OData.Capabilities.V1.ConformanceLevel
Org.OData.Capabilities.V1.SupportedFormats
Org.OData.Capabilities.V1.AsynchronousRequestsSupported
Org.OData.Capabilities.V1.BatchContinueOnErrorSupported
Org.OData.Capabilities.V1.FilterFunctions
*/