using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TestFormsAuthentication
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblLogonUserIdentityName.Text = HttpContext.Current.Request.LogonUserIdentity.Name;
            lblWindowsIdentityGetCurrentName.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }

        protected void BtnConnectClick(object sender, EventArgs e)
        {
            const string connectionStringKey = "cs";
            string connectionString = null;

            if (ConfigurationManager.ConnectionStrings.OfType<ConnectionStringSettings>().Any(cs => cs.Name == connectionStringKey))
                connectionString = ConfigurationManager.ConnectionStrings[connectionStringKey].ConnectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
                return;

            lblError.Text = string.Empty;

            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select suser_name()";

                    var userName = cmd.ExecuteScalar();
                    string userNameStr;

                    if(userName != null && !Convert.IsDBNull(userName))
                        lblError.Text = !string.IsNullOrWhiteSpace(userNameStr = userName.ToString()) ? userNameStr : "Empty";
                }
                connection.Close();
            }
            catch (Exception eException)
            {
                lblError.Text = eException.Message;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
