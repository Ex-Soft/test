using System;


namespace UniDirectional
{
	public class UOrder
	{
		private int id;
		private int number;
		
		public UOrder()
		{
		}

		public virtual int Id 
		{
			get { return this.id; }
			set { this.id = value; }
		}

		public virtual int Number 
		{
			get { return this.number; }
			set { this.number = value; }
		}

	}
}

