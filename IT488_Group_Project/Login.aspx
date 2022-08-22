<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IT488_Group_Project.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <center>
            <h1>Please Log In</h1>
        <div>
        <table>
            <tr>
                <td><asp:Label ID="Label1" runat="server" Text="Username"></asp:Label></td>
                <td><asp:TextBox ID="txtboxUsername" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label2" runat="server" Text="Password"></asp:Label></td>
                <td><asp:TextBox ID="txtboxPass" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" /></td>
                <td> <asp:Label ID="Label3" runat="server" Text="Username or Password is incorrect" ForeColor="Red" Visible="false"></asp:Label></td>
                
            </tr>
        </table>  
        </div>
        </center>
    </div>

</asp:Content>
