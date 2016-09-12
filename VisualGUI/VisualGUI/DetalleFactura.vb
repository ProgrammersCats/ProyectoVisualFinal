Imports System.Data
Imports System.Data.OleDb
Public Class DetalleFactura
    Dim path As String = "..\..\..\BDEmpresa.accdb"
    Dim dbPath As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & path
    Private _id As String
    Public Property ID() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
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
    Private _idFact As String
    Public Property IdFactura() As String
        Get
            Return _idFact
        End Get
        Set(ByVal value As String)
            _idFact = value
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

    Sub New(fila As DataRow)
        Me.ID = fila(0)
        Me.IdFactura = fila("idFactura")
        Me.Cantidad = fila("Cantidad")
        Dim producto As Producto
        Using dbConexion As New OleDbConnection(dbPath)
            Dim consulta As String = "Select * from Productos"
            Dim dbAdapter As New OleDbDataAdapter(New OleDbCommand(consulta, dbConexion))
            Dim dsProductos As New DataSet("Productos")
            dbAdapter.Fill(dsProductos, "Productos")
            'MessageBox.Show(fila(1))
            For Each filaProd As DataRow In dsProductos.Tables("Productos").Rows
                If filaProd("Descripcion").Equals(fila("Producto")) Then
                    producto = New Producto(filaProd)
                    Me.Item = producto
                    Exit For
                End If
            Next
        End Using
        MessageBox.Show(Me.Item.Precio)

    End Sub
End Class
