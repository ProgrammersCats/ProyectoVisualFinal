Imports System.Data
Imports System.Data.OleDb

Public Class WinDetalle
    Dim productoSelected As Producto
    Dim winFactura As WinFactura
    Dim dsDetalle As DataSet
    Public path As String = "..\..\..\BDEmpresa.accdb"
    Public dbPath As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & path
    Private Sub Window_Closed(sender As Object, e As EventArgs)
        winFactura = Me.Owner
        winFactura.Show()
        winFactura.DataContext = dsDetalle
        Me.Close()

    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Using conexiondb As New OleDbConnection(dbPath)
            Dim consulta As String = "Select * From Productos"
            Dim dbAdapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexiondb))
            Dim dsProducto As New DataSet
            dbAdapter.Fill(dsProducto, "Productos")
            dtgProducto.DataContext = dsProducto

        End Using
    End Sub

    Private Sub dtgProducto_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dtgProducto.SelectionChanged
        Dim fila As DataRowView = sender.SelectedItem
        If (fila IsNot Nothing) Then
            txtProducto.Text = fila(1)
            productoSelected = New Producto(fila)
        End If

    End Sub

    Private Sub txtCantidad_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtCantidad.TextChanged
        Try

            txtTotal.Text = productoSelected.Precio * txtCantidad.Text

        Catch ex As Exception
            MessageBox.Show("Favor ingrese números")
            txtCantidad.Text = "0"
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardar.Click
        Dim winVendedor As winVendedor = Me.Owner.Owner
        Dim winFactura As WinFactura = Me.Owner
        'Dim dtDetalle = winFactura.DataContext
        dsDetalle = Me.DataContext
        'Using dbConexion As New OleDbConnection(dbPath)
        'Dim dsDetalle As New DataSet
        '    Dim dtDetalle As New DataTable("Detalle")
        '    dtDetalle.Columns.Add("IdProducto")
        '    dtDetalle.Columns.Add("IdFactura")
        '    dtDetalle.Columns.Add("Producto")
        '    dtDetalle.Columns.Add("Cantidad")
        '    dtDetalle.Columns.Add("Total")

        dsDetalle.Tables("Detalle").Rows.Add(productoSelected.Id, txtCantidad.Text, txtTotal.Text, winVendedor.NroFactura)

        winFactura.dtgDetalle.DataContext = dsDetalle
        Me.Owner.DataContext = dsDetalle
        MessageBox.Show(winVendedor.NroFactura)
        MessageBox.Show("Te sigo amando..")
        MessageBox.Show("Yo igual...")
        'End Using
    End Sub
End Class
