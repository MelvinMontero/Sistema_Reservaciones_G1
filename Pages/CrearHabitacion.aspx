<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearHabitacion.aspx.cs" Inherits="Sistema_Reservaciones_G1.Pages.CrearHabitacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <h1>Crear habitacion</h1>
    <div>
        <h2>Hotel</h2>
        
         
        <asp:DropDownList ID="droplisthoteles" runat="server" AppendDataBoundItems="True" AutoPostBack="False">
                <asp:ListItem Text="Seleccione un hotel" Value="" />
            </asp:DropDownList>
    </div>
      <div>
          <h2>Numero de habitacion</h2>
           
          <asp:TextBox ID="txtnumhabitacion" runat="server" MaxLength="10" />
         <asp:RequiredFieldValidator ID="rfvNumeroHabitacion" runat="server" 
     ControlToValidate="txtNumeroHabitacion" ErrorMessage="El número de habitación es obligatorio." 
    Display="Dynamic" ForeColor="Red" />
            
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
      </div>
      <div>
          <h2>Descripcion</h2>
 <asp:TextBox ID="Textdescrip" runat="server" CssClass="form-control" MaxLength="500" TextMode="MultiLine"></asp:TextBox>
          <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" 
                ControlToValidate="txtDescripcion" ErrorMessage="La descripción es obligatoria." 
                Display="Dynamic" ForeColor="Red" />
      </div>
      <div>
          <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click"/>
      </div>
   
      
</asp:Content>
