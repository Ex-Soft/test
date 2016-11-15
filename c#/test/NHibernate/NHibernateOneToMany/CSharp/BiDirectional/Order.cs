using System;


namespace BiDirectional
{
	public class BOrder
	{
		private int id;
		private int number;
		private BCustomer orderedBy;
		
		public BOrder()
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
		
		public virtual BCustomer OrderedBy
		{
			get { return this.orderedBy; }
			set { this.orderedBy = value; }
		}

	}
}

