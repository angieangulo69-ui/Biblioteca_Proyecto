Public Class Home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lblNombre.Text = Session("NombreUsuario")
            lblEmail.Text = Session("CorreoUsuario")
        End If
    End Sub

End Class