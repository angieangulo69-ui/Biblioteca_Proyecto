<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormLogin.aspx.vb" Inherits="Biblioteca_Proyecto.FormLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!--  ESTILO MODERNO -->
    <style>
        body {
            background: linear-gradient(135deg, #95d5b2, #74c69d, #52b788);
            background-attachment: fixed;
            font-family: 'Segoe UI', sans-serif;
        }

        .login-card {
            width: 360px;
            border-radius: 18px !important;
            padding: 30px;
            background: white;
            box-shadow: 0 8px 25px rgba(0,0,0,0.15);
            animation: fadeIn 0.6s ease;
        }

        .form-control {
            border-radius: 10px;
            border: 1px solid #b7e4c7;
            padding: 10px;
            transition: all 0.2s;
        }

        .form-control:focus {
            border-color: #40916c;
            box-shadow: 0 0 6px rgba(64, 145, 108, 0.4);
        }

        .btn-login {
            background-color: #40916c;
            border: none;
            padding: 10px 20px;
            font-weight: bold;
            border-radius: 10px;
            transition: 0.3s;
            width: 100%;
        }

        .btn-login:hover {
            background-color: #2d6a4f;
            transform: translateY(-2px);
            box-shadow: 0 4px 10px rgba(0,0,0,0.2);
        }

        .title-welcome {
            color: white;
            font-weight: bold;
            text-shadow: 1px 2px 4px rgba(0,0,0,0.3);
        }

        @keyframes fadeIn {
            from { opacity: 0; transform: translateY(10px); }
            to { opacity: 1; transform: translateY(0); }
        }
    </style>

    <!-- TÍTULO -->
    <div class="text-center mb-4">
        <h1 class="display-5 title-welcome">Bienvenido al Sistema</h1>
        <p class="lead text-white">Control de Vehículos y Propietarios</p>
    </div>

    <!-- TARJETA DE LOGIN -->
    <div class="d-flex justify-content-center">
        <div class="login-card">

            <h3 class="text-center mb-3" style="color: #2d6a4f;">Iniciar Sesión</h3>

            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" CssClass="fw-bold"></asp:Label>

            <!-- Usuario -->
            <div class="form-group mt-2">
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" CssClass="fw-semibold"></asp:Label>
                <asp:TextBox ID="txtUsuario" CssClass="form-control mt-1" runat="server"></asp:TextBox>
            </div>

            <!-- Contraseña -->
            <div class="form-group mt-3">
                <asp:Label ID="lblContrasena" runat="server" Text="Contraseña:" CssClass="fw-semibold"></asp:Label>
                <asp:TextBox ID="txtPassword" CssClass="form-control mt-1" runat="server" TextMode="Password"></asp:TextBox>
            </div>

            <!-- Botón -->
            <div class="text-center mt-4">
                <asp:Button 
                    ID="btnIniciarSesion" 
                    runat="server" 
                    Text="Iniciar Sesión"  
                    CssClass="btn-login"  
                    OnClick="btnIniciarSesion_Click"/>
            </div>

        </div>
    </div>

</asp:Content>
