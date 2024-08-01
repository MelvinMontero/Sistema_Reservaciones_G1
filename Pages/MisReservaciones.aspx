<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisReservaciones.aspx.cs" Inherits="Sistema_Reservaciones_G1.Pages.MisReservaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Mis Reservaciones</h1>
    <a href="CrearReservacion.aspx">Nueva Reservación</a>
    <asp:GridView ID="gvMisReservaciones" 
            runat="server" 
            AutoGenerateColumns="false" 
            CssClass="align-content-lg-center  header-center=bold item-center"         
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
            <asp:BoundField DataField="idReservacion" HeaderText="# Reservacion" SortExpression="idReservacion"></asp:BoundField>
            <asp:BoundField DataField="nombre" HeaderText="Hotel" SortExpression="nombre"></asp:BoundField>
            <asp:BoundField DataField="fechaEntrada" HeaderText="Fecha Entrada" SortExpression="fechaEntrada" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
            <asp:BoundField DataField="fechaSalida" HeaderText="Fecha Salida" SortExpression="fechaSalida" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
            <asp:BoundField DataField="costoTotal" HeaderText="Costo" SortExpression="costoTotal" DataFormatString="{0:C2}"></asp:BoundField>
            <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="estado"></asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href="Detalle.aspx?id=<%# Eval ("idReservacion") %>" class="btn btn-link">Consultar</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>