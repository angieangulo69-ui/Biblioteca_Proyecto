Public Class dbLogin
    'Atributos'
    Private _IdLogin As Integer
    Private _Correo As String
    Private _Contrasena As String
    Private _FechaRegistro As DateTime


    'Constructor vacio
    Public Sub New()
    End Sub

    'Constructor con parametros
    Public Sub New(idLogin As Integer, correo As String, contrasena As String, fechaRegistro As Date)
        Me._IdLogin = idLogin
        Me._Correo = correo
        Me._Contrasena = contrasena
        Me._FechaRegistro = fechaRegistro
    End Sub
    'Propiedades de los atributos
    Public Property IdLogin As Integer
        Get
            Return _IdLogin
        End Get
        Set(value As Integer)
            _IdLogin = value
        End Set
    End Property

    Public Property Correo As String
        Get
            Return _Correo
        End Get
        Set(value As String)
            _Correo = value
        End Set
    End Property

    Public Property Contrasena As String
        Get
            Return _Contrasena
        End Get
        Set(value As String)
            _Contrasena = value
        End Set
    End Property

    Public Property FechaRegistro As Date
        Get
            Return _FechaRegistro
        End Get
        Set(value As Date)
            _FechaRegistro = value
        End Set
    End Property


End Class
