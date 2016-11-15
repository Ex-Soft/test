using System.Collections.Generic;

namespace TestGridWithSelTypeCheck
{
    public class StaffResponse
    {
        public bool success { get; set;}
        public int total { get; set; }
        public string message { get; set; }
        public List<Staff> staff { get; set; }
    }
}