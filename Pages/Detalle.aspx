<%@ Page Title="Detalles de reservacion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Sistema_Reservaciones_G1.Pages.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="details">
            <h2>Detalle de reservación</h2>
            <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="alert alert-danger"></asp:Label>
            <table>
                <tr>
                    <td><strong># reservación:</strong></td>
                    <td><asp:TextBox ID="TextResernum" runat="server" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><strong>Hotel:</strong></td>
                    <td><asp:TextBox ID="Texthotel" runat="server" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><strong>Número habitación:</strong></td>
                    <td><asp:TextBox ID="Textnumhabit" runat="server" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><strong>Cliente:</strong></td>
                    <td><asp:TextBox ID="Textnumcliente" runat="server" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><strong>Fecha de entrada:</strong></td>
                    <td><asp:TextBox ID="Textfechaentrada" runat="server" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><strong>Fecha de salida:</strong></td>
                    <td><asp:TextBox ID="Textfechasalida" runat="server" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><strong>Días de la reserva:</strong></td>
                    <td><asp:TextBox ID="Textdiareserva" runat="server" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><strong>Número de niños:</strong></td>
                    <td><asp:TextBox ID="Textninos" runat="server" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><strong>Número de adultos:</strong></td>
                    <td><asp:TextBox ID="textAdultos" runat="server" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><strong>Costo total:</strong></td>
                    <td><asp:TextBox ID="Textcostototal" runat="server" ReadOnly="true"></asp:TextBox></td>
                </tr>
            </table>
        </div>
        <asp:Button ID="btnEditar" runat="server" Text="Editar reservación"  CssClass="btn btn-primary" OnClick="btnEditar_Click"/>
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar reservación" CssClass="btn btn-danger" OnClick="btnCancelar_Click"/>
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CausesValidation="false" CssClass="btn btn-secondary" OnClick="btnRegresar_Click"/>
    </div>
    <div>
        <h2>Lista de acciones realizadas</h2>
        <asp:GridView ID="grvBitacoras" runat="server" AutoGenerateColumns="false" CssClass="grid-view"
        AllowCustomPaging="True" 
        CellPadding="5" 
        GridLines="Both" 
        RowStyle-BorderColor="Black"
        RowStyle-BorderStyle="Solid"
        RowStyle-BorderWidth="1px"
        HeaderStyle-BorderColor="Black"
        HeaderStyle-BorderStyle="Solid"
        HeaderStyle-BorderWidth="1px"
        CellSpacing="5">
            <Columns>
                    <asp:BoundField DataField="fechaDeLaAccion" HeaderText="Fecha" SortExpression="fechaDeLaAccion">
                    <HeaderStyle CssClass="header-center bold"/>
                    <ItemStyle CssClass="item-center"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="accionRealizada" HeaderText="Acción" SortExpression="accionRealizada">
                    <HeaderStyle CssClass="header-center bold"/>
                    <ItemStyle CssClass="item-center"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="nombreCompleto" HeaderText="Realizada por" SortExpression="nombreCompleto">
                <HeaderStyle CssClass="header-center bold"/>
                    <ItemStyle CssClass="item-center"/>
                    </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
