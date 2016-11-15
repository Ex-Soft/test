using System.Reflection;

namespace IEnumerableToXls.Export
{
    class PropertyInfoForExport
    {
        public PropertyInfo PropertyInfo { get; private set; }
        public string ColumnName { get; private set; }

        public PropertyInfoForExport(PropertyInfo propertyInfo, string columnName)
        {
            PropertyInfo = propertyInfo;
            ColumnName = columnName;
        }
    }
}
