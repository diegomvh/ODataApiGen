using System;
using System.Net;
using System.Xml.Linq;

namespace Od2Ts
{
    public class Loader
    {
        public static XDocument Load(string source)
        {
            return XDocument.Load(source);
        }
    }
}
