using System;

namespace TestJsonNET
{
    public class LicenseObject
    {
        public object LicenseKey { get; set; }
        public byte[] Signature { get; set; }
    }
    public class LicenseKey
    {
        public DateTime ExpirationDate { get; set; }
        public DateTimeOffset ExpirationDateTimeOffset { get; set; }
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public Guid ProductId { get; set; }
        public object Version { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public long? DistributorId { get; set; }
        public string DistributorName { get; set; }
    }
}
