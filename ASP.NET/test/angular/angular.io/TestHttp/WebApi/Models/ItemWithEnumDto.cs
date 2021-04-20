using System.Text.Json.Serialization;

namespace WebApi.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TestEnum
    {
        Zero,
        First,
        Second,
        Third,
        Fourth,
        Fifth
    }

	public class ItemWithEnumDto
    {
        public int Id { get; set; }
        public TestEnum Value { get; set; }
    }
}
