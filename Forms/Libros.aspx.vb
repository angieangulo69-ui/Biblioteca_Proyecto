Imports System.Data.SqlClient

Public Class Libros
    Inherits System.Web.UI.Page
    Protected DbHelper As New DbHelper()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarAutores()
            CargarLibros()
        End If
    End Sub
    Private Sub CargarAutores()
        Dim dt As DataTable = DbHelper.ExecuteDataTable(
            "SELECT IdAutor, (Nombre + ' ' + Apellido) AS Autor FROM Autores",
            Nothing)

        ddlAutor.DataSource = dt
        ddlAutor.DataTextField = "Autor"
        ddlAutor.DataValueField = "IdAutor"
        ddlAutor.DataBind()

        ddlAutor.Items.Insert(0, New ListItem("--Seleccione Autor--", "0"))
    End Sub

    Private Sub CargarLibros()
        Dim query As String =
            "SELECT L.IdLibro, L.Titulo, 
                    (A.Nombre + ' ' + A.Apellido) AS Autor,
                    L.Categoria, L.Anio, L.Disponible
             FROM Libros L
             INNER JOIN Autores A ON L.IdAutor = A.IdAutor"

        Dim dt As DataTable = DbHelper.ExecuteDataTable(query, Nothing)

        gvLibros.DataSource = dt
        gvLibros.DataBind()
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If ddlAutor.SelectedValue = "0" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "msg",
                "alert('Debe seleccionar un autor');", True)
            Return
        End If

        Dim query As String =
            "INSERT INTO Libros (Titulo, IdAutor, Categoria, Anio)
             VALUES (@Titulo, @IdAutor, @Categoria, @Anio)"

        Dim parametros As New List(Of SqlParameter) From {
            New SqlParameter("@Titulo", txtTitulo.Text),
            New SqlParameter("@IdAutor", ddlAutor.SelectedValue),
            New SqlParameter("@Categoria", txtCategoria.Text),
            New SqlParameter("@Anio", txtAnio.Text)
        }

        DbHelper.ExecuteNonQuery(query, parametros)

        ClientScript.RegisterStartupScript(Me.GetType(), "msg",
            "alert('Libro registrado exitosamente');", True)

        txtTitulo.Text = ""
        txtCategoria.Text = ""
        txtAnio.Text = ""
        ddlAutor.SelectedIndex = 0

        CargarLibros()
    End Sub

End Class