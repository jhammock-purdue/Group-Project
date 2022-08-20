using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace IT488_Group_Project
{
    public partial class _Default : Page
    {
        public DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source = it488library.database.windows.net; User ID = LibraryAdmin; Password = 564^LxdT; Initial Catalog= BookRental;"))
            {
                sqlCon.Open();
                string query = "Select count(1) from Accounts where account_number=@username and Passwords=@password";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                cmd.Parameters.AddWithValue("@username",txtboxUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@password", txtboxPass.Text.Trim());
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 1)
                {
                    Session["username"] = txtboxUsername.Text;
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Label3.Visible = true;
                }
            }
        }
    }
}