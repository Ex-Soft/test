using System;

namespace UniDirectional
{
	public class UPersonName
	{
		private int id;
		private string name = "";
		
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
		
		public override bool Equals(object obj)
		{
			// Check for null values and compare run-time types.
			if (obj == null || GetType() != obj.GetType()) 
				return false;
			UPersonName asName = (UPersonName)obj;
			
			if (name.Equals(asName.name) && id.Equals(asName.id))
				return true;
			
			return false;
		}
		
		public override int GetHashCode()
		{
			int temp = 0;
			
			temp = (name + id).GetHashCode();// ^ id);
			
			return temp;
		}
		
		public static bool operator ==(UPersonName x, UPersonName y) 
		{
			if ((x.name == y.name) && (x.id == y.id))
				return true;
			
			return false;
		}
		
		public static bool operator !=(UPersonName x, UPersonName y) 
		{
			return !(x == y);
		}

		public override string ToString()
		{
			return "Name[" + name + "]";
		}
	}
}
