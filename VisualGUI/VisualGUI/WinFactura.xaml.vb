﻿Imports System.Data

Public Class WinFactura
    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Dim winVendedor As winVendedor = Me.Owner
        winVendedor.Show()
        Me.Close()
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As RoutedEventArgs) Handles btnDetalle.Click
        Dim winDetalle As New WinDetalle
        winDetalle.Owner = Me
        winDetalle.Show()
        Me.Hide()
    End Sub

    Private Sub btnAgregarCliente_Click(sender As Object, e As RoutedEventArgs) Handles btnAgregarCliente.Click
        Dim winCliente As New WinCliente
        winCliente.Owner = Me
        winCliente.Show()
        Me.Hide()

    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        txtCliente.Text = "Kimmy"
        txtFecha.Text = "24/08/2016"
        txtNmrFact.Text = "001"
        txtRuc.Text = "0987546855"
        txtVendedor.Text = Me.DataContext.Nombre
        Dim dsDetalle As New DataSet
        Dim dtDetalle As New DataTable("Detalle")


        dtDetalle.Columns.Add("Producto")
        dtDetalle.Columns.Add("Cantidad")
        dtDetalle.Columns.Add("Total")

        dtDetalle.Rows.Add("Bolsa", "5", "50")
        dtDetalle.Rows.Add("Cuaderno", "10", "1.20")
        dtDetalle.Rows.Add("Cepillo", "2", "1.50")
        dtDetalle.Rows.Add("Cartuchera", "1", "9.25")

        dsDetalle.Tables.Add(dtDetalle)
        dtgDetalle.DataContext = dsDetalle
        txtSubtotal.Text = "20.40"
        txtIva.Text = "12.25"
        txtTotal.Text = "32.65"
        txtDevolucion.Text = "5.10"
        txtTotalPagar.Text = "27.55"
    End Sub
End Class
