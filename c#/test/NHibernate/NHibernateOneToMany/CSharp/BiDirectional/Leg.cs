using System;

namespace BiDirectional
{
	public class BLeg
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
		private BDog owner;

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
		
		public virtual BDog Owner
		{
			get { return this.owner; }
			set { this.owner = value; }
		}
	}
}
