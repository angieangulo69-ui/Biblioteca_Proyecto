Public Class Categoria
    Public Class Categoria
        'Atributos'
        Private _IdCategoria As Integer
        Private _NombreCategoria As String

        'Constructor vacio
        Public Sub New()

        End Sub
        'Constructor con parametros
        Public Sub New(idCategoria As Integer, nombreCategoria As String)
            Me._IdCategoria1 = idCategoria
            Me._NombreCategoria1 = nombreCategoria

        End Sub
        'Propiedades de los atriubtos
        Public Property _IdCategoria1 As Integer
            Get
                Return _IdCategoria
            End Get
            Set(value As Integer)
                _IdCategoria = value
            End Set
        End Property

        Public Property _NombreCategoria1 As String
            Get
                Return _NombreCategoria
            End Get
            Set(value As String)
                _NombreCategoria = value
            End Set
        End Property
    End Class
End Class
