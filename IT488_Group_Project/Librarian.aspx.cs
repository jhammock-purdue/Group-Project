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
            if (!IsPostBack)
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
        }

        protected void AssignRental_Click(object sender, EventArgs e)
        {

                int ISBN = Convert.ToInt32(AvailableBooksDDL.SelectedValue);
                int account = Convert.ToInt32(AccountsDDL.SelectedValue);


                string labelText = db.AssignRental(ISBN, account, Session["username"].ToString());
                Label1.Text = labelText;
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int ISBN = Convert.ToInt32(ISBNReturn.Text);
            int account = Convert.ToInt32(AccountsDDL.SelectedValue);

            string labelText = db.ReturnRental(ISBN, account, Session["username"].ToString());
            Label2.Text = labelText;
        }
    }
}