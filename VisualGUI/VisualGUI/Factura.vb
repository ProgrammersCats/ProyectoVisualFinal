Public Class Factura
    Private _numeroFactura As String
    Public Property NumeroFactura As String
        Get
            Return _numeroFactura
        End Get
        Set(ByVal value As String)
            _numeroFactura = value
        End Set
    End Property
    Private _fecha As String
    Public Property Fecha() As String
        Get
            Return _fecha
        End Get
        Set(ByVal value As String)
            _fecha = value
        End Set
    End Property
    Private _cliente As Cliente
    Public Property Cliente() As Cliente
        Get
            Return _cliente
        End Get
        Set(ByVal value As Cliente)
            _cliente = value
        End Set
    End Property

    Private _vendedor As Usuario
    Public Property Vendedor() As Usuario
        Get
            Return _vendedor
        End Get
        Set(ByVal value As Usuario)
            _vendedor = value
        End Set
    End Property

    Private _lugarEmi As Provincia
    Public Property LugarEmision() As Provincia
        Get
            Return _lugarEmi
        End Get
        Set(ByVal value As Provincia)
            _lugarEmi = value
        End Set
    End Property

    Private _detalles As New ArrayList()
    Public Property Detalles() As ArrayList
        Get
            Return _detalles
        End Get
        Set(ByVal value As ArrayList)
            _detalles = value
        End Set
    End Property

    Private _subtotal As Double
    Public ReadOnly Property Subtotal() As Double
        Get
            Dim subT As Double
            For Each det As DetalleFactura In Me.Detalles
                subT += det.TotalDetalle
            Next
            Return subT
        End Get

    End Property

    Private _total As Double
    Public ReadOnly Property Total() As Double
        Get
            Return Me.IVA + Me.Subtotal
        End Get

    End Property

    Private _iva As Double
    Public ReadOnly Property IVA() As Double
        Get
            Return (Me.Subtotal * Me.LugarEmision.Iva) / 100
        End Get

    End Property

    Private _devolucion As Double
    Public Property Devolucion() As Double
        Get
            Return (Me.Total * _devolucion) / 100
        End Get
        Set(ByVal value As Double)
            _devolucion = value
        End Set
    End Property

    Private _totalPagar As Double
    Public ReadOnly Property TotalPagar() As Double
        Get
            Return Me.Total - Me.Devolucion
        End Get

    End Property

    Public Sub New(numero As String)
        Me.NumeroFactura = numero
    End Sub
    Public Sub New()
        Me.Fecha = Date.Now
        Me.NumeroFactura = 999
    End Sub

End Class
