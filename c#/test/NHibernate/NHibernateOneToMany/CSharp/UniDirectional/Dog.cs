using System;
using Iesi.Collections;

namespace UniDirectional
{
	public class UDog
	{
		private int id;
		private string name;
		private ISet legs;
		
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
		
		public virtual ISet Legs 
		{
			get { return this.legs; }
			set { this.legs = value; }
		}
	}
}
