<%@ Page Title="Rental" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Librarian.aspx.cs" Inherits="IT488_Group_Project.Librarian" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <center>
            <h1>Rental Assignment</h1>
        <div>
            Title:
            <asp:DropDownList ID="AvailableBooksDDL" runat="server">
            </asp:DropDownList>
            <br />
                       
            <br />
            Account:
            <asp:DropDownList ID="AccountsDDL" runat="server">
               
            </asp:DropDownList>
            <asp:Button ID="AssignRental" runat="server" Text="Assign Rental" OnClick="AssignRental_Click" />
            <br />

        </div>
        </center>
    </div>

</asp:Content>
