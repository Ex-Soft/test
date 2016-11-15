namespace TestReflection
{
    public class ExportInfo
    {
        public string ColumnName { get; private set; }
        public int Order { get; private set; }

        public ExportInfo(string columnName, int order)
        {
            ColumnName = columnName;
            Order = order;
        }
    }
}
