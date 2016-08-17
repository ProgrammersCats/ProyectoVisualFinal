Imports System.Xml

Public Class Persona
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

    Public Sub New()

    End Sub

    Public Sub New(nombre As String, apellido As String, telefono As String, direccion As String)
        Me.Nombre = nombre
        Me.Apellido = apellido
        Me.Telefono = telefono
        Me.Direccion = direccion
    End Sub

    Public Overridable Function ValidarDatos()
        Return False
    End Function


End Class
