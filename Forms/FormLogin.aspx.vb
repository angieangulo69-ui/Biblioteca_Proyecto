Public Class FormLogin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub btnIniciarSesion_Click(sender As Object, e As EventArgs) Handles btnIniciarSesion.Click
        Dim Usuario As String = txtUsuario.Text.Trim()
        Dim Password As String = txtPassword.Text

        Dim DbHelper As New dbLogin()
        ' Encriptar contraseña
        Dim encrypter As New Simple3Des("MiClaveSecreta123") 'Clave secreta para encriptación
        Dim passEncrypted As String = encrypter.EncryptData(Password) 'Encriptar la contraseña ingresada

        If DbHelper.ValidateLogin(Usuario, passEncrypted) Then
            ' Login exitoso
            Dim User As Usuario = DbHelper.GetUser(Usuario)
            Dim UsuarioOb As Usuario = DbHelper.GetUser(Usuario) ' Obtener objeto Usuario desde la base de datos
            Session("Usuario") = User 'Guardar el objeto Usuario en la sesión
            If User.Rol = "2" Then
                Response.Redirect("Admin.aspx") 'Redireccionar a la página de administración si es admin
                Return
            End If
            Response.Redirect("Home.aspx") 'Redireccionar a la página principal
        Else
            ' Login fallido
            Utils.SwalUtils.ShowSwalError(Me, "Error de autenticación", "Usuario o contraseña incorrectos.")
        End If

    End Sub
End Class