using System.Runtime.Serialization;

namespace TestWCF
{
    [DataContract]
    public class DataContract : IDataContract
    {
        [DataMember]
        public string StringField { get; set; }
    }
}
