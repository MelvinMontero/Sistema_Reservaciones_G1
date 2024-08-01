<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearReservacion.aspx.cs" Inherits="Sistema_Reservaciones_G1.Pages.CrearReservacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Crear Reservación</h1>
    <div>
        <div>
            <span>Hotel</span><br />
            <asp:DropDownList ID="drdHotel" runat="server" CssClass="form-control"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvHotel" runat="server" ControlToValidate="drdHotel" InitialValue="" ErrorMessage="Seleccione un hotel" CssClass="text-danger" Display="Dynamic" /><br />           
            <span>Cliente</span><br />
            <asp:DropDownList ID="drdCliente" runat="server" CssClass="form-control"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvCliente" runat="server" ControlToValidate="drdCliente" InitialValue="" ErrorMessage="Seleccione un cliente" CssClass="text-danger" Display="Dynamic" /><br />       
            <div style="display: flex; gap: 20px;">
                <div>
                    <span>Fecha de Entrada</span><br />
                    <asp:TextBox ID="txtFechaEntrada" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFechaEntrada" runat="server" ControlToValidate="txtFechaEntrada" ErrorMessage="La fecha de entrada es obligatoria" CssClass="text-danger" Display="Dynamic" />
                    <asp:CompareValidator ID="cvFechaEntrada" runat="server" ControlToValidate="txtFechaEntrada" Operator="DataTypeCheck" Type="Date" ErrorMessage="Ingrese una fecha válida en formato dd/MM/yyyy" CssClass="text-danger" Display="Dynamic" />
                    <asp:CustomValidator ID="customFechaEntrada" runat="server" ControlToValidate="txtFechaEntrada" ErrorMessage="La fecha de entrada no puede ser menor o igual a la fecha actual" CssClass="text-danger" Display="Dynamic" OnServerValidate="ValidateFechaEntrada" />
                </div>
                <div>
                    <span>Fecha de Salida</span><br />
                    <asp:TextBox ID="txtFechaSalida" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFechaSalida" runat="server" ControlToValidate="txtFechaSalida" ErrorMessage="La fecha de salida es obligatoria" CssClass="text-danger" Display="Dynamic" />
                    <asp:CompareValidator ID="cvFechaSalida" runat="server" ControlToValidate="txtFechaSalida" Operator="DataTypeCheck" Type="Date" ErrorMessage="Ingrese una fecha válida en formato dd/MM/yyyy" CssClass="text-danger" Display="Dynamic" />
                    <asp:CustomValidator ID="customFechaSalida" runat="server" ControlToValidate="txtFechaSalida" ErrorMessage="La fecha de salida no puede ser menor que la fecha de entrada" CssClass="text-danger" Display="Dynamic" OnServerValidate="ValidateFechaSalida" />
                </div>
            </div>
            <span>Número de Adultos</span><br />
            <asp:TextBox ID="txtNumAdultos" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNumAdultos" runat="server" ControlToValidate="txtNumAdultos" ErrorMessage="El número de adultos es obligatorio" CssClass="text-danger" Display="Dynamic" />
            <asp:RangeValidator ID="rvNumAdultos" runat="server" ControlToValidate="txtNumAdultos" MinimumValue="1" MaximumValue="100" Type="Integer" ErrorMessage="El número de adultos debe ser mayor a 0" CssClass="text-danger" Display="Dynamic" /><br />
            <span>Número de Niños</span><br />
            <asp:TextBox ID="txtNumNinhos" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNumNinhos" runat="server" ControlToValidate="txtNumNinhos" ErrorMessage="El número de niños es obligatorio" CssClass="text-danger" Display="Dynamic" />
            <asp:RangeValidator ID="rvNumNinhos" runat="server" ControlToValidate="txtNumNinhos" MinimumValue="0" MaximumValue="100" Type="Integer" ErrorMessage="El número de niños debe ser mayor o igual a 0" CssClass="text-danger" Display="Dynamic" /><br />
        </div>
    </div>
    <div>
        <div>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click"/>
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click"/>
        </div>
    </div>
</asp:Content>
