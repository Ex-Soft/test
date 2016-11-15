using System;

namespace EventClass
{
	public class EventClassArgs:EventArgs
	{
		public readonly int
			ArgInt;

		public readonly string
			ArgString;

		public EventClassArgs(int aArgInt, string aArgString)
		{
			ArgInt=aArgInt;
			ArgString=aArgString;
		}
	}

	public delegate bool EventClassHandler(object sender, EventClassArgs args);

	public class EventClass
	{
		public event EventClassHandler
			SomeEvent;

		public void OnSomeEvent(object sender, EventClassArgs args)
		{
			if(SomeEvent!=null)
				SomeEvent(sender,args);
		}
	}
}
