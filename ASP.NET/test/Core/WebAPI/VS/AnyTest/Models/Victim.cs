namespace AnyTest.Models
{
    public class Victim
    {
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{{Value:{(Value != null ? $"\"{Value}\"" : "null")}}}";
        }
    }
}
