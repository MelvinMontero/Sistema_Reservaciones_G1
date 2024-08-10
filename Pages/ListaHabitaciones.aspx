<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaHabitaciones.aspx.cs" Inherits="Sistema_Reservaciones_G1.Pages.ListaHabitaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <title>Lista de habitaciones</title>
    <style>
        table {
            width: 100%;
            border-collapse: collapse;
        }
        th, td {
            padding: 8px;
            text-align: center;
            border-bottom: 1px solid #ddd;
        }
        th {
            background-color: #f2f2f2;
            font-weight: bold;
        }
        tr:nth-child(even) {
            background-color: #f2f2f2; 
        }
        .left-align {
            text-align: left;
        }
        .center-align {
            text-align: center;
        }
    </style>

    <form id="form1" runat="server">
        <div>
            <h1>Lista de habitaciones</h1>
            <asp:HyperLink ID="lnkCrearHabitacion" runat="server" NavigateUrl="~/Pages/CrearHabitacion.aspx">Crear habitación</asp:HyperLink>
            <br /><br />
            <asp:GridView ID="gvHabitaciones" runat="server" AutoGenerateColumns="False" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" HeaderStyle-CssClass="center-align" ItemStyle-CssClass="center-align" />
                    <asp:BoundField DataField="Hotel" HeaderText="Hotel" HeaderStyle-CssClass="left-align" ItemStyle-CssClass="left-align" />
                    <asp:BoundField DataField="NumeroHabitacion" HeaderText="Número de habitación" HeaderStyle-CssClass="center-align" ItemStyle-CssClass="center-align" />
                    <asp:BoundField DataField="CapacidadMaxima" HeaderText="Capacidad máxima" HeaderStyle-CssClass="center-align" ItemStyle-CssClass="center-align" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" HeaderStyle-CssClass="center-align" ItemStyle-CssClass="center-align" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink ID="lnkModificar" runat="server" Text="Modificar" NavigateUrl='<%# Eval("ID", "~/Pages/EditarHabitacion.aspx?ID={0}") %>'>
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger" Visible="False"></asp:Label>
        </div>
    </form>



</asp:Content>
