using System.Collections.Generic;
using System.IO;

namespace IEnumerableToXls.Export
{
    interface IExport
    {
        MemoryStream Export<T>(IEnumerable<T> data, Dictionary<string, ExportInfo> exportInfos);
    }
}
