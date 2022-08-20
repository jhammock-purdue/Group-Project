using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT488_Group_Project
{
    public partial class TestRent : System.Web.UI.Page
    {
        public DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            ddlAvailableBooks.DataSource = db.getAvailableBooks().ToList();
            ddlAvailableBooks.DataTextField = "Title";
            ddlAvailableBooks.DataValueField = "ISBN";
            ddlAvailableBooks.DataBind();
            

            ddlAccount.DataSource = db.getAccounts().ToList();
            ddlAccount.DataTextField = "AccountNumber";
            ddlAccount.DataValueField = "FirstName";
            ddlAccount.DataBind();

        }
    }
}