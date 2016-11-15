using System;

namespace UniDirectional
{
	public class UHabitant
	{
		private int id;
		private int houseNumber;
		
		public virtual int Id 
		{
			get { return this.id; }
			set { this.id = value; }
		}
		
		public virtual int HouseNumber
		{
			get { return this.houseNumber; }
			set { this.houseNumber = value; }
		}
		
		override public string ToString()
		{
			return "HouseNumber[" + houseNumber.ToString() + "]";
		}
	}
}
