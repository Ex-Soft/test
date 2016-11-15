namespace WebApp.Domain
{
	public class SmthEntity : ISmthEntity
	{
		public string FString { get; set; }

		public SmthEntity(string fString = "")
		{
			FString = fString;
		}

		public SmthEntity(SmthEntity obj) : this(obj.FString)
		{}
	}
}
