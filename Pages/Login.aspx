<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Sistema_Reservaciones_G1.Pages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Login</h2>
    <div>
        <asp:Label ID="lblemail" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtemail" ErrorMessage="El campo Email es obligatorio." CssClass="text-danger" Display="Dynamic" />
        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtemail" ErrorMessage="Formato de email no válido." CssClass="text-danger" Display="Dynamic" 
            ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$" />
    </div>
    <div>
        <asp:Label ID="lblclave" runat="server" Text="Clave:"></asp:Label>
        <asp:TextBox ID="pswclave" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvClave" runat="server" ControlToValidate="pswclave" ErrorMessage="El campo Clave es obligatorio." CssClass="text-danger" Display="Dynamic" />
    </div>
    <div>
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-primary" />
    </div>
    <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="text-danger"></asp:Label>
</asp:Content>
