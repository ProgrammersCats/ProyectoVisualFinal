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

        If (TypeOf Me.DataContext Is DataRowView) Then
            Dim fila As DataRowView = Me.DataContext
            txtProducto.Text = fila("Producto")
            txtPrecioUnitario.Text = fila("PrecioUnitario")
            txtCantidad.Text = fila("Cantidad")
            txtTotal.Text = fila("Total")

            'dtgProducto.SelectedIndex
        End If
    End Sub

    Private Sub dtgProducto_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dtgProducto.SelectionChanged
        Dim fila As DataRowView = sender.SelectedItem
        If (fila IsNot Nothing) Then
            txtProducto.Text = fila("Descripcion")
            txtPrecioUnitario.Text = fila("Precio")
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
        'Dim winVendedor As winVendedor = Me.Owner.Owner
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
        If TypeOf Me.DataContext Is DataRowView Then
            Dim fila As DataRowView = Me.DataContext
            Dim dsDetalle2 As DataSet = winFactura.dsDetalle
            For Each det As DataRow In dsDetalle2.Tables("Detalle").Rows
                If (det(0) = fila(0)) Then
                    det("Producto") = txtProducto.Text
                    det("PrecioUnitario") = txtPrecioUnitario.Text
                    det("Cantidad") = txtCantidad.Text
                    det("Total") = txtTotal.Text
                    Exit For
                End If
            Next

            winFactura.dtgDetalle.DataContext = dsDetalle2
            Me.Owner.DataContext = dsDetalle2
        Else
            dsDetalle.Tables("Detalle").Rows.Add(0, productoSelected.Descripcion, productoSelected.Precio, txtCantidad.Text, txtTotal.Text, winFactura.txtNmrFact.Text)

            winFactura.dtgDetalle.DataContext = dsDetalle
            Me.Owner.DataContext = dsDetalle
        End If

        MessageBox.Show("Se guardó el detalle, Cerrando ventana..")
        winFactura.Show()
        Me.Close()
        'End Using
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As RoutedEventArgs) Handles btnEliminar.Click
        Dim winFactura As WinFactura = Me.Owner
        Dim fila As DataRowView = Me.DataContext
        For Each det As DataRow In winFactura.dsDetalle.Tables("Detalle").Rows
            If (det(0) = fila(0)) Then
                det.Delete()
                Exit For
            End If
        Next
        winFactura.dtgDetalle.DataContext = dsDetalle
        Me.Owner.DataContext = dsDetalle
        MessageBox.Show("Se eliminó el detalle, Cerrando ventana..")
        winFactura.Show()
        Me.Close()

    End Sub
End Class
