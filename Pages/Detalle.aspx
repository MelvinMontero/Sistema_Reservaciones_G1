<%@ Page Title="Detalles de reservacion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Sistema_Reservaciones_G1.Pages.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="container">
            <div class="details">
                <h2>Detalle de reservación</h2>  <asp:TextBox ID="TextDetallesR" runat="server"></asp:TextBox>
                <p><strong># reservación:</strong></p>
                <asp:TextBox ID="TextResernum" runat="server"></asp:TextBox>
                <p><strong>Hotel:</strong></p>
             <asp:TextBox ID="Texthotel" runat="server"></asp:TextBox>
                <p><strong>Número habitación:</strong></p>
            <asp:TextBox ID="Textnumhabit" runat="server"></asp:TextBox>
                <p><strong>Cliente:</strong></p>
              <asp:TextBox ID="Textnumcliente" runat="server"></asp:TextBox>
                <p><strong>Fecha de entrada:</strong></p>
         <asp:TextBox ID="Textfechaentrada" runat="server"></asp:TextBox>
                <p><strong>Fecha de salida:</strong></p>
<asp:TextBox ID="Textfechasalida" runat="server"></asp:TextBox>
                <p><strong>Días de la reserva:</strong></p>
         <asp:TextBox ID="Textdiareserva" runat="server"></asp:TextBox>
                <p><strong>Número de niños:</strong></p>
           <asp:TextBox ID="Textninos" runat="server"></asp:TextBox>
                <p><strong>Número de niños:</strong></p>
                 <asp:TextBox ID="Texnumninos" runat="server"></asp:TextBox>
                <p><strong>Costo total:</strong></p>
                 <asp:TextBox ID="Textcostototal" runat="server"></asp:TextBox>

                 </div>
                <asp:Button ID="btnEdit1" runat="server" Text="Editar reservación" OnClick="btnEdit1_Click" />
                <asp:Button ID="btnCancel1" runat="server" Text="Cancelar reservación" OnClick="btnCancel1_Click" />
                <asp:Button ID="btnBack1" runat="server" Text="Regresar" OnClick="btnBack1_Click" />
            </div>
            

                <%-- gridview no se muestra aun --%>
                <h2>Lista de acciones realizadas</h2>
                <asp:GridView ID="gvActions" runat="server" AutoGenerateColumns="False" CssClass="grid-view">
                    <Columns>
                          <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Datefecha">
                          <HeaderStyle CssClass="header-center bold"/>
                           <ItemStyle CssClass="item-center"/>
                           </asp:BoundField>
                          <asp:BoundField DataField="Accion" HeaderText="Acción" SortExpression="AccionDetalle">
                           <HeaderStyle CssClass="header-center bold"/>
                         <ItemStyle CssClass="item-center"/>
                          </asp:BoundField>
                         <asp:BoundField DataField="Realizada" HeaderText="Realizada por" SortExpression="Realizadodetalle">
                        <HeaderStyle CssClass="header-center bold"/>
                         <ItemStyle CssClass="item-center"/>
                           </asp:BoundField>

                    </Columns>
                </asp:GridView>
            
    

</asp:Content>
