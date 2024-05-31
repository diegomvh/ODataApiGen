using System.Dynamic;
using System.Xml.Linq;

static class XElementExtensions
{
    public static dynamic ToDynamic(
        this XElement element, 
        string nameProperty = "Name",
        string valueProperty = "Value",
        string elementsMethod = "Elements")
    {
        var result = new ExpandoObject() as IDictionary<string, object>;

        // Node name and value
        result[nameProperty] = element.Name.LocalName;
        result[valueProperty] = element.Value;

        // Add each attribute to the expando object
        foreach (var attribute in element.Attributes())    
        {
            result[attribute.Name.LocalName] = attribute.Value;
        }

        // Children element list (to be populated) and method to enumerate over them
        var children = new List<dynamic>();
        result[elementsMethod] = new Func<IEnumerable<dynamic>>(() => children);

        // Add each child node to the expando object and children list
        foreach (var child in element.Elements())
        {        
            var node = ToDynamic(child, nameProperty, valueProperty, elementsMethod);
            children.Add(node);

            var nodeName = (node as IDictionary<string, object>)[nameProperty].ToString();

            // If we haven't seen the node name before, add it as a property
            if (!result.ContainsKey(nodeName))
            {
                result[nodeName] = node;
                continue;
            }

            // If we've seen it once, replace with a list
            if (!(result[nodeName] is List<dynamic>))
            {
                result[nodeName] = new List<dynamic>() { result[nodeName] };
            }
                
            (result[nodeName] as List<dynamic>).Add(node);
        }

        return result;
    }
}