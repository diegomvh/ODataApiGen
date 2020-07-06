using System;
using System.Collections.Generic;
using System.Linq;
using ODataApiGen.Abstracts;
using ODataApiGen.Models;

namespace ODataApiGen.Angular
{
    public abstract class AngularRenderable : ODataApiGen.Abstracts.Renderable
    {
        public AngularRenderable(ApiOptions options) : base(options) {}
        public string ToTypescript(string type)
        {
            if (String.IsNullOrEmpty(type)) return "any";
            if (Options.GeoJson && (type.StartsWith("Edm.Geography") || type.StartsWith("Edm.Geometry"))) {
                switch (type)
                {
                    case "Edm.Geography": //Abstract base type for all Geography types
                    case "Edm.GeographyPoint": //A point in a round-earth coordinate system
                        return "Point";
                    case "Edm.GeographyMultiPoint": //Collection of points in a round-earth coordinate system
                        return "MultiPoint";
                    case "Edm.GeographyLineString": //Line string in a round-earth coordinate system
                        return "LineString";
                    case "Edm.GeographyMultiLineString": //Collection of line strings in a round-earth coordinate system
                        return "MultiLineString";
                    case "Edm.GeographyPolygon": //Polygon in a round-earth coordinate system
                        return "Polygon";
                    case "Edm.GeographyMultiPolygon": //Collection of polygons in a round-earth coordinate system
                        return "MultiPolygon";
                    case "Edm.GeographyCollection": //Collection of arbitrary Geography values
                        return "GeometryCollection";
                    case "Edm.Geometry": //Abstract base type for all Geometry types
                    case "Edm.GeometryPoint": //Point in a flat-earth coordinate system
                        return "Point";
                    case "Edm.GeometryMultiPoint": //Collection of points in a flat-earth coordinate system
                        return "MultiPoint";
                    case "Edm.GeometryLineString": //Line string in a flat-earth coordinate system
                        return "LineString";
                    case "Edm.GeometryMultiLineString": //Collection of line strings in a flat-earth coordinate system
                        return "MultiLineString";
                    case "Edm.GeometryPolygon": //Polygon in a flat-earth coordinate system
                        return "Polygon";
                    case "Edm.GeometryMultiPolygon": //Collection of polygons in a flat-earth coordinate system
                        return "MultiPolygon";
                    case "Edm.GeometryCollection": //Collection of arbitrary Geometry values
                        return "GeometryCollection";
                }
            }
            switch (type)
            {
                case "Edm.String": //Sequence of UTF-8 characters
                case "Edm.Duration": //Signed duration in days, hours, minutes, and (sub)seconds
                case "Edm.Guid": //16-byte (128-bit) unique identifier
                case "Edm.Binary": //Binary data
                    return "string";
                case "Edm.Int16": //Signed 16-bit integer
                case "Edm.Int32": //Signed 32-bit integer
                case "Edm.Int64": //Signed 64-bit integer
                case "Edm.SByte": //Signed 8-bit integer
                case "Edm.Byte": //Unsigned 8-bit integer
                case "Edm.Single": //IEEE 754 binary32 floating-point number (6-9 decimal digits)
                case "Edm.Decimal": //Numeric values with fixed precision and scale
                case "Edm.Double": //IEEE 754 binary64 floating-point number (15-17 decimal digits)
                    return "number";
                case "Edm.Boolean": //Binary-valued logic
                    return "boolean";
                case "Edm.DateTimeOffset": //Date and time with a time-zone offset, no leap seconds
                case "Edm.Date": //Date without a time-zone offset
                case "Edm.TimeOfDay": //Clock time 00:00-23:59:59.999999999999
                    return "Date";
                case "Edm.Stream": //Binary data stream
                default:
                    {
                        return type.Contains(".") && !type.StartsWith("Edm") ? type.Split('.').Last(a => !String.IsNullOrWhiteSpace(a)) : "any";
                    }
            }
        }
        public IEnumerable<string> CallableNamespaces(Callable callable)
        {
            var uriList = new List<string>();
            if (!string.IsNullOrWhiteSpace(callable.ReturnType) && !callable.IsEdmReturnType)
            {
                uriList.Add(callable.ReturnType);
            }
            if (!string.IsNullOrWhiteSpace(callable.BindingParameter))
            {
                uriList.Add(callable.BindingParameter);
            }
            foreach (var param in callable.Parameters)
            {
                uriList.Add(param.Type);
            }
            return uriList;
        }
        public IEnumerable<string> RenderImports()
        {
            return this.GetImportRecords().Select(r =>
            {
                var path = r.From.ToString();
                if (!path.StartsWith("../"))
                    path = $"./{path}";
                return $"import {{ {String.Join(", ", r.Names)} }} from '{path}';";
            });
        }
        public abstract IEnumerable<Import> Imports { get; }
        protected IEnumerable<Import> GetImportRecords()
        {
            var records = this.Dependencies.Where(a => a.Uri != this.Uri).GroupBy(i => i.Uri).Select(group =>
            {
                var uri = this.Uri.MakeRelativeUri(group.First().Uri);
                var names = group.SelectMany(d => d.ExportTypes).Distinct();
                return new Import(names, uri);
            });
            return records;
        }
    }
}