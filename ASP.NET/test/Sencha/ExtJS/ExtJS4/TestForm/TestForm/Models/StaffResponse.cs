using System.Collections.Generic;

namespace TestForm.Models
{
    public class StaffResponse
    {
        public bool success { get; set; }
        public int total { get; set; }
        public string message { get; set; }
        public List<Staff> rows { get; set; }
    }
}