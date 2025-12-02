<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="RegistroPrestamos.aspx.vb" Inherits="Biblioteca_Proyecto.RegistroPrestamos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    body {
        font-family: "Segoe UI";
    }

    .card-custom {
        background-color: #d8f3dc;
        border: 1px solid #95d5b2;
        border-radius: 15px;
        padding: 25px;
        box-shadow: 0px 4px 15px rgba(0,0,0,0.15);
    }

    .form-control {
        border-radius: 10px;
        border: 1px solid #74c69d;
        padding: 10px;
    }

    .form-control:focus {
        border-color: #1b4332;
        box-shadow: 0 0 6px #1b433296;
    }

    .btn-green {
        background-color: #2d6a4f;
        color: white;
        border-radius: 10px;
        padding: 10px 18px;
        border: none;
        transition: 0.3s;
    }

    .btn-green:hover {
        background-color: #1b4332;
        transform: translateY(-3px);
        box-shadow: 0px 4px 15px rgba(0,0,0,0.25);
    }

    .table-header-green {
        background-color: #2d6a4f !important;
        color: white !important;
    }
</style>

<div class="card-custom mt-4">

    <h2 class="text-center mb-4">Registro de Préstamos</h2>

    <div class="row g-3">

        <div class="col-md-6">
            <label>Seleccionar Libro</label>
            <asp:DropDownList ID="ddlLibros" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>

        <div class="col-md-6">
            <label>Seleccionar Usuario</label>
            <asp:DropDownList ID="ddlUsuarios" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>

        <div class="col-md-6">
            <label>Fecha Préstamo</label>
            <asp:TextBox ID="txtFechaPrestamo" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
        </div>

        <div class="col-md-6">
            <label>Fecha Devolución</label>
            <asp:TextBox ID="txtFecha" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
        </div>

    </div>

    <div class="text-center mt-4">
        <asp:Button ID="btnGuardar" runat="server" Text="Registrar Préstamo" CssClass="btn-green" />
    </div>

    <div class="mt-3 text-center">
        <asp:Label ID="lblMensaje" runat="server" CssClass="fw-bold"></asp:Label>
    </div>

</div>

<!-- LISTADO -->
<div class="card-custom mt-4">
    <h3 class="text-center mb-3">Historial de Préstamos</h3>

    <asp:GridView 
        ID="gvPrestamos"
        runat="server"
        AutoGenerateColumns="False"
        CssClass="table table-bordered table-hover text-center">

        <Columns>
            <asp:BoundField DataField="IdPrestamo" HeaderText="ID" />
            <asp:BoundField DataField="Titulo" HeaderText="Libro" />
            <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
            <asp:BoundField DataField="FechaPrestamo" HeaderText="Préstamo" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="FechaDevolucion" HeaderText="Devolución" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="Devuelto" HeaderText="Devuelto" />

            <asp:TemplateField HeaderText="Acción">
                <ItemTemplate>
                    <asp:Button ID="btnDevolver" runat="server" Text="Marcar Devuelto" CssClass="btn-green" CommandName="Devolver" CommandArgument='<%# Eval("IdPrestamo") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

        <HeaderStyle CssClass="table-header-green" />

    </asp:GridView>
</div>


</asp:Content>
