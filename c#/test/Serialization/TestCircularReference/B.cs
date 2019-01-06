using System;
using System.Runtime.Serialization;

namespace TestCircularReference
{
    [DataContract(IsReference = true)]
    public class B
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public C PC { get; set; }
        [DataMember]
        public D PD { get; set; }
    }
}
