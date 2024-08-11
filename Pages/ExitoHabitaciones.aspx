<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExitoHabitaciones.aspx.cs" Inherits="Sistema_Reservaciones_G1.Pages.ExitoHabitaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="alert alert-success">
     <%: Request.QueryString["mensaje"] ?? "Operación realizada correctamente." %>
 </div> 
 <asp:LinkButton ID="lnkListaHabitaciones" runat="server" CssClass="btn btn-primary" PostBackUrl="~/Pages/ListaHabitaciones.aspx">Ir a Gestionar Habitaciones</asp:LinkButton>
</asp:Content>
