using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LessonProject.Models.Info
{
    public class Customer
    {
        public int ID { get; set; } 
        public string Name { get; set; }

        public Dictionary<string,Ownership> Ownerships { get; set; }
    }
}