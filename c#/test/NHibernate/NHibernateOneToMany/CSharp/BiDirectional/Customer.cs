using System;
using System.Collections;

namespace BiDirectional
{
	public class BCustomer
	{
		private int id;
		private string name;
		private IList orderList;


		public BCustomer()
		{
		}

		public virtual int Id 
		{
			get { return this.id; }
			set { this.id = value; }
		}

		public virtual string Name 
		{
			get { return this.name; }
			set { this.name = value; }
		}

		public virtual IList OrderList
		{
			get { return this.orderList; }
			set { this.orderList = value; }
		}
	}
}
