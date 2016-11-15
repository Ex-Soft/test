namespace AccessToApplication
{
	class AccessToApplication
	{
		public static System.Web.HttpApplicationState
			Applications=null;

		public static bool IsUserOnlineExists()
		{
			bool
				Result=false;

			int
				tmpUserOnline=0;

			if(Applications!=null)
				tmpUserOnline=(int)Applications["UserOnline"];

            Result = tmpUserOnline>0;

			return(Result);
		}
	}
}