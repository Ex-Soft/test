using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestMasterDetail
{
    [Serializable]
    public partial class Master
    {
        public string Val { get; set; }

        [XmlElement("Detail")]
        public List<Detail> Details { get; set; }

        public Master()
        {
            Details = new List<Detail>();
        }
    }
}
