<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Sistema_Reservaciones_G1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">ToGO</h1>
            <p class="lead">ToGO es un sitio web el cual sirve de sistema de reservación de hoteles.</p>
            <p><a href="https://teams.microsoft.com/l/message/19:0a59e920-02ff-4f52-8749-428cf1ac20ad_f86db6b5-d0a4-4aa4-8438-f0a7ec2eb6ee@unq.gbl.spaces/1723433121819?context=%7B%22contextType%22%3A%22chat%22%7D" 
                class="btn btn-primary btn-md">Para más información únete a nuestro GitHub</a></p>
        </section>
        <div style="text-align:center;">
            <asp:Image ID="Logo2" ImageUrl="~/imagenes/ToGOInicio.png" runat="server" />
        </div>

    </main>

</asp:Content>
