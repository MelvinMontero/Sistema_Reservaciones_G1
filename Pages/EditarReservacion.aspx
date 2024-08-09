<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarReservacion.aspx.cs" Inherits="Sistema_Reservaciones_G1.Pages.EditarReservacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Modificar reservacion</h1>
    <div class="form-row">
        <div class="details col-md-12">
            <div class="row mt-1 mb-1">
                <div class="col-md-3">
                    <asp:Label ID="Label7" runat="server" Text="Hotel"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtHotel" runat="server" required="required" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row mt-1 mb-1">
                <div class="col-md-3">
                    <asp:Label ID="Label6" runat="server" Text="Numero de Habitación"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtHabitacion" runat="server" required="required" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row mt-1 mb-1">
                <div class="col-md-3">
                    <asp:Label ID="Label5" runat="server" Text="Cliente"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtCliente" runat="server" required="required" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row mt-1 mb-1">
                <div class="col-md-3"><asp:Label ID="Label3" runat="server" Text="Fecha Entrada"></asp:Label></div>
                <div class="col-md-3"><asp:Label ID="Label4" runat="server" Text="Fecha Salida"></asp:Label></div>
            </div>
            <div class="row mt-1 mb-1">
                <div class="col-md-3">
                    <asp:TextBox ID="txtFechaEntrada" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    <asp:RegularExpressionValidator 
                        ID="revFechaEntrada" 
                        runat="server" 
                        ControlToValidate="txtFechaEntrada"
                        ErrorMessage="Fecha en formato dd/MM/yyyy" 
                        ValidationExpression="^\d{4}-\d{2}-\d{2}$" 
                        CssClass="text-danger">
                    </asp:RegularExpressionValidator>

                    <asp:CustomValidator 
                        ID="cvFechaEntrada" 
                        runat="server" 
                        ControlToValidate="txtFechaEntrada" 
                        ErrorMessage="La fecha de entrada no puede ser menor que la fecha actual ni mayor que la fecha de salida." 
                        OnServerValidate="cvFechaEntrada_ServerValidate" 
                        CssClass="text-danger">
                    </asp:CustomValidator>
                </div>

                <div class="col-md-3">
                    <asp:TextBox ID="txtFechaSalida" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    <asp:RegularExpressionValidator 
                        ID="revFechaSalida" 
                        runat="server" 
                        ControlToValidate="txtFechaSalida"
                        ErrorMessage="Fecha en formato dd/MM/yyyy" 
                        ValidationExpression="^\d{4}-\d{2}-\d{2}$" 
                        CssClass="text-danger">
                    </asp:RegularExpressionValidator>

                    <asp:CustomValidator 
                        ID="cvFechaSalida" 
                        runat="server" 
                        ControlToValidate="txtFechaSalida" 
                        ErrorMessage="La fecha de salida no puede ser menor que la fecha de entrada ni menor que la fecha actual." 
                        OnServerValidate="cvFechaSalida_ServerValidate" 
                        CssClass="text-danger">
                    </asp:CustomValidator>
                </div>
            </div>
            <div class="row mt-1 mb-1">
                <div class="col-md-3"><asp:Label ID="Label1" runat="server" Text="Numero de adultos"></asp:Label></div>
                <div class="col-md-3"><asp:Label ID="Label2" runat="server" Text="Numero de niños"></asp:Label></div>
            </div>
            <div class="row mt-1 mb-1">
                <div class="col-md-3">
                    <asp:TextBox ID="txtnumeroAdultos" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator 
                        ID="revNumeroAdultos" 
                        runat="server" 
                        ControlToValidate="txtnumeroAdultos" 
                        ErrorMessage="Ingrese un número entero" 
                        ValidationExpression="^\d+$" 
                        ForeColor="Red">
                    </asp:RegularExpressionValidator>
                    <asp:RangeValidator 
                        ID="rvNumeroAdultos" 
                        runat="server" 
                        ControlToValidate="txtnumeroAdultos" 
                        ErrorMessage="El número debe ser al menos 1." 
                        MinimumValue="1" 
                        MaximumValue="4" 
                        Type="Integer" 
                        ForeColor="Red">
                    </asp:RangeValidator>
                </div>
                <div class="col-md-3">
                     <asp:TextBox ID="txtnumeroNinhos" runat="server" CssClass="form-control"></asp:TextBox>
                     <asp:RegularExpressionValidator 
                         ID="revNumeroNinhos" 
                         runat="server" 
                         ControlToValidate="txtnumeroNinhos" 
                         ErrorMessage="Ingrese un número entero" 
                         ValidationExpression="^\d+$" 
                         ForeColor="Red">
                     </asp:RegularExpressionValidator>
                     <asp:RangeValidator 
                         ID="rvNumeroNinhos" 
                         runat="server" 
                         ControlToValidate="txtnumeroNinhos" 
                         ErrorMessage="No puede ser menor que 0" 
                         MinimumValue="0" 
                         MaximumValue="4" 
                         Type="Integer" 
                         ForeColor="Red">
                     </asp:RangeValidator>
                </div>  
            </div>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click"/>
            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-secondary" CausesValidation="false" OnClick="btnRegresar_Click"/>
        </div>          
    </div> 
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
</asp:Content>
