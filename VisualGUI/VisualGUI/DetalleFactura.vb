Public Class DetalleFactura

    Private _codigo As String
    Public Property Codigo() As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            _codigo = value
        End Set
    End Property
    Private _item As Producto
    Public Property Item() As Producto
        Get
            Return _item
        End Get
        Set(ByVal value As Producto)
            _item = value
        End Set
    End Property

    Private _cantidad As Integer
    Public Property Cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property

    Private _totalDetalle As Double
    Public ReadOnly Property TotalDetalle() As Double
        Get
            Return Me.Cantidad * Me.Item.Precio
        End Get

    End Property
    Sub New(item As Producto, cant As Integer)
        Me.Item = item
        Me.Cantidad = cant
    End Sub


End Class
