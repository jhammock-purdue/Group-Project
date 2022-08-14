<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="IT488_Group_Project.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           
        </div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <center>
        <% var books = db.getBooks(TextBox1.Text); Response.Write("<ul>");
            foreach (var item in books)
            {
                string imgHTML = "<img src=\"Content/Images/" + item.Isbn + ".jpg\" height=170px width=100px />";
                Response.Write("<li>" + imgHTML + "<br/>" + item.Title + "<br/>   By:"  + item.Author + "</li><br/>");
               
            }
            Response.Write("</ul>");
            %>
            </center>
    </form>
</body>
</html>
