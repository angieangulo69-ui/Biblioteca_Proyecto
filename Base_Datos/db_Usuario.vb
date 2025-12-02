Imports System.Data.SqlClient
Imports System.Security.Cryptography.X509Certificates

Public Class db_Usuario
    'Cadena de conexión desde Web.config'
    Public ReadOnly ConnectionString As String = ConfigurationManager.ConnectionStrings("Proyecto_prograIIIConnectionString").ConnectionString

    'Método para crear una nueva Persona
    Public Function create(Usuario As Usuario) As Boolean
        Try
            Dim sql As String = "INSERT INTO Usuarios (Nombre, Apellido1, Apellido2, Email,Telefono, FechaRegistro,Rol ) VALUES (@Nombre, @Apellido1, @Apellido2, @Email, @Telefono, @FechaRegistro,@Rol )"
            Dim Parametros As New List(Of SqlParameter) From {
            New SqlParameter("@Nombre", Usuario.Nombre),
            New SqlParameter("@Apellido1", Usuario.Apellido1),
            New SqlParameter("@Apellido2", Usuario.Apellido2),
            New SqlParameter("@Email", Usuario.Email),
            New SqlParameter("@Telefono", Usuario.Telefono),
            New SqlParameter("@FechaRegistro", Usuario.FechaRegistro),
            New SqlParameter("@Rol", Usuario.Rol)
        }

            Using connetion As New SqlConnection(ConnectionString)
                Using command As New SqlCommand(sql, connetion)
                    command.Parameters.AddRange(Parametros.ToArray())
                    connetion.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            ' Return False
            Throw ex
        End Try

        Return True
    End Function

    'Método para eliminar una Persona por ID
    Public Function delete(ByRef id As Integer) As Boolean

        Try
            Dim sql As String = "DELETE FROM Usuarios WHERE IdUsuario = @IdUsuario"
            Dim Parametros As New List(Of SqlParameter) From {
            New SqlParameter("@IdUsuario", id)
        }
            Using connetion As New SqlConnection(ConnectionString)
                Using command As New SqlCommand(sql, connetion)
                    command.Parameters.AddRange(Parametros.ToArray())
                    connetion.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using

            Return True

        Catch ex As Exception
        End Try
        Return False
    End Function

    'Método para actualizar una Persona
    Public Function update(ByRef Usuario As Usuario) As Boolean

        Try
            Dim sql As String = "UPDATE Usuarios SET Nombre = @Nombre, Apellido1 = @Apellido1,  Apellido2 = @Apellido2 , 
                                Email =@Email,Telefono =@Telefono, FechaRegistro =@FechaRegistro, Rol =@Rol  WHERE IdUsuario = @IdUsuario"

            Dim Parametros As New List(Of SqlParameter) From {
            New SqlParameter("@IdUsuario", Usuario.IdUsuario),
            New SqlParameter("@Nombre", Usuario.Nombre),
            New SqlParameter("@Apellido1", Usuario.Apellido1),
            New SqlParameter("@Apellido2", Usuario.Apellido2),
            New SqlParameter("@Email", Usuario.Email),
            New SqlParameter("@Telefono", Usuario.Telefono),
            New SqlParameter("@FechaRegistro", Usuario.FechaRegistro),
            New SqlParameter("@Rol", Usuario.Rol)
        }
            Using connetion As New SqlConnection(ConnectionString)
                Using command As New SqlCommand(sql, connetion)
                    command.Parameters.AddRange(Parametros.ToArray())
                    connetion.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
        End Try
        Return False
    End Function

    'Método para leer todas las Personas
    Public Function readAll() As DataTable
        Dim datos_tabla As New DataTable()
        Try
            Dim sql As String = "SELECT * FROM Usuarios ORDER BY IdUsuario DESC"
            Using connection As New SqlConnection(ConnectionString)
                Using command As New SqlCommand(sql, connection)
                    Dim adapter As New SqlDataAdapter(command)
                    adapter.Fill(datos_tabla)
                End Using
            End Using
        Catch ex As Exception

        End Try
        Return datos_tabla

    End Function
End Class
