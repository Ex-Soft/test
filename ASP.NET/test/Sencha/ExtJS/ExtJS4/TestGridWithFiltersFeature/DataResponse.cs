using System.Collections.Generic;

namespace TestGridWithFiltersFeature
{
    public class DataResponse
    {
        public bool success { get; set;}
        public int total { get; set; }
        public string message { get; set; }
        public List<Data> data { get; set; }
    }
}