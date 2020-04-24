using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ODataApiGen.Models
{
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
    public class Annotation
    {
        protected dynamic Value;
        public string Term => this.Value.Term;
        public Annotation(object value) {
            Value = value;
        }

        public static Annotation Factory(XElement element) {
           var dyn = element.ToDynamic(); 
           switch(dyn.Term) {
               case "Org.OData.Core.V1.Computed": return new CoreComputedAnnotation(dyn);
               case "Org.OData.Core.V1.Immutable": return new CoreImmutableAnnotation(dyn);
               case "Org.OData.Core.V1.Permissions": return new CorePermissionsAnnotation(dyn);
               case "Org.OData.Measures.V1.ISOCurrency": return new MeasuresISOCurrencyAnnotation(dyn);
               case "Org.OData.Measures.V1.Scale": return new MeasuresScaleAnnotation(dyn);
           }
           return new Annotation(dyn);
        }
        public virtual IDictionary<string, object> ToDictionary()
        {         
            var result = new Dictionary<string, object>();
            result.Add("type", this.Term);
            return result;
        }
    }

    public class CoreComputedAnnotation : Annotation
    {
        public bool Bool => this.Value.Bool.ToLower() == "true";
        public CoreComputedAnnotation(object value) : base(value)
        {
        }
        public override IDictionary<string, object> ToDictionary() {
            var result = base.ToDictionary();
            result.Add("bool", this.Bool);
            return result;
        }
    }
    public class CoreImmutableAnnotation : Annotation
    {
        public bool Bool => this.Value.Bool.ToLower() == "true";
        public CoreImmutableAnnotation(object value) : base(value)
        {
        }
        public override IDictionary<string, object> ToDictionary() {
            var result = base.ToDictionary();
            result.Add("bool", this.Bool);
            return result;
        }
    }
    public class CorePermissionsAnnotation : Annotation
    {
        public IEnumerable<string> Permissions => ((List<dynamic>)this.Value.Elements()).Select(ele => ele.Value as string);
        public CorePermissionsAnnotation(object value) : base(value)
        {
        }
        public override IDictionary<string, object> ToDictionary() {
            var result = base.ToDictionary();
            result.Add("permissions", this.Permissions);
            return result;
        }
    }
    public class MeasuresISOCurrencyAnnotation : Annotation
    {
        public string String => this.Value.String;
        public MeasuresISOCurrencyAnnotation(object value) : base(value)
        {
        }
        public override IDictionary<string, object> ToDictionary() {
            var result = base.ToDictionary();
            result.Add("string", this.String);
            return result;
        }
    }
    public class MeasuresScaleAnnotation : Annotation
    {
        public int Int => Convert.ToInt32(this.Value.Int);
        public MeasuresScaleAnnotation(object value) : base(value)
        {
        }
        public override IDictionary<string, object> ToDictionary() {
            var result = base.ToDictionary();
            result.Add("int", this.Int);
            return result;
        }
    }
}
