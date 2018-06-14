using System.Collections.Generic;

namespace TestForm.Models
{
    public class FormResponse
    {
        public bool success { get; set; }
        public Dictionary<string, object> data { get; set; }
    }
}