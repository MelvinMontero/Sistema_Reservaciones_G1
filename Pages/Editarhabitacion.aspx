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
        <h2>Número de habitación</h2>
        <!-- Campo de texto para ingresar el número de la habitación -->
        <asp:TextBox ID="txtnumhabitacion" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
    
        <!-- Validador de expresión regular para asegurar que el número de habitación solo contenga caracteres alfanuméricos -->
        <asp:RegularExpressionValidator ID="revNumHabitacion" runat="server" ControlToValidate="txtnumhabitacion"
            ErrorMessage="El número de habitación solo puede contener caracteres alfanuméricos." 
            ValidationExpression="^[a-zA-Z0-9]+$" CssClass="text-danger"></asp:RegularExpressionValidator>

        
    </div>
      <div>
          <h2>Capacidad maxima</h2>
          <asp:DropDownList ID="DropDownListcapacidad" runat="server">
    <asp:ListItem Text="1" Value="1" />
    <asp:ListItem Text="2" Value="2" />
    <asp:ListItem Text="3" Value="3" />
    <asp:ListItem Text="4" Value="4" />
    <asp:ListItem Text="5" Value="5" />
    <asp:ListItem Text="6" Value="6" />
    <asp:ListItem Text="7" Value="7" />
    <asp:ListItem Text="8" Value="8" />
</asp:DropDownList>
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
          <asp:Button ID="ButtonGuardareditarhabitacion" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="ButtonGuardareditarhabitacion_Click" />
          <asp:Button ID="Buttoninactivar" runat="server" Text="Inactivar" CssClass="btn btn-danger" OnClick="Buttoninactivar_Click" />
           <asp:Button ID="ButtonRegresar" runat="server" Text="Regresar" CssClass="btn btn-secondary" OnClick="ButtonRegresar_Click"/>
      </div>
 <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" Visible="False"></asp:Label>
      
</asp:Content>
