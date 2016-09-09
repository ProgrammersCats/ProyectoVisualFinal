Imports System.Data

Public Class Provincia
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
    Private _capital As String
    Public Property Capital() As String
        Get
            Return _capital
        End Get
        Set(ByVal value As String)
            _capital = value
        End Set
    End Property
    Private _iva As Integer
    Public Property Iva() As Integer
        Get
            Return _iva
        End Get
        Set(ByVal value As Integer)
            _iva = value
        End Set
    End Property
    Sub New(id As Integer, nombre As String, capital As String, iva As Integer)
        Me.Id = id
        Me.Nombre = nombre
        Me.Capital = capital
        Me.Iva = iva
    End Sub
    Public Sub New(fila As DataRow)
        Me.Id = fila("Id")
        Me.Nombre = fila("Nombre")
        Me.Capital = fila("Capital")
        Me.Iva = fila("Iva")
    End Sub
End Class
