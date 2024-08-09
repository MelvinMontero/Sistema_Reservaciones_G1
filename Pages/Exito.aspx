<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exito.aspx.cs" Inherits="Sistema_Reservaciones_G1.Pages.Exito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="alert alert-success">
        <%: Request.QueryString["mensaje"] ?? "Operación realizada correctamente." %>
    </div> 
    <asp:LinkButton ID="lnkIrMisReservaciones" runat="server" CssClass="btn btn-primary" Visible="false" PostBackUrl="~/Pages/MisReservaciones.aspx">Ir a Mis Reservaciones</asp:LinkButton>
    <asp:LinkButton ID="lnkIrGestionarReservaciones" runat="server" CssClass="btn btn-primary" Visible="false" PostBackUrl="~/Pages/GestionarReservaciones.aspx">Ir a Gestionar Reservaciones</asp:LinkButton>

</asp:Content>
