using System;
using System.Collections;

namespace UniDirectional
{
	public class UStreet
	{
		private int id;
		private string name;
		private IDictionary habitantList;
		
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
		
		public virtual IDictionary HabitantList 
		{
			get { return this.habitantList; }
			set { this.habitantList = value; }
		}
	}
}
