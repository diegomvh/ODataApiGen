using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

/*
https://github.com/oasis-tcs/odata-vocabularies/tree/master/vocabularies
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
namespace ODataApiGen.Models
{
    public class Annotable 
    {
        public Annotable(XElement element) {
            Annotations = element.Descendants().Where(a => a.Name.LocalName == "Annotation")
                .Select(annot => annot.ToDynamic()).ToList();
        }
        public List<dynamic> Annotations {get; set;}

        public dynamic Annotation(string term) {
            return this.Annotations.Where(a => a.Term == term).FirstOrDefault();
        }
    }
}
