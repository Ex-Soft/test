using System;

namespace TestEventsI
{
	class ClassWithEvent
	{
		public ClassWithEvent(EventManagerClass EventManager)
		{
			if (EventManager != null)
				EventManager.SmthEvent += DoSmth;
		}

		public virtual void DoSmth(Object sender, ClassEventArgs e)
		{
			Console.WriteLine("{0}{1}\tSender: {2}{1}\tArguments: {{ FInt: {3}, FString: \"{4}\" }}{1}", this.GetType().FullName, Environment.NewLine, sender.GetType().FullName, e.FInt, e.FString);
		}

		public virtual void Attach(EventManagerClass EventManager)
		{
			if (EventManager != null)
				EventManager.SmthEvent += DoSmth;
		}

		public virtual void Detach(EventManagerClass EventManager)
		{
			if (EventManager != null)
				EventManager.SmthEvent -= DoSmth;
		}
	}

	class ClassWithEventI : ClassWithEvent
	{
		public ClassWithEventI(EventManagerClass EventManager) : base(EventManager)
		{}
	}

	class ClassWithEventII : ClassWithEvent
	{
		public ClassWithEventII(EventManagerClass EventManager) : base(EventManager)
		{}
	}

	class ClassWithEventIII : ClassWithEvent
	{
		public ClassWithEventIII(EventManagerClass EventManager) : base(EventManager)
		{}

		public override void DoSmth(object sender, ClassEventArgs e)
		{
			Console.WriteLine(";)");
			base.DoSmth(sender, e);
		}
	}

}
