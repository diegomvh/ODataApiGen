using System;
using System.Collections.Generic;
using System.Linq;
using Od2Ts.Interfaces;

namespace Od2Ts.Extensions
{
    public class ImportRecord
    {
        public string ElementTypeName { get; set; }
        public Uri RelativeNamespace { get; set; }
    }

    public static class ImportsExtensions
    {
        public static IEnumerable<ImportRecord> GetImportRecords(this IHasImports element, bool useInterface)
        {
            var records = element.Imports(useInterface).Where(a => a.Uri != element.Uri).Select(a =>
            {
                var record = new ImportRecord()
                {
                    RelativeNamespace = element.Uri.MakeRelativeUri(a.Uri),
                    ElementTypeName = a.Uri.Segments.Last()
                };
                return record;
            });
            return records;
        }
    }
}
