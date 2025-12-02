<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Libros.aspx.vb" Inherits="Biblioteca_Proyecto.Libros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    .card-libro {
        background-color: #d8f3dc;
        border: 1px solid #95d5b2;
        border-radius: 15px;
        padding: 25px;
        margin-bottom: 25px;
    }
    h2 {
        color: #1b4332;
        font-weight: bold;
    }
    .grid-green {
        border: 1px solid #95d5b2;
        background-color: #f1fff4;
        border-radius: 12px;
        overflow: hidden;
    }
    .grid-green th {
        background-color: #95d5b2;
        color: #1b4332;
        padding: 10px;
    }
</style>

<div class="card-libro">
    <h2>Registro de Libros</h2>

    <div class="row g-3">
        <div class="col-md-4">
            <asp:TextBox ID="txtTitulo" CssClass="form-control" placeholder="Título del Libro" runat="server"></asp:TextBox>
        </div>

        <div class="col-md-4">
            <asp:DropDownList ID="ddlAutor" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>

        <div class="col-md-2">
            <asp:TextBox ID="txtCategoria" CssClass="form-control" placeholder="Categoría" runat="server"></asp:TextBox>
        </div>

        <div class="col-md-2">
            <asp:TextBox ID="txtAnio" CssClass="form-control" TextMode="Number" placeholder="Año" runat="server"></asp:TextBox>
        </div>
    </div>

    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Libro"
        CssClass="btn btn-success mt-3" />
</div>

<div class="grid-green">
    <asp:GridView 
        ID="gvLibros" 
        runat="server" 
        AutoGenerateColumns="False" 
        CssClass="table table-bordered"
        Width="100%">
        
        <Columns>
            <asp:BoundField DataField="IdLibro" HeaderText="ID" />
            <asp:BoundField DataField="Titulo" HeaderText="Título" />
            <asp:BoundField DataField="Autor" HeaderText="Autor" />
            <asp:BoundField DataField="Categoria" HeaderText="Categoría" />
            <asp:BoundField DataField="Anio" HeaderText="Año" />
            <asp:CheckBoxField DataField="Disponible" HeaderText="Disponible" />
        </Columns>

    </asp:GridView>
</div>
</asp:Content>
