<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarReservaciones.aspx.cs" Inherits="Sistema_Reservaciones_G1.Pages.GestionarReservaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Gestionar Reservaciones</h1>
     <div>
            <h2>Gestionar reservaciones</h2>
          <div class="form-row">
            <div class="form-group">
                <asp:DropDownList ID="ddlClientes" runat="server">
                    <asp:ListItem Text="Seleccione un cliente" Value="0" />
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <span>Fecha de Entrada</span><br />
                <asp:TextBox ID="txtFechaEntrada" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvFechaEntrada" runat="server" ControlToValidate="txtFechaEntrada" ErrorMessage="La fecha de entrada es obligatoria" CssClass="text-danger" Display="Dynamic" />
                <asp:CompareValidator ID="cvFechaEntrada" runat="server" ControlToValidate="txtFechaEntrada" Operator="DataTypeCheck" Type="Date" ErrorMessage="Ingrese una fecha válida en formato dd/MM/yyyy" CssClass="text-danger" Display="Dynamic" />
                <asp:CustomValidator ID="customFechaEntrada" runat="server" ControlToValidate="txtFechaEntrada" ErrorMessage="La fecha de entrada no puede ser menor o igual a la fecha actual" CssClass="text-danger" Display="Dynamic" OnServerValidate="ValidateFechaEntrada" />
            </div>
            <div class="form-group">
                <span>Fecha de Salida</span><br />
                <asp:TextBox ID="txtFechaSalida" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvFechaSalida" runat="server" ControlToValidate="txtFechaSalida" ErrorMessage="La fecha de salida es obligatoria" CssClass="text-danger" Display="Dynamic" />
                <asp:CompareValidator ID="cvFechaSalida" runat="server" ControlToValidate="txtFechaSalida" Operator="DataTypeCheck" Type="Date" ErrorMessage="Ingrese una fecha válida en formato dd/MM/yyyy" CssClass="text-danger" Display="Dynamic" />
                <asp:CustomValidator ID="customFechaSalida" runat="server" ControlToValidate="txtFechaSalida" ErrorMessage="La fecha de salida no puede ser menor que la fecha de entrada" CssClass="text-danger" Display="Dynamic" OnServerValidate="ValidateFechaSalida" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
                <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
            
    </div>
    <div>
        <a href="CrearReservacion.aspx" class="btn btn-primary">Nueva Reservación</a><br />
        <div>  
            <asp:GridView ID="gvReservaciones" runat="server" AutoGenerateColumns="false" CssClass="grid-view"
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
                    <asp:BoundField DataField="idReservacion" HeaderText="# Reservacion" SortExpression="idReservacion">
                        <HeaderStyle CssClass="header-center bold"/>
                        <ItemStyle CssClass="item-center"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="nombreCompleto" HeaderText="Cliente" SortExpression="nombreCompleto">
                        <HeaderStyle CssClass="header-left bold"/>
                        <ItemStyle CssClass="item-left"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="nombre" HeaderText="Hotel" SortExpression="nombre">
                        <HeaderStyle CssClass="header-left bold"/>
                        <ItemStyle CssClass="item-left"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="fechaEntrada" HeaderText="Fecha Entrada" SortExpression="fechaEntrada" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle CssClass="header-center bold"/>
                        <ItemStyle CssClass="item-center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fechaSalida" HeaderText="Fecha Salida" SortExpression="fechaSalida" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle CssClass="header-center bold"/>
                        <ItemStyle CssClass="item-center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="costoTotal" HeaderText="Costo" SortExpression="costoTotal" DataFormatString="{0:C2}">
                        <HeaderStyle CssClass="header-right bold"/>
                        <ItemStyle CssClass="item-right"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="estado">
                        <HeaderStyle CssClass="header-center bold"/>
                        <ItemStyle CssClass="item-center"/>
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href="/Detalle.aspx" class="btn btn-secondary">Consultar</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
             </asp:GridView>
        </div>
    </div>         
</asp:Content>
