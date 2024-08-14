<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Sistema_Reservaciones_G1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">ToGO</h1>
            <p class="lead">ToGO es un sitio web el cual sirve de sistema de reservación de hoteles.</p>
            <p><a href="https://github.com/MelvinMontero/Sistema_Reservaciones_G1" 
                class="btn btn-primary btn-md">Para más información únete a nuestro GitHub</a></p>
        </section>
        <div style="text-align:center;">
            <asp:Image ID="Logo2" ImageUrl="~/imagenes/ToGOInicio.png" runat="server" />
        </div>

    </main>

</asp:Content>
