using System;

namespace Command
{
	abstract class Command
	{
		abstract public void Execute();

		protected Receiver
			r;

		public Receiver R
		{
			set
			{
				r = value;
			}
		}
	}

	class ConcreteCommand : Command
	{
		override public void Execute()
		{
			Console.WriteLine("Command executed");
			r.InformAboutCommand();
		}
	}

	class Receiver
	{
		public void InformAboutCommand()
		{
			Console.WriteLine("Receiver informed about command");
		}

	}

	class Invoker
	{
		Command
			command;

		public void StoreCommand(Command c)
		{
			command = c;
		}

		public void ExecuteCommand()
		{
			command.Execute();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Command
				c = new ConcreteCommand();

			Receiver
				r = new Receiver();

			c.R = r;

			Invoker
				i = new Invoker();

			i.StoreCommand(c);
			i.ExecuteCommand();
		}
	}
}
