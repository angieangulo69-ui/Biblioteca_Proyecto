Public Class SiteMaster
    Inherits MasterPage
    Protected Autenticador As Boolean = False
    Protected esAdmin As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ' Verifica si la sesión existe
        Dim UsuarioObj As Usuario = TryCast(Session("Usuario"), Usuario)

        Autenticador = UsuarioObj IsNot Nothing

        If Autenticador Then
            esAdmin = (UsuarioObj.Rol = "2") ' Si es admin
        End If

        liAdmin.Visible = esAdmin ' Mostrar enlace de admin si es admin
    End Sub
End Class