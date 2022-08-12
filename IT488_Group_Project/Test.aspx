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
        
        <% var books = db.getBooks(TextBox1.Text); Response.Write("<ul>");
            foreach (var item in books)
            {
                Response.Write("<li>" + item.Title + "</li><br/>");
            }
            Response.Write("</ul>");%>
    </form>
</body>
</html>
