Imports System.Data.SqlClient

Public Class FormUsuario
    Inherits System.Web.UI.Page


    Dim db As New DbHelper

    Private Sub CargarLectores()
        Dim query As String = "SELECT * FROM Lectores"
        Dim dt As DataTable = db.ExecuteDataTable(query, New List(Of SqlParameter)())
        gvLectores.DataSource = dt
        gvLectores.DataBind()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        If txtNombre.Text = "" Or txtApellido.Text = "" Or txtCorreo.Text = "" Then
            lblMensaje.Text = "Debe completar los campos obligatorios."
            Return
        End If

        Dim query As String = "
        INSERT INTO Lectores (Nombre, Apellido, Nacionalidad, FechaNacimiento, Telefono, Correo)
        VALUES (@Nombre, @Apellido, @Nacionalidad, @FechaNacimiento, @Telefono, @Correo)
        "

        Dim parametros As New List(Of SqlParameter) From {
            New SqlParameter("@Nombre", txtNombre.Text),
            New SqlParameter("@Apellido", txtApellido.Text),
            New SqlParameter("@Nacionalidad", txtNacionalidad.Text),
            New SqlParameter("@FechaNacimiento", txtFechaNacimiento.Text),
            New SqlParameter("@Telefono", txtTelefono.Text),
            New SqlParameter("@Correo", txtCorreo.Text)
        }

        db.ExecuteNonQuery(query, parametros)

        lblMensaje.ForeColor = Drawing.Color.Green
        lblMensaje.Text = "Lector registrado correctamente."

        txtNombre.Text = ""
        txtApellido.Text = ""
        txtNacionalidad.Text = ""
        txtFechaNacimiento.Text = ""
        txtTelefono.Text = ""
        txtCorreo.Text = ""

        CargarLectores()
    End Sub

End Class