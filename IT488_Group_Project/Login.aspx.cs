using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT488_Group_Project
{
    public partial class Login : System.Web.UI.Page
    {
        DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source = it488library.database.windows.net; User ID = LibraryAdmin; Password = 564^LxdT; Initial Catalog= BookRental;"))
            {
                sqlCon.Open();
                string query = "Select count(account) from UserTable where account=@username and password=@password";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.Parameters.AddWithValue("@username", txtboxUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@password", txtboxPass.Text.Trim());
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 1)
                {
                    Session["username"] = txtboxUsername.Text.ToString();
                    Response.Redirect("MyAccount.aspx");
                }
                else
                {
                    Label3.Visible = true;
                }
            }
        }
    }
}