using System.Collections.Generic;

namespace TestGrid.remote.app.handlers
{
    public class ResponseStaff
    {
        public bool success { get; set;}
        public int total { get; set; }
        public string message { get; set; }
        public List<models.Staff> staffs { get; set; }
    }
}