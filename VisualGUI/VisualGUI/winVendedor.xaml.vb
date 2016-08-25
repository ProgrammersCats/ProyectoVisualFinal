Imports System.Data

Public Class winVendedor
    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Me.Hide()
        Me.Owner.Show()
    End Sub

    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        Dim winFactura As New WinFactura
        winFactura.Owner = Me
        winFactura.Show()
        Me.Hide()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim dsFactura As New DataSet
        Dim dtFactura As New DataTable("Factura")
        dtFactura.Columns.Add("Id")
        dtFactura.Columns.Add("Fecha")
        dtFactura.Columns.Add("Vendedor")
        dtFactura.Columns.Add("Cliente")
        dtFactura.Columns.Add("Ruc")

        dtFactura.Rows.Add("001", "10/12/2016", "Ricardo", "Malu-chan", "0954854785")
        dtFactura.Rows.Add("002", "13/12/2016", "Paul", "Yander", "0954658955")
        dtFactura.Rows.Add("003", "14/11/2016", "Chibi", "Miguel", "0985485685")

        dsFactura.Tables.Add(dtFactura)
        dtgVendedor.DataContext = dsFactura
    End Sub
End Class
