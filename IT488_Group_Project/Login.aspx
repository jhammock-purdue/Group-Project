<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IT488_Group_Project._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <center>
            <h1>Top Books</h1>
        <div>
           <% var topbooks = db.getTopBooks(); Response.Write("<table>"); Response.Write("<tr>");
               foreach (var item in topbooks)
               {

                   string imgHTML = "<img src=\"Content/Images/" + item.Isbn + ".jpg\" height=170px width=100px />";
                   Response.Write("<td>" + imgHTML + "</td>");
                   Response.Write("<td>");
                   Response.Write("<table>");
                   Response.Write("<tr>");
                   Response.Write("<td><b>" + item.Title + "</b></td>");
                   Response.Write("</tr>");
                   Response.Write("<tr>");
                   Response.Write("<td><i>" + item.Author + "</i></td>");
                   Response.Write("</tr>");        
                   Response.Write("</table>");
                   Response.Write("</td>");

               }
               Response.Write("</tr>"); Response.Write("</table>");
            %>
        </div>
        </center>
    </div>

</asp:Content>
