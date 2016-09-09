Imports System.Data

Public Class WinDetalle
    Dim productoSelected As Producto
    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Dim winFactura As WinFactura = Me.Owner
        winFactura.Show()
        Me.Close()

    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim path As String = "../../productos.xml"
        Dim dsProducto As New DataSet
        dsProducto.ReadXml(path)
        dtgProducto.DataContext = dsProducto
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
        End Try
    End Sub
End Class
