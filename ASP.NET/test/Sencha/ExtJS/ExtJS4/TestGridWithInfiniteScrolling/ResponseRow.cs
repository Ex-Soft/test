using System.Collections.Generic;

namespace TestGridWithInfiniteScrolling
{
    public class ResponseRow
    {
        public bool success { get; set; }
        public int total { get; set; }
        public string message { get; set; }
        public List<Row> rows { get; set; }
    }
}