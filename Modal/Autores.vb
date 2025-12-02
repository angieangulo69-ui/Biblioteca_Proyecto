Public Class Autores
    Public Property IdAutor As Integer
    Public Property Nombre As String
    Public Property Apellido As String
    Public Property Nacionalidad As String
    Public Property FechaNacimiento As Date

    Public Sub New()
    End Sub
    Public Sub New(idAutor As Integer, nombre As String, apellido As String, nacionalidad As String, fechaNacimiento As Date)
        Me.IdAutor = idAutor
        Me.Nombre = nombre
        Me.Apellido = apellido
        Me.Nacionalidad = nacionalidad
        Me.FechaNacimiento = fechaNacimiento
    End Sub

End Class
