Imports System.Data

Public Class winAdmin
    Dim path As String = "../../productos.xml"
    Private Sub winAdmin_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed, MyBase.Closed
        Me.Hide()
        Me.Owner.Show()
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)
        Dim dsProducto As New DataSet
        dsProducto.ReadXml(path)
        'Dim dtProd As DataTable = dsProducto.Tables("Item")
        dtgAdmin.DataContext = dsProducto


    End Sub

    Private Sub dtgAdmin_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dtgAdmin.SelectionChanged
        Dim fila As DataRowView = sender.SelectedItem
        If Not (fila Is Nothing) Then
            Dim prod As New Producto(fila(0), fila(1), fila(2), fila(3))
            Dim winProducto As New WinProducto
            winProducto.Owner = Me
            winProducto.DataContext = prod
            winProducto.Show()
            Me.Hide()

        End If

    End Sub
End Class
