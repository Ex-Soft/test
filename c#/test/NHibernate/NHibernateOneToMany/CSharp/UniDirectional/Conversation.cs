using System;
using System.Collections;

namespace UniDirectional
{
	public class UConversation
	{
		private int id;
		private string subject;
		private IList messages;
		
		public virtual int Id 
		{
			get { return this.id; }
			set { this.id = value; }
		}
		
		public virtual string Subject 
		{
			get { return this.subject; }
			set { this.subject = value; }
		}
		
		public virtual IList MessageList 
		{
			get { return this.messages; }
			set { this.messages = value; }
		}
	}
}
