#define USE_CHECK_BOX_LIST
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace AnyTest
{
	public class TestDynamicCheckBox : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.Label LabelInfo;

		string
			DynamicCheckBoxSignature="TestCheckBox";

		private void Page_Init(object sender, System.EventArgs e)
		{
			System.Web.UI.HtmlControls.HtmlForm
				form;

			if((form=this.FindControl("TestDynamicCheckBoxForm") as System.Web.UI.HtmlControls.HtmlForm)!=null)
			{
				DynamicControlsDS
					DS=new DynamicControlsDS();

				#if USE_CHECK_BOX_LIST
					System.Web.UI.WebControls.CheckBoxList
						tmpCheckBoxList;

					tmpCheckBoxList=new CheckBoxList();
					tmpCheckBoxList.ID=DynamicCheckBoxSignature;

					tmpCheckBoxList.DataSource=DS.Tables["TestTable"];
					tmpCheckBoxList.DataValueField="Id";
					tmpCheckBoxList.DataTextField="Description";
					tmpCheckBoxList.DataBind();

					form.Controls.Add(tmpCheckBoxList);
				#else
					System.Web.UI.WebControls.CheckBox
						tmpCheckBox;
				

					foreach(DataRow row in DS.Tables["TestTable"].Rows)
					{
						tmpCheckBox=new CheckBox();
						tmpCheckBox.ID=DynamicCheckBoxSignature+Convert.ToInt64(row["Id"]);
						tmpCheckBox.Text=Convert.ToString(row["Description"]);
						form.Controls.Add(tmpCheckBox);
					}
				#endif
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);
			this.Init += new System.EventHandler(this.Page_Init);

		}
		#endregion

		private void btnSubmit_Click(object sender, EventArgs e)
		{
			LabelInfo.Text=string.Empty;
			#if USE_CHECK_BOX_LIST
				System.Web.UI.WebControls.CheckBoxList
					tmpCheckBoxList;

				if((tmpCheckBoxList=FindControl(DynamicCheckBoxSignature) as System.Web.UI.WebControls.CheckBoxList)!=null)
					for(int i=0; i<tmpCheckBoxList.Items.Count; ++i)
						if(tmpCheckBoxList.Items[i].Selected)
						{
							if(LabelInfo.Text!=string.Empty)
								LabelInfo.Text+=" ";
							LabelInfo.Text+=tmpCheckBoxList.Items[i].Value;
						}
			#else
				DynamicControlsDS
					DS=new DynamicControlsDS();

				System.Web.UI.WebControls.CheckBox
					tmpCheckBox;
				
				foreach(DataRow row in DS.Tables["TestTable"].Rows)
				{
					if((tmpCheckBox=FindControl(DynamicCheckBoxSignature+Convert.ToInt64(row["Id"])) as System.Web.UI.WebControls.CheckBox)!=null
						&& tmpCheckBox.Checked)
					{
						if(LabelInfo.Text!=string.Empty)
							LabelInfo.Text+=" ";
						LabelInfo.Text+=Convert.ToString(Convert.ToInt64(row["Id"]));
					}
				}
			#endif
		}
	}
}
