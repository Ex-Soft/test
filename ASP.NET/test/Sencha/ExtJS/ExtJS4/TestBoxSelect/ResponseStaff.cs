using System.Collections.Generic;

namespace TestBoxSelect
{
    public class ResponseStaff
    {
        public bool success { get; set;}
        public int total { get; set; }
        public string message { get; set; }
        public List<Staff> staffs { get; set; }
    }
}