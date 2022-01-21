using AthenaNetCore.BusinessLogic.Entities;

namespace TestS3
{
    public class EventItem
    {
        [AthenaColumn("id")]
        public string Id { get; set; }

        [AthenaColumn("groupId")]
        public int GroupId { get; set; }

        [AthenaColumn("value")]
        public string Value { get; set; }

        [AthenaColumn("fDateTime")]
        public DateTime FDateTime { get; set; }

        [AthenaColumn("fTimeStamp")]
        public DateTime FTimeStamp { get; set; }
    }
}
