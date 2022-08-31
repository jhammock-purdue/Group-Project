<%@ Page Title="Rental" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Librarian.aspx.cs" Inherits="IT488_Group_Project.Librarian" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <center>
            <h1>Rentals</h1>
        <div>
            <h2>Rental Assignment</h2>
            Title:
            <asp:DropDownList ID="AvailableBooksDDL" runat="server" AutoPostBack ="true">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Account:
            <asp:DropDownList ID="AccountsDDL" runat="server" AutoPostBack ="true">
               
            </asp:DropDownList>
            <br />
            <asp:Button ID="AssignRental" runat="server" Text="Assign Rental" OnClick="AssignRental_Click" />
            
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

            <h2>Rental Return</h2>
            <p>

                ISBN to Return:<asp:TextBox ID="ISBNReturn" runat="server" Text="1"></asp:TextBox><br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Return" />
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>

            <asp:UpdatePanel ID="BookTable" UpdateMode="Always">
            <% var books = db.GetAssignedRentals(Int32.Parse(AccountsDDL.SelectedValue)); Response.Write("<table>");
                    int counter = 0;
                    foreach (var item in books)
                    {
                        string imgHTML = "<img src=\"Content/Images/" + item.ISBN + ".jpg\" height=170px width=100px />";

                        if (counter == 0)
                        {
                            Response.Write("<tr>");
                                Response.Write("<td>" + imgHTML + "</td>");
                                Response.Write("<td>");
                            Response.Write("<table>");
                                Response.Write("<tr>");
                                    Response.Write("<td>" + item.Date.Date + "</td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                    Response.Write("<td>" + item.ISBN + "</td>");
                                Response.Write("</tr>");
                            Response.Write("</table>");
                        Response.Write("</td>");
                        
                            counter++;
                        }
                        else if (counter == 1)
                        {
                            Response.Write("<tr>");
                                Response.Write("<td>" + imgHTML + "</td>");
                                Response.Write("<td>");
                            Response.Write("<table>");
                                Response.Write("<tr>");
                                    Response.Write("<td>" + item.Date.Date + "</td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                    Response.Write("<td>" + item.ISBN + "</td>");
                                Response.Write("</tr>");
                            Response.Write("</table>");
                        Response.Write("</td>");

                            counter++;
                        }
                        else if (counter == 2)
                        {
                            Response.Write("<tr>");
                                Response.Write("<td>" + imgHTML + "</td>");
                                Response.Write("<td>");
                            Response.Write("<table>");
                                Response.Write("<tr>");
                                    Response.Write("<td>" + item.Date.Date + "</td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                    Response.Write("<td>" + item.ISBN + "</td>");
                                Response.Write("</tr>");
                            Response.Write("</table>");
                        Response.Write("</td>");

                            counter = 0;
                        }


                    }
                    Response.Write("</table>");
                
            %></asp:UpdatePanel>
            </p>
        </div>
        </center>
    </div>

</asp:Content>
