using System;
using System.Collections.Generic;

namespace Command
{
	abstract class Command
	{
		public abstract void Execute();
		public abstract void UnExecute();
	}

	class CalculatorCommand : Command
	{
		char
			@operator;

		int
			operand;

		Calculator
			calculator;

		public CalculatorCommand(Calculator calculator, char @operator, int operand)
		{
			this.calculator = calculator;
			this.@operator = @operator;
			this.operand = operand;
		}

		public char Operator
		{
			set { @operator = value; }
		}

		public int Operand
		{
			set { operand = value; }
		}

		public override void Execute()
		{
			calculator.Operation(@operator, operand);
		}

		public override void UnExecute()
		{
			calculator.Operation(Undo(@operator), operand);
		}

		private char Undo(char @operator)
		{
			char
				undo;

			switch (@operator)
			{
				case '+': undo = '-'; break;
				case '-': undo = '+'; break;
				case '*': undo = '/'; break;
				case '/': undo = '*'; break;
				default: undo = ' '; break;
			}
			return undo;
		}
	}

	class Calculator
	{
		private int
			curr = 0;

		public void Operation(char @operator, int operand)
		{
			switch (@operator)
			{
				case '+': curr += operand; break;
				case '-': curr -= operand; break;
				case '*': curr *= operand; break;
				case '/': curr /= operand; break;
			}

			Console.WriteLine("Current value = {0,3} (following {1} {2})",curr, @operator, operand);
		}
	}

	class User
	{
		Calculator
			calculator = new Calculator();

		List<Command>
			commands = new List<Command>();

		int
			current = 0;

		public void Redo(int levels)
		{
			Console.WriteLine("\n---- Redo {0} levels ", levels);

			for (int i = 0; i < levels; i++)
				if (current < commands.Count - 1)
					commands[current++].Execute();
		}

		public void Undo(int levels)
		{
			Console.WriteLine("\n---- Undo {0} levels ", levels);

			for (int i = 0; i < levels; i++)
				if (current > 0)
					commands[--current].UnExecute();
		}

		public void Compute(char @operator, int operand)
		{
			Command
				command = new CalculatorCommand(calculator, @operator, operand);

			command.Execute();
			commands.Add(command);
			current++;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			User
				user = new User();

			user.Compute('+', 100);
			user.Compute('-', 50);
			user.Compute('*', 10);
			user.Compute('/', 2);

			user.Undo(4);

			user.Redo(3);

			Console.Read();
		}
	}
}
