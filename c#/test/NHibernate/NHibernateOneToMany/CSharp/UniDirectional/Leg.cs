using System;

namespace UniDirectional
{
	public class ULeg
	{
		public enum LegPosition
		{
			FrontLeft,
			FrontRight,
			BackLeft,
			BackRight
		}
		
		private int id;
		private LegPosition position;

		public virtual int Id 
		{
			get { return this.id; }
			set { this.id = value; }
		}

		public virtual LegPosition Position 
		{
			get { return this.position; }
			set { this.position = value; }
		}
	}
}
