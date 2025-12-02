Imports System.Data.SqlClient

Public Class RegistroPrestamos
    Inherits System.Web.UI.Page
    Dim db As New DbHelper

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarUsuarios()
            CargarLibrosDisponibles()
            CargarPrestamos()
            txtFecha.Text = Date.Now.ToString("yyyy-MM-dd")
        End If
    End Sub

    ' ================================
    '   CARGAR LECTORES (ANTES Usuarios2)
    ' ================================
    Private Sub CargarUsuarios()
        Dim dt As DataTable = db.ExecuteDataTable(
            "SELECT IdLector, (Nombre + ' ' + Apellido) AS NombreCompleto FROM Lectores",
            New List(Of SqlParameter)()
        )

        ddlUsuarios.DataSource = dt
        ddlUsuarios.DataTextField = "NombreCompleto"
        ddlUsuarios.DataValueField = "IdLector"
        ddlUsuarios.DataBind()

        ddlUsuarios.Items.Insert(0, New ListItem("-- Seleccione Lector --", "0"))
    End Sub

    Private Sub CargarLibrosDisponibles()
        Dim dt As DataTable = db.ExecuteDataTable(
            "SELECT IdLibro, Titulo FROM Libros WHERE Disponible = 1",
            New List(Of SqlParameter)()
        )

        ddlLibros.DataSource = dt
        ddlLibros.DataTextField = "Titulo"
        ddlLibros.DataValueField = "IdLibro"
        ddlLibros.DataBind()

        ddlLibros.Items.Insert(0, New ListItem("-- Seleccione Libro --", "0"))
    End Sub

    Private Sub CargarPrestamos()
        Dim query As String =
        "
        SELECT 
            P.IdPrestamo,
            (U.Nombre + ' ' + U.Apellido) AS Usuario,
            L.Titulo,
            P.FechaPrestamo,
            P.FechaDevolucion,
            P.Devuelto
        FROM Prestamos P
        INNER JOIN Lectores U ON P.IdUsuario = U.IdLector
        INNER JOIN Libros L ON P.IdLibro = L.IdLibro
        "

        Dim dt As DataTable = db.ExecuteDataTable(query, New List(Of SqlParameter)())
        gvPrestamos.DataSource = dt
        gvPrestamos.DataBind()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)

        ' Validación
        If ddlUsuarios.SelectedValue = "0" Or ddlLibros.SelectedValue = "0" Then
            lblMensaje.Text = "Debe seleccionar un lector y un libro."
            lblMensaje.ForeColor = Drawing.Color.Red
            Return
        End If

        ' Insertar préstamo
        Dim query As String =
            "INSERT INTO Prestamos (IdUsuario, IdLibro, FechaPrestamo, FechaDevolucion, Devuelto)
             VALUES (@IdUsuario, @IdLibro, @FechaPrestamo, @FechaDevolucion, 0)"

        Dim params As New List(Of SqlParameter) From {
            New SqlParameter("@IdUsuario", ddlUsuarios.SelectedValue),
            New SqlParameter("@IdLibro", ddlLibros.SelectedValue),
            New SqlParameter("@FechaPrestamo", txtFechaPrestamo.Text),
            New SqlParameter("@FechaDevolucion", txtFecha.Text)
        }

        db.ExecuteNonQuery(query, params)

        ' Marcar libro como NO disponible
        db.ExecuteNonQuery(
            "UPDATE Libros SET Disponible = 0 WHERE IdLibro = @IdLibro",
            New List(Of SqlParameter) From {
                New SqlParameter("@IdLibro", ddlLibros.SelectedValue)
            }
        )

        lblMensaje.ForeColor = Drawing.Color.Green
        lblMensaje.Text = "Préstamo registrado correctamente."

        CargarLibrosDisponibles()
        CargarPrestamos()
    End Sub

End Class