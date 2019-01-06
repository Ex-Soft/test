using System;
using System.Runtime.Serialization;

namespace TestCircularReference
{
    [DataContract(IsReference = true)]
    public class D
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int PInt { get; set; }
    }
}
