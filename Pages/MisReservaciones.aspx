<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisReservaciones.aspx.cs" Inherits="Sistema_Reservaciones_G1.Pages.MisReservaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Mis Reservaciones</h1>
    <a href="~/Pages/CrearReservacion.aspx">Nueva Reservación</a>
    <asp:GridView ID="gvMisReservaciones" runat="server" AutoGenerateColumns="false" CssClass="grid-view">
        <Columns>
            <asp:BoundField DataField="idReservacion" HeaderText="# Reservacion" SortExpression="idReservacion">
                <HeaderStyle CssClass="header-center bold"/>
                <ItemStyle CssClass="item-center"/>
            </asp:BoundField>
            <asp:BoundField DataField="Hotel" HeaderText="Hotel" SortExpression="Hotel">
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
            <asp:BoundField DataField="costo" HeaderText="Costo" SortExpression="costo" DataFormatString="{0:C2}">
                <HeaderStyle CssClass="header-right bold"/>
                <ItemStyle CssClass="item-right"/>
            </asp:BoundField>
            <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="estado">
                <HeaderStyle CssClass="header-center bold"/>
                <ItemStyle CssClass="item-center"/>
            </asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href="/Detalle.aspx" class="btn btn-primary">Consultar</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
