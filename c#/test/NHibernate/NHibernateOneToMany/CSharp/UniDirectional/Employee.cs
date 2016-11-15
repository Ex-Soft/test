using System;

namespace UniDirectional
{
	public class UEmployee
	{
		private int id;
		private string name;
		private string address;
		
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
		
		public virtual string Address
		{
			get { return this.address; }
			set { this.address = value; }
		}
		
		override public string ToString()
		{
			return "Name[" + name + "]:Address[" + address + "]";
		}
	}
}
