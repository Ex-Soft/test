using System;
using System.Runtime.Serialization;

namespace TestCircularReference
{
    [DataContract(IsReference = true)]
    public class C
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int PInt { get; set; }
        [DataMember]
        public D PD { get; set; }
    }
}
