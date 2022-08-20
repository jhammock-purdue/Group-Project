<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Browse.aspx.cs" Inherits="IT488_Group_Project.Browse" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">


    
        
            <asp:Label ID="Label1" runat="server" Text="Search by Genre, Title, Author, ISBN, or Release Date:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <center>
        <%  var books = db.getBooks(TextBox1.Text); Response.Write("<table>");
            int counter = 0;
            foreach (var item in books)
            {
                string imgHTML = "<img src=\"Content/Images/" + item.Isbn + ".jpg\" height=170px width=100px />";

                if (counter == 0)
                {
                    Response.Write("<tr>");
                    Response.Write("<td>" + imgHTML + "</td>");
                    Response.Write("<td>");
                    Response.Write("<table>");
                    Response.Write("<tr>");
                    Response.Write("<td>" + item.Title + "</td>");
                    Response.Write("</tr>");
                    Response.Write("<tr>");
                    Response.Write("<td>" + item.Author + "</td>");
                    Response.Write("</tr>");
                    Response.Write("</table>");
                    Response.Write("</td>");

                    counter++;
                }
                else if (counter == 1)
                {
                    Response.Write("<td>" + imgHTML + "</td>");
                    Response.Write("<td>");
                    Response.Write("<table>");
                    Response.Write("<tr>");
                    Response.Write("<td>" + item.Title + "</td>");
                    Response.Write("</tr>");
                    Response.Write("<tr>");
                    Response.Write("<td>" + item.Author + "</td>");
                    Response.Write("</tr>");
                    Response.Write("</table>");
                    Response.Write("</td>");
                    counter++;
                }
                else if (counter == 2)
                {
                    Response.Write("<td>" + imgHTML + "</td>");
                    Response.Write("<td>");
                    Response.Write("<table>");
                    Response.Write("<tr>");
                    Response.Write("<td>" + item.Title + "</td>");
                    Response.Write("</tr>");
                    Response.Write("<tr>");
                    Response.Write("<td>" + item.Author + "</td>");
                    Response.Write("</tr>");
                    Response.Write("</table>");
                    Response.Write("</td>");
                    Response.Write("</tr>");
                    counter = 0;
                }


            }
            Response.Write("</table>");
            %>



   
</div>
    </asp:Content>
