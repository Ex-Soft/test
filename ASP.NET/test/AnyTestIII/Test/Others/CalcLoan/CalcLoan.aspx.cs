using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CalcLoan
{
	public class CalcLoanForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Principal;
		protected System.Web.UI.WebControls.TextBox Rate;
		protected System.Web.UI.WebControls.TextBox Term;
		protected System.Web.UI.WebControls.Label Output;
		protected System.Web.UI.WebControls.DropDownList DropDownListDate;
		protected System.Web.UI.WebControls.Button ButtonComputePayment;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}
		
		private void InitializeComponent()
		{    
			this.ButtonComputePayment.Click += new System.EventHandler(this.ButtonComputePayment_Click);
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion

		private void ButtonComputePayment_Click(object sender, System.EventArgs e)
		{
			try
			{
				double
					principal=Convert.ToDouble(Principal.Text),
					rate=Convert.ToDouble(Rate.Text)/100,
					term=Convert.ToDouble(Term.Text),
					tmp=System.Math.Pow(1+(rate/12),term),
					payment=principal*(((rate/12)*tmp)/(tmp-1));

				Output.Text="Monthly Payment = "+payment.ToString("c");
			}
			catch(Exception)
			{
				Output.Text="Error";
			}
		}
	}
}
