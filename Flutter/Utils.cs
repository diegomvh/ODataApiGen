using System.Text.RegularExpressions;

namespace ODataApiGen.Flutter
{
    public enum DartElement {
        Enum,
        Class,
        Attribute,
        Method,
        Function,
        Constant
    }

    public static class Utils {
        public static char[] TypeScriptInvalidNameChars = new char[] {'-', '(', ')'};
        public static bool IsValidTypeScrtiptName(string name) {
            return !name.Any(c => TypeScriptInvalidNameChars.Contains(c));
        }
        public static string ToDartName(string name, DartElement type) {
            var sep = "";
            var parts = Regex.Split(name, @"(?<!^)(?=[A-Z])|[-_]").Where(p => !String.IsNullOrWhiteSpace(p)).ToArray();
            switch (type) {
                case DartElement.Constant:
                    parts = parts.Select(p => p.ToUpper()).ToArray();
                    sep = "_";
                    break;
                case DartElement.Enum:
                case DartElement.Class:
                    parts = parts.Select(p => p[0].ToString().ToUpper() + p.Substring(1)).ToArray();
                    break;
                case DartElement.Attribute:
                case DartElement.Function:
                case DartElement.Method:
                    parts = parts.Select(p => p[0].ToString().ToUpper() + p.Substring(1)).ToArray();
                    parts[0] = parts[0].ToLower();
                    break;
            }
            return string.Join(sep, parts);
        }
        public static string ToDartType(string type, bool geo = true)
        {
            if (String.IsNullOrEmpty(type)) return "dynamic";
            if (geo && (type.StartsWith("Edm.Geography") || type.StartsWith("Edm.Geometry"))) {
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
                case "Edm.Guid": //16-byte (128-bit) unique identifier
                    return "String";
                case "Edm.Binary": //Binary data
                    return "ByteBuffer";
                case "Edm.Duration": //Signed duration in days, hours, minutes, and (sub)seconds
                    return "Duration";
                case "Edm.Int16": //Signed 16-bit integer
                case "Edm.Int32": //Signed 32-bit integer
                case "Edm.Int64": //Signed 64-bit integer
                case "Edm.SByte": //Signed 8-bit integer
                case "Edm.Byte": //Unsigned 8-bit integer
                    return "int";
                case "Edm.Single": //IEEE 754 binary32 floating-point number (6-9 decimal digits)
                case "Edm.Decimal": //Numeric values with fixed precision and scale
                case "Edm.Double": //IEEE 754 binary64 floating-point number (15-17 decimal digits)
                    return "double";
                case "Edm.Boolean": //Binary-valued logic
                    return "bool";
                case "Edm.DateTimeOffset": //Date and time with a time-zone offset, no leap seconds
                case "Edm.Date": //Date without a time-zone offset
                case "Edm.TimeOfDay": //Clock time 00:00-23:59:59.999999999999
                    return "DateTime";
                case "Edm.Stream": //Binary data stream
                default:
                    {
                        return type.Contains(".") && !type.StartsWith("Edm") ? 
                            Utils.ToDartName(type.Split('.').Last(a => !String.IsNullOrWhiteSpace(a)), DartElement.Class) : 
                            "dynamic";
                    }
            }
        }
    }

    public static class Filters
    {
        public static string Parameters(IEnumerable<CallableParameterConfig> parameters) {
            return string.Join(", ", parameters.Select(p => $"{p.Name}: {p.Type}"));
        }
        public static string Methodcase(string name) {
            return Utils.ToDartName(name, DartElement.Method);
        }
    }
}
