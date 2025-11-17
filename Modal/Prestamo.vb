Public Class Prestamo
    'Atributos'
    Private _IdPrestamo As Integer
    Private _IdUsuario As Integer
    Private _IdLibro As Integer
    Private _FechaPrestamo As DateTime
    Private _FechaDevolucion As DateTime
    'Constructor vacio
    Public Sub New()
    End Sub
    'Constructor con parametros 
    Public Sub New(idPrestamo As Integer, idUsuario As Integer, idLibro As Integer, fechaPrestamo As Date, fechaDevolucion As Date)
        Me._IdPrestamo = idPrestamo
        Me._IdUsuario = idUsuario
        Me._IdLibro = idLibro
        Me._FechaPrestamo = fechaPrestamo
        Me._FechaDevolucion = fechaDevolucion
    End Sub

    Public Property IdPrestamo As Integer
        Get
            Return _IdPrestamo
        End Get
        Set(value As Integer)
            _IdPrestamo = value
        End Set
    End Property

    Public Property IdUsuario As Integer
        Get
            Return _IdUsuario
        End Get
        Set(value As Integer)
            _IdUsuario = value
        End Set
    End Property

    Public Property IdLibro As Integer
        Get
            Return _IdLibro
        End Get
        Set(value As Integer)
            _IdLibro = value
        End Set
    End Property

    Public Property FechaPrestamo As Date
        Get
            Return _FechaPrestamo
        End Get
        Set(value As Date)
            _FechaPrestamo = value
        End Set
    End Property

    Public Property FechaDevolucion As Date
        Get
            Return _FechaDevolucion
        End Get
        Set(value As Date)
            _FechaDevolucion = value
        End Set
    End Property
End Class
