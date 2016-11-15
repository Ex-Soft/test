using System;

namespace UniDirectional
{
	public class UMessage
	{
		private int id;
		private string text;
		
		public virtual int Id 
		{
			get { return this.id; }
			set { this.id = value; }
		}
		
		public virtual string Text 
		{
			get { return this.text; }
			set { this.text = value; }
		}
	}
}
