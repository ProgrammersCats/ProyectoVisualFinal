Public Class Pagos
    Private _id As String
    Public Property Id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property
    Private _tipo As String
    Public Property Tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal value As String)
            _tipo = value
        End Set
    End Property
    Private _valor As Integer
    Public Property Valor() As Integer
        Get
            Return _valor
        End Get
        Set(ByVal value As Integer)
            _valor = value
        End Set
    End Property
    Sub New(id As Integer, tipo As String, valor As String)
        Me.Id = id
        Me.Tipo = tipo
        Me.Valor = valor
    End Sub
End Class
