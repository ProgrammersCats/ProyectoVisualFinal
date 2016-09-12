Imports System.Data
Imports System.Xml

Public Class Usuario
    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _apellido As String
    Public Property Apellido() As String
        Get
            Return _apellido
        End Get
        Set(ByVal value As String)
            _apellido = value
        End Set
    End Property

    Private _direccion As String
    Public Property Direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property

    Private _telefono As String
    Public Property Telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
        End Set
    End Property

    Private _usuario As String
    Public Property Usuario() As String
        Get
            Return _usuario
        End Get
        Set(ByVal value As String)
            _usuario = value
        End Set
    End Property

    Private _contraseña As String
    Public Property Contraseña() As String
        Get
            Return _contraseña
        End Get
        Set(ByVal value As String)
            _contraseña = value
        End Set
    End Property

    Private _rol As String
    Public Property Rol() As String
        Get
            Return _rol
        End Get
        Set(ByVal value As String)
            _rol = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(id As Integer, usuario As String, contraseña As String, nombre As String, apellido As String, telefono As String, direccion As String, rol As String)
        Me.Id = id
        Me.Nombre = nombre
        Me.Apellido = apellido
        Me.Telefono = telefono
        Me.Direccion = direccion
        Me.Usuario = usuario
        Me.Contraseña = contraseña
        Me.Rol = rol
    End Sub
    Public Sub New(fila As DataRow)
        Me.Id = fila("Id")
        Me.Nombre = fila("Nombre")
        Me.Apellido = fila("Apellido")
        Me.Telefono = fila("Telefono")
        Me.Direccion = fila("Direccion")
        Me.Usuario = fila("Usuario")
        Me.Contraseña = fila("Contraseña")
        Me.Rol = fila("Rol")
    End Sub
    Public Sub New(user As Usuario)
        Me.Id = user.Id
        Me.Nombre = user.Nombre
        Me.Apellido = user.Apellido
        Me.Telefono = user.Telefono
        Me.Direccion = user.Direccion
        Me.Usuario = user.Usuario
        Me.Contraseña = user.Contraseña
        Me.Rol = user.Rol
    End Sub
End Class
