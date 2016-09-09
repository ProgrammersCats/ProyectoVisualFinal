Imports System.Data
Imports System.Data.OleDb

Public Class winVendedor
    Public path As String = "..\..\..\BDEmpresa.accdb"
    Public dbPath As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & path
    Public NroFactura As Integer
    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Me.Hide()
        Me.Owner.Show()
    End Sub

    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        Dim winFactura As New WinFactura
        winFactura.Owner = Me
        winFactura.DataContext = Me.DataContext
        winFactura.Show()
        Me.Hide()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim dsFactura As New DataSet
        'Dim dtFactura As New DataTable("Factura")

        Using dbConexion As New OleDbConnection(dbPath)
            Dim sentencia As String = "Select * from Facturas"
            Dim dbAdapter As New OleDbDataAdapter(New OleDbCommand(sentencia, dbConexion))
            dbAdapter.Fill(dsFactura, "Factura")
            dtgVendedor.DataContext = dsFactura
            'MessageBox.Show(dsFactura.Tables("Factura").Rows.Count)
            NroFactura = dsFactura.Tables("Factura").Rows(dsFactura.Tables("Factura").Rows.Count - 1)("Id") + 1

        End Using

        'MessageBox.Show(NroFactura)

        'dtFactura.Columns.Add("Id")
        'dtFactura.Columns.Add("Fecha")
        'dtFactura.Columns.Add("Vendedor")
        'dtFactura.Columns.Add("Cliente")
        'dtFactura.Columns.Add("Ruc")

        'dtFactura.Rows.Add("001", "10/12/2016", "Ricardo", "Malu-chan", "0954854785")
        'dtFactura.Rows.Add("002", "13/12/2016", "Paul", "Yander", "0954658955")
        'dtFactura.Rows.Add("003", "14/11/2016", "Chibi", "Miguel", "0985485685")

        'dsFactura.Tables.Add(dtFactura)
        'dtgVendedor.DataContext = dsFactura
    End Sub
End Class
