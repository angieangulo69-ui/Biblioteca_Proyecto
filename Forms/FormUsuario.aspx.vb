Imports System.Data.SqlClient

Public Class FormUsuario
    Inherits System.Web.UI.Page
    'Instancias de la calse usuario
    Dim usuario As New Usuario()
    Protected dbHelper As New BD_Usuario()

    'Evento de carga de la pagina
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Cargar_Usuario()

        End If
    End Sub
    'Método para guardar una nueva persona desde los TextBox
    Protected Sub btn_registrar_Click(sender As Object, e As EventArgs)
        Try
            Dim usuario As New Usuario With {
                .Nombre = txtNombre.Text.Trim(),
                .Apellido1 = txtApellido1.Text.Trim(),
                .Apellido2 = txtApellido2.Text.Trim(),
                .Email = txtEmail.Text.Trim(),
                .Telefono = txtTelefono.Text.Trim(),
                .FechaRegistro = Convert.ToDateTime(txtFechaRegistro.Text.Trim()),
                .Rol = DRol.Text.Trim()
                }

            If dbHelper.create(usuario) Then
                lblMensaje.Text = "Usuario creada"
                LimpiarCampos()
                Cargar_Usuario()
            Else
                lblMensaje.Text = "Ocurrio un error"
            End If
        Catch ex As Exception
            lblMensaje.Text = " Error: " & ex.Message
        End Try
    End Sub
    'Método para eliminar una fila del GridView
    Protected Sub gvUsuario_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

        Try
            Dim id As Integer = Convert.ToInt32(gvUsuario.DataKeys(e.RowIndex).Value)
            dbHelper.delete(id)
            lblMensaje.Text = "Persona eliminada"
            Cargar_Usuario 'Acutalizar el GridView'
            e.Cancel = True

        Catch ex As Exception
            lblMensaje.Text = "Error al eliminar la persona: " & ex.Message
        End Try

    End Sub
    'Método para editar una fila del GridView
    Protected Sub gvUsuario_RowEditing(sender As Object, e As GridViewEditEventArgs)

        Try
            gvUsuario.EditIndex = e.NewEditIndex
            Cargar_Usuario()
        Catch ex As Exception
            lblMensaje.Text = " Error al editar: " & ex.Message
        End Try
    End Sub



    '   Método para cargar las personas en el GridView
    Private Sub Cargar_Usuario()
        Try
            Dim dt As New DataTable()
            Using conn As New SqlConnection(ConfigurationManager.ConnectionStrings("Proyecto_prograIIIConnectionString").ConnectionString)
                Dim sql As String = "SELECT * FROM Usuarios"
                Using cmd As New SqlCommand(sql, conn)
                    conn.Open()
                    dt.Load(cmd.ExecuteReader())
                End Using
            End Using

            gvUsuario.DataSource = dt
            gvUsuario.DataBind()
        Catch ex As Exception
            lblMensaje.Text = "Error al cargar personas: " & ex.Message
        End Try
    End Sub
    'Método para cancelar la edición de una fila en el GridView
    Protected Sub gvUsuario_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)

        gvUsuario.EditIndex = -1
        Cargar_Usuario()


    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs)
        LimpiarCampos()
        lblMensaje.Text = " Campos limpiados"
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)
        LimpiarCampos()
        ' btnActualizar.Visible = False
        'btnMostrar.Visible = True
        editando.Value = ""
        lblMensaje.Text = "Edición cancelada"
    End Sub

    Protected Sub btnCargar_Click(sender As Object, e As EventArgs)
        Cargar_Usuario()
        lblMensaje.Text = " Lista de Usuarios actualizada"
    End Sub

    Private Sub LimpiarCampos()
        ' Limpia los TextBox del formulario
        txtNombre.Text = String.Empty
        txtApellido1.Text = String.Empty
        txtApellido2.Text = String.Empty
        txtEmail.Text = String.Empty
        txtTelefono.Text = String.Empty
        txtFechaRegistro.Text = String.Empty
        DRol.Text = String.Empty


        ' Limpia el campo oculto de edición
        editando.Value = String.Empty

        ' Restablece el estado de los botones
        ' btnMostrar.Visible = True
        ' btnActualizar.Visible = False

        ' Limpia el mensaje en pantalla
        lblMensaje.Text = ""
    End Sub

    'Método para actualizar una fila editada en el GridView
    Protected Sub gvUsuario_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)

        Try
            Dim id As Integer = Convert.ToInt32(gvUsuario.DataKeys(e.RowIndex).Value)
            Dim persona As Usuario = New Usuario With {
                .IdUsuario = id,
                .Nombre = e.NewValues("Nombre"),
                .Apellido1 = e.NewValues("Apellido1"),
                .Apellido2 = e.NewValues("Apellido2"),
                .Email = e.NewValues("Email"),
                .Telefono = e.NewValues("Telefono"),
                .FechaRegistro = e.NewValues("FechaRegistro"),
                .Rol = e.NewValues("Rol")
            }

            If dbHelper.update(persona) Then
                lblMensaje.Text = "Usuario actualizado correctamente"
            Else
                lblMensaje.Text = "Error al actualizar el Usuario"
            End If

            gvUsuario.EditIndex = -1
            Cargar_Usuario()
            lblMensaje.Text = "Usuario actualizado ."
        Catch ex As Exception
            lblMensaje.Text = " Error al actualizar: " & ex.Message
        End Try

    End Sub
    'Método para seleccionar una fila en el GridView
    Protected Sub gvUsuario_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim id As Integer = Convert.ToInt32(gvUsuario.SelectedDataKey.Value)

            Using conexion As New SqlConnection(ConfigurationManager.ConnectionStrings("Proyecto_progralllConnectionString").ConnectionString)
                Dim sql As String = "SELECT * FROM Usuarios WHERE IdUsuario = @IdUsuario"
                Using cmd As New SqlCommand(sql, conexion)
                    cmd.Parameters.AddWithValue("@IdUsuario", id)
                    conexion.Open()
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            ' Cargar los datos en los campos de texto
                            txtNombre.Text = dr("Nombre").ToString()
                            txtApellido1.Text = dr("Apellido1").ToString()
                            txtApellido2.Text = dr("Apellido2").ToString()
                            txtEmail.Text = dr("Email").ToString()
                            txtTelefono.Text = dr("Telefono").ToString()
                            txtFechaRegistro.Text = Convert.ToDateTime(dr("FechaRegistro")).ToString("yyyy-MM-dd")
                            DRol.Text = dr("Rol").ToString()

                            ' Guardar el id seleccionado para actualizar
                            editando.Value = id.ToString()

                            ' Cambiar visibilidad de botones
                            ' btnMostrar.Visible = False
                            'btnActualizar.Visible = True

                            lblMensaje.Text = "Modo edición: Usuario seleccionada (ID " & id & ")"
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            lblMensaje.Text = " Error al seleccionar: " & ex.Message
        End Try
    End Sub
    'Método para actualizar una persona desde los TextBox
    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Try
            If String.IsNullOrEmpty(editando.Value) OrElse Not IsNumeric(editando.Value) Then
                lblMensaje.Text = " No se ha seleccionado un Usuario para actualizar."
                Exit Sub
            End If

            'Crear el objeto Persona con los datos actualizados
            Dim Usuario As Usuario = New Usuario With {
             .IdUsuario = Convert.ToInt32(editando.Value),
            .Nombre = txtNombre.Text.Trim(),
            .Apellido1 = txtApellido1.Text().Trim(),
            .Apellido2 = txtApellido2.Text().Trim(),
            .Email = txtEmail.Text(),
            .Telefono = txtTelefono.Text().Trim()
        }
            'Asignar la fecha de nacimiento si no está vacía
            If Not String.IsNullOrEmpty(txtFechaRegistro.Text) Then
                Usuario.FechaRegistro = Convert.ToDateTime(txtFechaRegistro.Text)
            End If
            'Actualizar la persona en la base de datos
            dbHelper.update(Usuario)

            lblMensaje.Text = "Usuario actualizado correctamente."
            LimpiarCampos()
            Cargar_Usuario()

        Catch ex As Exception
            lblMensaje.Text = "Error al actualizar: " & ex.Message
        End Try
    End Sub

End Class