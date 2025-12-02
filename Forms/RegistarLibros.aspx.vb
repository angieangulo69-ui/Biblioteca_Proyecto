Imports System.Data.SqlClient

Public Class RegistarLibros
    Inherits System.Web.UI.Page
    Protected DbHelper As New DbHelper()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarAutores()
        End If
    End Sub
    Private Sub CargarAutores()
        Dim dt As DataTable =
            DbHelper.ExecuteDataTable("SELECT IdAutor, Nombre FROM Autores", Nothing)

        ddlAutor.DataSource = dt
        ddlAutor.DataTextField = "Nombre"
        ddlAutor.DataValueField = "IdAutor"
        ddlAutor.DataBind()
        ddlAutor.Items.Insert(0, New ListItem("--Seleccione--", ""))
    End Sub
    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim query As String =
            "INSERT INTO Libros (Titulo, IdAutor, Categoria, Anio, Disponible)
             VALUES (@Titulo, @IdAutor, @Categoria, @Anio, @Disponible)"

        Dim parametros As New List(Of SqlParameter) From {
            New SqlParameter("@Titulo", txtTitulo.Text),
            New SqlParameter("@IdAutor", ddlAutor.SelectedValue),
            New SqlParameter("@Categoria", txtCategoria.Text),
            New SqlParameter("@Anio", txtAnio.Text),
            New SqlParameter("@Disponible", chkDisponible.Checked)
        }

        DbHelper.ExecuteNonQuery(query, parametros)

        ClientScript.RegisterStartupScript(Me.GetType(), "alert",
            "alert('Libro registrado con éxito');", True)

        txtTitulo.Text = ""
        txtCategoria.Text = ""
        txtAnio.Text = ""
    End Sub
End Class