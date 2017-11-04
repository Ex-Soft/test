using System;

namespace TestEventsI
{
	class EventManagerClass
	{
		public event EventHandler<ClassEventArgs>
			SmthEvent;

		protected virtual void OnSmthEvent(ClassEventArgs e)
		{
			Console.WriteLine("EventManagerClass::OnSmthEvent()");

			EventHandler<ClassEventArgs>
				tmp = SmthEvent;

            if (tmp != null)
            {
                Delegate[]
                    delegates = tmp.GetInvocationList();

                tmp(this, e);
            }
		}

		public void Test()
		{
			ClassEventArgs
				e = new ClassEventArgs(1, "1st");

			Console.WriteLine("EventManagerClass::Test()");
			OnSmthEvent(e);
		}
	}
}
