using System;
using System.Collections.Generic;

namespace TestServiceI
{
	public class TestClassSimple
	{
		virtual public int FInt { get; set; }
		virtual public decimal FDecimal { get; set; }
		virtual public DateTime FDateTime { get; set; }
		virtual public string FString { get; set; }

		public TestClassSimple() : this(int.MinValue, decimal.MinValue, DateTime.Now, string.Empty)
		{}

		public TestClassSimple(int FInt, decimal FDecimal, DateTime FDateTime, string FString)
		{
			this.FInt = FInt;
			this.FDecimal = FDecimal;
			this.FDateTime = FDateTime;
			this.FString = FString;
		}
	}

	public class TestClass
	{
		virtual public int FInt { get; set; }
		virtual public decimal FDecimal { get; set; }
		virtual public DateTime FDateTime { get; set; }
		virtual public string FString { get; set; }

		virtual public List<TestClassSimple> ListTestClassSimple { get; set; }

		public TestClass()
		{}
	}
}
