<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Sistema_Reservaciones_G1.Pages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Login</h2>
    <div>
        <asp:Label ID="lblemail" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblclave" runat="server" Text="Clave:"></asp:Label>
        <asp:TextBox ID="pswclave" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
    </div>
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>

</asp:Content>
