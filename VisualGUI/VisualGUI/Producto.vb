Imports System.Data

Public Class Producto
    Private _id As String
    Public Property Id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property
    Private _descripcion As String
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    Private _precio As Double
    Public Property Precio() As Double
        Get
            Return _precio
        End Get
        Set(ByVal value As Double)
            _precio = value
        End Set
    End Property
    Private _costo As Double
    Public Property Costo() As Double
        Get
            Return _costo
        End Get
        Set(ByVal value As Double)
            _costo = value
        End Set
    End Property

    Sub New(id As String, descripcion As String, costo As Double, precio As Double)
        Me.Id = id
        Me.Descripcion = descripcion
        Me.Costo = costo
        Me.Precio = precio
    End Sub
    Sub New(fila As DataRowView)
        'Me.Id = fila("Id")
        Me.Descripcion = fila("Descripcion")
        Me.Costo = fila("Costo")
        Me.Precio = fila("Precio")
    End Sub
End Class
