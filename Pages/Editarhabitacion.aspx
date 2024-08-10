<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Editarhabitacion.aspx.cs" Inherits="Sistema_Reservaciones_G1.Pages.Editarhabitacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%-- solo para empleados --%>

     
    <h1>Editar habitacion</h1>
    
    <div>
        <h2>Hotel</h2>
      
         <label for="Hotelselec">Hotel:</label>
                <asp:TextBox ID="Hotelselec" runat="server" ReadOnly="True"></asp:TextBox>

    </div>
      <div>
          <h2>Numero de habitacion</h2>
           <asp:TextBox ID="txtnumhabitacion" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
          <%-- Esta advertencia hace que los caracteres deban ser alfanumericos si no dara un mensaje de error --%>
           <asp:RegularExpressionValidator ID="revNumHabitacion" runat="server" ControlToValidate="txtnumhabitacion"
        ErrorMessage="El número de habitación solo puede contener caracteres alfanuméricos." 
        ValidationExpression="^[a-zA-Z0-9]+$" CssClass="text-danger"></asp:RegularExpressionValidator>

          <%-- Da un mensaje de error al tener un numero de habitacion duplicada --%>
          <asp:CustomValidator ID="cvNumHabitacionUnico" runat="server" ControlToValidate="txtnumhabitacion" 
        ErrorMessage="El número de habitación no puede estar duplicado para el mismo hotel." 
        OnServerValidate="cvNumHabitacionUnico_ServerValidate" CssClass="text-danger"></asp:CustomValidator>


      </div>
      <div>
          <h2>Capacidad maxima</h2>
          <asp:DropDownList ID="DropDownListcapacidad" runat="server" CssClass="form-control"></asp:DropDownList>
          <%-- Advertencia sobre la capacidad maxima de la habitacion --%>
           <asp:RangeValidator ID="rvCapacidad" runat="server" ControlToValidate="DropDownListcapacidad" 
        MinimumValue="1" MaximumValue="8" Type="Integer" ErrorMessage="La capacidad máxima debe ser un número entre 1 y 8." 
        CssClass="text-danger"></asp:RangeValidator>
      </div>
      <div>
          <h2>Descripcion</h2>
 <asp:TextBox ID="Textdescrip" runat="server" CssClass="form-control" MaxLength="500"></asp:TextBox>
          <%-- Genera un error si se dan caracteres fuera de lo alfanumerico --%>
          <asp:RegularExpressionValidator ID="revDescripcion" runat="server" ControlToValidate="Textdescrip" 
        ErrorMessage="La descripción solo puede contener caracteres alfanuméricos." 
        ValidationExpression="^[a-zA-Z0-9\s]+$" CssClass="text-danger"></asp:RegularExpressionValidator>
      </div>
      <div>
          <asp:Button ID="ButtonGuardareditarhabitacion" runat="server" Text="Guardar" OnClick="ButtonGuardareditarhabitacion_Click" />
          <asp:Button ID="Buttoninactivar" runat="server" Text="Inactivar" OnClick="Buttoninactivar_Click" />
           <asp:Button ID="ButtonRegresar" runat="server" Text="Regresar" OnClick="ButtonRegresar_Click"/>
      </div>
 <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" Visible="False"></asp:Label>
      
</asp:Content>
