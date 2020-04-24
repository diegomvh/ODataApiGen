using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
    public class Annotable 
    {
        public Annotable(XElement element) {
            Annotations = element.Descendants().Where(a => a.Name.LocalName == "Annotation")
                .Select(annot => Annotation.Factory(annot)).ToList();
        }
        public List<Annotation> Annotations {get; set;}

        public T FindAnnotation<T>(string term) where T: Annotation {
            return this.Annotations.Where(a => a.Term == term).FirstOrDefault() as T;
        }
    }
}
