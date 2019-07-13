using System.Collections.Generic;

namespace TodoApi
{
    public class PersonnelResponse
    {
        public bool success {get; set;}
        public int total {get; set;}
        public string message {get; set;}
        public IEnumerable<Personnel> data {get; set;}

        public PersonnelResponse(bool success = false, IEnumerable<Personnel> data = null, int total = 0, string message = "")
        {
            this.success = success;
            this.data = data;
            this.total = total;
            this.message = message;
        }
    }
}