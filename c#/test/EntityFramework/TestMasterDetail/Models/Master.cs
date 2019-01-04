using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestMasterDetail.Models
{
    [Serializable]
    public partial class Master
    {
        public string Val { get; set; }

        [XmlElement("Detail")]
        public ICollection<Detail> Details { get; set; }

        public Master()
        {
            Details = new List<Detail>();
        }
    }
}
