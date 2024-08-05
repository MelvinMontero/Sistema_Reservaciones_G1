<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarReservacion.aspx.cs" Inherits="Sistema_Reservaciones_G1.Pages.EditarReservacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h1>Modificar reservacion</h1>
  
<div>
     <h2>Hotel</h2>  <asp:TextBox ID="Texthotel1" runat="server" required="required"></asp:TextBox>

</div>

 <div>
      <h2>Numero de habitacion</h2>  <asp:TextBox ID="Textnumhabit" runat="server" required="required"></asp:TextBox>
 </div>
 <div>
      <h2>Cliente</h2>  <asp:TextBox ID="Textcliente" runat="server" required="required"></asp:TextBox>
 </div>
 <div>
     <h2>Fecha Entrada</h2>  <asp:TextBox ID="TextFechaentrada" runat="server"></asp:TextBox>
     <%-- Realiza validacion que la fecha de entrada este en formato correcto y no sea menor o igual a la fecha actual --%>
    <asp:RegularExpressionValidator ID="revFechaEntrada" runat="server" ControlToValidate="TextFechaentrada"
        ErrorMessage="La fecha de entrada debe estar en el formato dd/MM/yyyy" 
        ValidationExpression="^\d{2}/\d{2}/\d{4}$" CssClass="text-danger"></asp:RegularExpressionValidator>
    <asp:CustomValidator ID="cvFechaEntrada" runat="server" ControlToValidate="TextFechaentrada" 
        ErrorMessage="La fecha de entrada no puede ser menor o igual a la fecha actual." 
        OnServerValidate="cvFechaEntrada_ServerValidate" CssClass="text-danger"></asp:CustomValidator>
     <%-- En el server validate falta probarlo --%>

     <h2>Fecha salida</h2>  <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
       <%-- Realiza validacion que la fecha de entrada este en formato correcto y no sea menor o igual a la fecha actual --%>
     <asp:RegularExpressionValidator ID="revFechaSalida" runat="server" ControlToValidate="TextBox2"
        ErrorMessage="La fecha de salida debe estar en el formato dd/MM/yyyy" 
        ValidationExpression="^\d{2}/\d{2}/\d{4}$" CssClass="text-danger"></asp:RegularExpressionValidator>
    <asp:CustomValidator ID="cvFechaSalida" runat="server" ControlToValidate="TextBox2" 
        ErrorMessage="La fecha de salida no puede ser menor o igual a la fecha actual." 
        OnServerValidate="cvFechaSalida_ServerValidate" CssClass="text-danger"></asp:CustomValidator>
 </div>
 <div>
     <h2>Numero de adultos</h2>
       <%--cambie el drop down list espero que este bien asi--%>
             <asp:DropDownList ID="ddlClientes" runat="server" CssClass="form-control" required="required">
        <asp:ListItem Text="1" Value="1" />
        <asp:ListItem Text="2" Value="2" />
        <asp:ListItem Text="3" Value="3" />
        <asp:ListItem Text="4" Value="4" />
        <asp:ListItem Text="5" Value="5" />
        <asp:ListItem Text="6" Value="6" />
        <asp:ListItem Text="7" Value="7" />
        <asp:ListItem Text="8" Value="8" />
    </asp:DropDownList>
</div>
    
    <div>
    <h2>Numero de ninos</h2>
    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" required="required">
        <asp:ListItem Text="0" Value="0" />
        <asp:ListItem Text="1" Value="1" />
        <asp:ListItem Text="2" Value="2" />
        <asp:ListItem Text="3" Value="3" />
        <asp:ListItem Text="4" Value="4" />
        <asp:ListItem Text="5" Value="5" />
        <asp:ListItem Text="6" Value="6" />
        <asp:ListItem Text="7" Value="7" />
        <asp:ListItem Text="8" Value="8" />
    </asp:DropDownList>
</div>

    <div>
        <asp:Button ID="ButtonGuarda" runat="server" Text="Guardar" OnClick="ButtonGuarda_Click" />
        <%-- Pagina 29 boton guardar --%>

        <asp:Button ID="ButtonRegresar" runat="server" Text="Regresar" OnClick="ButtonRegresar_Click" />
        <%-- Pagina 30 boton cancelar --%>
    </div>


</asp:Content>
