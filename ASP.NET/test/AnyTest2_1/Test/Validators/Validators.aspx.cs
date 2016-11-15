using System;
using System.Web.UI.WebControls;

namespace AnyTest2_1
{
	public partial class TestValidatorsForm : System.Web.UI.Page
	{
		protected void Page_Load(Object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				RangeValidatorDate.MinimumValue = DateTime.Now.AddYears(-1).ToString("yyyy/MM/dd");
				RangeValidatorDate.MaximumValue = DateTime.Now.AddYears(1).ToString("yyyy/MM/dd");
			}
		}

		protected void ValidateAmount(Object sender, ServerValidateEventArgs e)
		{
			try
			{
				e.IsValid = (Convert.ToInt32(e.Value) % 10 == 0);
			}
			catch (FormatException)
			{
				e.IsValid = false;
			}
		}

		protected void OnClick(Object sender, EventArgs e)
		{
			if (IsValid)
			{
			}
		}
	}
}
