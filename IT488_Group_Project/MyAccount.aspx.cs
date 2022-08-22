using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT488_Group_Project
{
    public partial class MyAccount : System.Web.UI.Page
    {
        public DB db = new DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Username: " + Session["username"];
        }

    }
}