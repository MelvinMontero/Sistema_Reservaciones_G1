<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gestionarhabitaciones.aspx.cs" Inherits="Sistema_Reservaciones_G1.Pages.Gestionarhabitaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Lista de habitaciones</h1>
    <link rel="stylesheet" type="text/css" href="~/Styles/site.css" />
    <%-- falta el estilo cebra y las validaciones --%>
<a href="CrearHabitacion.aspx">Crear habitacion</a>
<asp:GridView ID="gvListaHabitaciones"  runat="server" AutoGenerateColumns="false" CssClass="grid-view" >
    
    <Columns>
       <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Hotel" HeaderText="Hotel" />
                    <asp:BoundField DataField="NumeroHabitacion" HeaderText="Número habitación" />
                    <asp:BoundField DataField="CapacidadMaxima" HeaderText="Capacidad máxima" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="btnModificar" runat="server" CommandName="Modificar" CommandArgument='<%# Eval("ID") %>' Text="Modificar" CssClass="btn-link" />
                        </ItemTemplate>
                    </asp:TemplateField>
    </Columns>
</asp:GridView>
</asp:Content>
