namespace WinFormsApp.Domain
{
	public class SmthEntity : ISmthEntity
	{
        public int FInt { get; set; }
        public string FString { get; set; }
        public decimal FDecimal { get; set; }

        public SmthEntity(int fInt = 0, string fString = "", decimal fDecimal = 0M)
        {
            FInt = FInt;
            FString = fString;
            FDecimal = fDecimal;
        }

        public SmthEntity(SmthEntity obj) : this(obj.FInt, obj.FString, obj.FDecimal)
        {}
    }
}
