Public Class Libro
    'Atributos de la clase Libro
    Private _IdLibro As Integer
    Private _Titulo As String
    Private _Autor As String
    Private _Editorial As String
    Private _Copias As Integer

    'Constructor vacio
    Public Sub New()
    End Sub

    'Constructor de la clase Libro
    Public Sub New(idLibro As Integer, titulo As String, autor As String, editorial As String, copias As Integer)
        Me.IdLibro = idLibro
        Me.Titulo = titulo
        Me.Autor = autor
        Me.Editorial = editorial
        Me.Copias = copias


    End Sub
    'Propiedades de los atriubtos
    Public Property IdLibro As Integer
        Get
            Return _IdLibro
        End Get
        Set(value As Integer)
            _IdLibro = value
        End Set
    End Property

    Public Property Titulo As String
        Get
            Return _Titulo
        End Get
        Set(value As String)
            _Titulo = value
        End Set
    End Property

    Public Property Autor As String
        Get
            Return _Autor
        End Get
        Set(value As String)
            _Autor = value
        End Set
    End Property

    Public Property Editorial As String
        Get
            Return _Editorial
        End Get
        Set(value As String)
            _Editorial = value
        End Set
    End Property

    Public Property Copias As Integer
        Get
            Return _Copias
        End Get
        Set(value As Integer)
            _Copias = value
        End Set
    End Property
End Class