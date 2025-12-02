<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="RegistarLibros.aspx.vb" Inherits="Biblioteca_Proyecto.RegistarLibros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    .card-form {
        background-color: #d8f3dc;
        border: 1px solid #95d5b2;
        border-radius: 12px;
        padding: 25px;
    }
    h2 { color: #1b4332; }
</style>

<div class="card-form">
    <h2>Registrar Libro</h2>

    <div class="row g-3">

        <div class="col-md-6">
            <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control" placeholder="Título del libro"></asp:TextBox>
        </div>

        <div class="col-md-6">
            <asp:DropDownList ID="ddlAutor" runat="server" CssClass="form-control">
                <asp:ListItem Text="Seleccione Autor" Value=""> </asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="col-md-4">
            <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control" placeholder="Categoría"></asp:TextBox>
        </div>

        <div class="col-md-4">
            <asp:TextBox ID="txtAnio" runat="server" CssClass="form-control" placeholder="Año"></asp:TextBox>
        </div>

        <div class="col-md-4">
            <asp:CheckBox ID="chkDisponible" runat="server" Checked="true" Text="Disponible" />
        </div>

    </div>

    <asp:Button ID="btnGuardar" runat="server" Text="Registrar Libro"
        CssClass="btn btn-success mt-3" />

</div>
</asp:Content>
