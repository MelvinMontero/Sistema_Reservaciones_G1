<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaHabitaciones.aspx.cs" Inherits="Sistema_Reservaciones_G1.Pages.ListaHabitaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Lista de habitaciones</h1>
        <div>
            <asp:HyperLink ID="lnkCrearHabitacion" runat="server" CssClass="btn btn-primary" NavigateUrl="~/Pages/CrearHabitacion.aspx">Crear habitación</asp:HyperLink>
            <br /><br />
            <asp:GridView ID="gvHabitaciones" runat="server" AutoGenerateColumns="false" CssClass="grid-view"
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
                    <asp:BoundField DataField="ID" HeaderText="ID" HeaderStyle-CssClass="center-align" ItemStyle-CssClass="center-align" />

                    <asp:BoundField DataField="Hotel" HeaderText="Hotel" HeaderStyle-CssClass="left-align" ItemStyle-CssClass="left-align" />

                    <asp:BoundField DataField="NumeroHabitacion" HeaderText="Número de habitación" HeaderStyle-CssClass="center-align" ItemStyle-CssClass="center-align" />

                    <asp:BoundField DataField="CapacidadMaxima" HeaderText="Capacidad máxima" HeaderStyle-CssClass="center-align" ItemStyle-CssClass="center-align" />

                    <asp:BoundField DataField="Estado" HeaderText="Estado" HeaderStyle-CssClass="center-align" ItemStyle-CssClass="center-align" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink ID="lnkModificar" CssClass="btn btn-secondary" runat="server" Text="Modificar" NavigateUrl='<%# Eval("ID", "~/Pages/EditarHabitacion.aspx?ID={0}") %>'>
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" Visible="False"></asp:Label>
        </div>
</asp:Content>
