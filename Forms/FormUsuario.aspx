<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormUsuario.aspx.vb" Inherits="Biblioteca_P.FormUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="editando" runat="server"/> 

    <div class="container mt-4 mb-5">
        <div class="card shadow-lg border-0 rounded-4">
            <div class="card-header bg-primary text-white text-center rounded-top-4">
                <h3 class="mb-0">Gestión de Usuarios</h3>
            </div>

            <div class="card-body p-4">   <!-- Campos del formulario -->
                <div class="row g-3">
                   
                    <h2 class="mb-3">Registro de Usuarios</h2>

                    <div class="col-md-4">
                        <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="Nombre" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtApellido1" CssClass="form-control" placeholder="Primer Apellido" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtApellido2" CssClass="form-control" placeholder="Segundo Apellido" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-md-4">
                        <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="Email" runat="server"></asp:TextBox>
                    </div>   
                    <div class="col-md-4">
                        <asp:TextBox ID="txtFechaRegistro" CssClass="form-control" TextMode="Date" placeholder="Fecha de Registro" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtTelefono" CssClass="form-control" placeholder="Teléfono" runat="server"></asp:TextBox>
                    </div>
                </div>

                 <asp:DropDownList ID="DRol" CssClass="form-control mb-3" runat="server">
                   <asp:ListItem Text="Seleccione un rol..." Value=""></asp:ListItem>
                   <asp:ListItem Text="Lector" Value="Lector"></asp:ListItem>
                   <asp:ListItem Text="Bibliotecario" Value="Bibliotecario"></asp:ListItem>
                 </asp:DropDownList>


                            
                <div class="mt-4 d-flex flex-wrap gap-2 justify-content-center">
                    
                    <asp:Button ID="btn_registrar" runat="server" CssClass="btn btn-primary btn-hover-mover" Text="Registrar" OnClick="btn_registrar_Click" />
                
                </div>                                  
                </div>

                <div class="text-center mt-3">
                    <asp:Label ID="lblMensaje" runat="server" CssClass="fw-bold text-primary"></asp:Label>
                </div>
            </div>
        </div>

        <div class="card shadow-lg border-0 rounded-4 mt-4">
            <div class="card-header bg-secondary text-white text-center rounded-top-4">
                <h4 class="mb-0">Listado de Personas</h4>
            </div>
            <div class="card-body">
               <asp:GridView 
                 ID="gvUsuario" 
                 runat="server" 
                 AutoGenerateColumns="False"
                 DataKeyNames="IdUsuario"
                 CssClass="table table-striped table-hover text-center align-middle"
                 OnRowDeleting="gvUsuario_RowDeleting"
                 OnRowEditing="gvUsuario_RowEditing"
                 OnRowUpdating="gvUsuario_RowUpdating"
                 OnRowCancelingEdit="gvUsuario_RowCancelingEdit"
                 OnSelectedIndexChanged="gvUsuario_SelectedIndexChanged">

    <Columns>
              
        <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-success" />
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-primary" />

        
        <asp:BoundField DataField="IdUsuario" HeaderText="ID" Visible="False" ReadOnly="True" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
        <asp:BoundField DataField="Apellido1" HeaderText="Apellido1" SortExpression="Apellido1" />
        <asp:BoundField DataField="Apellido2" HeaderText="Apellido2" SortExpression="Apellido2" />
        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" SortExpression="Telefono"/>
        <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro" SortExpression="FechaRegistro"/>
        <asp:BoundField DataField="Rol" HeaderText="Rol" SortExpression="Rol" />

    </Columns>

    <HeaderStyle CssClass="table-dark text-white" />
    <RowStyle CssClass="table-light" />

</asp:GridView>
                
            </div>
        </div>
   
</asp:Content>
