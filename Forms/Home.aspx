<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Home.aspx.vb" Inherits="Biblioteca_Proyecto.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<style>
    .banner {
        background-image: url('/imagenes/biblio.jpg');
        background-size: cover;
        padding: 120px;
        border-radius: 20px;
        color: aqua;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
        text-shadow: 1px 1px 2px white;
        text-align: left;
    }

    .card-home {
        border-radius: 15px;
        padding: 25px;
        background-color: azure;
         box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
        border: 1px solid #d0e6ff;
    }
</style>

<div class="banner">
    <h1>Biblioteca Digital</h1>
    <h4>Gestiona tus libros y préstamos fácilmente</h4>
</div>

<div class="row mt-4 text-center">
    <div class="col-md-6">
        <div class="card-home">
            <h3>Bienvenida/o</h3>
            <asp:Label ID="lblNombre" runat="server"></asp:Label>
        </div>
    </div>

    <div class="col-md-6">
        <div class="card-home">
            <h3>Correo</h3>
            <asp:Label ID="lblEmail" runat="server"></asp:Label>
        </div>
    </div>
</div>

</asp:Content>
