<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearHabitacion.aspx.cs" Inherits="Sistema_Reservaciones_G1.Pages.CrearHabitacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <h1>Crear habitación</h1>
    <div>
        <h2>Hotel</h2>
        
         
        <asp:DropDownList ID="drdHotel" runat="server" CssClass="form-control"></asp:DropDownList>
<asp:RequiredFieldValidator ID="rfvHotel" runat="server" ControlToValidate="drdHotel" InitialValue="" ErrorMessage="Seleccione un hotel" CssClass="text-danger" Display="Dynamic" />
    </div>
      <div>
          <h2>Numero de habitación</h2>
           
          <asp:TextBox ID="txtnumhabitacion" runat="server" MaxLength="10" />
         <asp:RequiredFieldValidator ID="rfvNumeroHabitacion" runat="server" 
     ControlToValidate="txtnumhabitacion" ErrorMessage="El número de habitación es obligatorio." 
    Display="Dynamic" ForeColor="Red" />
          <!-- Validador personalizado para asegurar que el número de habitación no esté duplicado en el mismo hotel -->
<asp:CustomValidator ID="cvNumHabitacionUnico" runat="server" ControlToValidate="txtnumhabitacion" 
    ErrorMessage="El número de habitación no puede estar duplicado para el mismo hotel." 
    OnServerValidate="cvNumHabitacionUnico_ServerValidate" CssClass="text-danger"></asp:CustomValidator>
            
      </div>
      <div>
          <h2>Capacidad máxima</h2>
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
          <h2>Descripción</h2>
 <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" MaxLength="500" TextMode="MultiLine"></asp:TextBox>
          <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" 
                ControlToValidate="txtDescripcion" ErrorMessage="La descripción es obligatoria." 
                Display="Dynamic" ForeColor="Red" />
      </div>
      <div>
          <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" CausesValidation="false" />
      </div>
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
      
</asp:Content>
