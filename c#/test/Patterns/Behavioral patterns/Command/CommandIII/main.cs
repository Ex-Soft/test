using System;

namespace CommandIII
{
	/* the Invoker class */
	public class Switch
	{
		ICommand
			flipUpCommand,
			flipDownCommand;

		public Switch(ICommand flipUpCmd, ICommand flipDownCmd)
		{
			this.flipUpCommand = flipUpCmd;
			this.flipDownCommand = flipDownCmd;
		}

		public void flipUp()
		{
			flipUpCommand.execute();
		}

		public void flipDown()
		{
			flipDownCommand.execute();
		}
	}

	/* Receiver class */
	public class Light
	{
		public void turnOn()
		{
			Console.WriteLine("The light is on");
		}

		public void turnOff()
		{
			Console.WriteLine("The light is off");
		}
	}

	/* the Command interface */
    public interface ICommand
    {
        void execute();
    }

	/* the ConcreteCommand */
    public class TurnOnLightCommand : ICommand
    {
        Light
            theLight;
 
		public TurnOnLightCommand(Light light)
		{
			this.theLight=light;
		}
 
		public void execute()
		{
			theLight.turnOn();
		}
	}

	/* the ConcreteCommand */
	public class TurnOffLightCommand : ICommand
	{
		Light
			theLight;
 
		public TurnOffLightCommand(Light light)
		{
			this.theLight=light;
		}
 
		public void execute()
		{
			theLight.turnOff();
		}
	}

    class Program
    {
        static void Main(string[] args)
        {
			Light
				l = new Light();

			ICommand
				switchUp = new TurnOnLightCommand(l),
				switchDown = new TurnOffLightCommand(l);

			Switch
				s = new Switch(switchUp, switchDown);

			s.flipUp();
			s.flipDown();

            Console.ReadLine();
        }
    }
}
