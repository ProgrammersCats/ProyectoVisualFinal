Imports System.Data

Public Class Cliente
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
    Private _ruc As String
    Public Property Ruc() As String
        Get
            Return _ruc
        End Get
        Set(ByVal value As String)
            _ruc = value
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
    Private _direccion As String
    Public Property Direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(id As Integer, nombre As String, apellido As String, direccion As String, telefono As String, ruc As String)
        Me.Id = id
        Me.Nombre = nombre
        Me.Apellido = apellido
        Me.Telefono = telefono
        Me.Direccion = direccion
        Me.Ruc = ruc
    End Sub
    Public Sub New(fila As DataRow)
        Me.Id = fila("Id")
        Me.Nombre = fila("Nombre")
        Me.Apellido = fila("Apellido")
        Me.Ruc = fila("Ruc")
        Me.Telefono = fila("Telefono")
        Me.Direccion = fila("Direccion")
    End Sub

End Class
