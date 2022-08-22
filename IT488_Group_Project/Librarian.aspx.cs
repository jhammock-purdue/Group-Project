using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IT488_Group_Project
{
    public partial class Librarian : System.Web.UI.Page
    {
        public DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            AvailableBooksDDL.DataSource = db.getAvailableBooks().ToList();
            AvailableBooksDDL.DataTextField = "Title";
            AvailableBooksDDL.DataValueField = "ISBN";
            AvailableBooksDDL.DataBind();


            AccountsDDL.DataSource = db.getAccounts().ToList();
            AccountsDDL.DataTextField = "AccountNumber";
            AccountsDDL.DataValueField = "AccountNumber";
            AccountsDDL.DataBind();

            List<Book> books = db.getAvailableBooks();

        }

        protected void AssignRental_Click(object sender, EventArgs e)
        {

        }
    }
}