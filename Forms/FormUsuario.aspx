<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormUsuario.aspx.vb" Inherits="Biblioteca_Proyecto.FormUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <style>
    .card-form {
        background: #e9f7ef;
        padding: 25px;
        border-radius: 12px;
        border: 1px solid #b2dfdb;
        box-shadow: 0 2px 6px rgba(0,0,0,0.1);
    }
    h2 {
        color: #1b5e20;
        font-weight: bold;
    }
    .btn-verde {
        background-color: #2e7d32;
        color: white;
        border-radius: 8px;
        padding: 8px 16px;
        border: none;
    }
    .btn-verde:hover {
        background-color: #1b5e20;
    }
</style>

<div class="container mt-4">
    <h2 class="text-center">Registrar Nuevo Lector</h2>

    <div class="row justify-content-center">
        <div class="col-md-6">
            <div class="card-form">

                <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>

                <div class="form-group mt-2">
                    <label>Nombre</label>
                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="form-group mt-3">
                    <label>Apellido</label>
                    <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="form-group mt-3">
                    <label>Nacionalidad</label>
                    <asp:TextBox ID="txtNacionalidad" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="form-group mt-3">
                    <label>Fecha de Nacimiento</label>
                    <asp:TextBox ID="txtFechaNacimiento" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="form-group mt-3">
                    <label>Teléfono</label>
                    <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="form-group mt-3">
                    <label>Correo</label>
                    <asp:TextBox ID="txtCorreo" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="text-center mt-4">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Lector" CssClass="btn-verde" OnClick="btnGuardar_Click" />
                </div>

            </div>
        </div>
    </div>

    <hr />

    <h3 class="text-center mt-4">Lectores Registrados</h3>

    <asp:GridView ID="gvLectores" runat="server" CssClass="table table-bordered table-striped mt-3" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="IdLector" HeaderText="ID" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
            <asp:BoundField DataField="Nacionalidad" HeaderText="Nacionalidad" />
            <asp:BoundField DataField="FechaNacimiento" HeaderText="Nacimiento" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
            <asp:BoundField DataField="Correo" HeaderText="Correo" />
        </Columns>
    </asp:GridView>

</div>   
</asp:Content>
