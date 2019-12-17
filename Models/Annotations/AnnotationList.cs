using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models.Annotations
{
    public class AnnotationList : List<Annotation>
    {
        public AnnotationList(XElement element, Schema schema)
        {
            this.Target = element.Attribute("Name")?.Value;
            this.AddRange(element.Descendants().Where(a => a.Name.LocalName == "Annotation")
                .Select(annot => new Annotation(annot)));
        }
        public string Target { get; set; }
    }
}
