<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarReservacion.aspx.cs" Inherits="Sistema_Reservaciones_G1.Pages.EditarReservacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h1>Modificar reservacion</h1>
   <%-- Faltan las limitaciones de los espacios--%>
<div>
     <h2>Hotel</h2>  <asp:TextBox ID="Texthotel1" runat="server"></asp:TextBox>

</div>

 <div>
      <h2>Numero de habitacion</h2>  <asp:TextBox ID="Textnumhabit" runat="server"></asp:TextBox>
 </div>
 <div>
      <h2>Cliente</h2>  <asp:TextBox ID="Textcliente" runat="server"></asp:TextBox>
 </div>
 <div>
     <h2>Fecha Entrada</h2>  <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
     <h2>Fecha salida</h2>  <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
 </div>
 <div>
     <h2>Numero de adultos</h2>
       
            <asp:DropDownList ID="ddlClientes" runat="server">
  <asp:ListItem Text="" Value="0" />
    
 </asp:DropDownList>
 </div>
    <div>
    <h2>Numero de ninos</h2>
          <asp:DropDownList ID="DropDownList1" runat="server">
  <asp:ListItem Text="" Value="0" />
    
 </asp:DropDownList>
</div>

    <div>
        <asp:Button ID="ButtonGuarda" runat="server" Text="Guardar" OnClick="ButtonGuarda_Click" />
        <asp:Button ID="ButtonRegresar" runat="server" Text="Regresar" OnClick="ButtonRegresar_Click" />
    </div>


</asp:Content>
