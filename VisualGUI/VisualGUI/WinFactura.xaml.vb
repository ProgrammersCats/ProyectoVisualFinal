﻿Imports System.Data
Imports System.Data.OleDb

Public Class WinFactura
    Dim path As String = "..\..\..\BDEmpresa.accdb"
    Dim dbPath As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & path
    'Dim winVendedor As winVendedor = Me.Owner
    Dim dsDetalle As DataSet
    Dim dsComboBox As DataSet
    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Dim winVendedor As winVendedor = Me.Owner
        winVendedor.Show()
        Me.Close()
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As RoutedEventArgs) Handles btnDetalle.Click
        Dim winDetalle As New WinDetalle
        winDetalle.Owner = Me
        winDetalle.DataContext = dsDetalle
        winDetalle.Show()
        Me.Hide()
    End Sub

    Private Sub btnAgregarCliente_Click(sender As Object, e As RoutedEventArgs) Handles btnAgregarCliente.Click
        Dim winCliente As New WinCliente
        winCliente.Owner = Me
        winCliente.Show()
        Me.Hide()

    End Sub

    Public Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim winVendedor As winVendedor = Me.Owner
        'txtCliente.Text = "Kimmy"
        txtFecha.Text = DateAndTime.Today
        txtNmrFact.Text = winVendedor.NroFactura
        'txtRuc.Text = "0987546855"
        txtVendedor.Text = Me.DataContext.Nombre

        dsDetalle = New DataSet()
        Dim dtDetalle As New DataTable("Detalle")
        dtDetalle.Columns.Add("Id")
        dtDetalle.Columns.Add("Cantidad")
        dtDetalle.Columns.Add("Total")
        dtDetalle.Columns.Add("idFactura")
        dsDetalle.Tables.Add(dtDetalle)
        dtgDetalle.DataContext = dsDetalle

        Using dbConexion As New OleDbConnection(dbPath)
            Dim consulta As String = "Select * From Provincias"
            Dim consulta2 As String = "Select * From Pagos"
            Dim consulta3 As String = "Select * From Clientes"
            Dim dbAdapter As New OleDbDataAdapter(New OleDbCommand(consulta, dbConexion))
            Dim dbAdapter2 As New OleDbDataAdapter(New OleDbCommand(consulta2, dbConexion))
            Dim dbAdapter3 As New OleDbDataAdapter(New OleDbCommand(consulta3, dbConexion))
            dsComboBox = New DataSet("ComboBoxes")
            dbAdapter.Fill(dsComboBox, "Provincias")
            dbAdapter2.Fill(dsComboBox, "Pagos")
            dbAdapter3.Fill(dsComboBox, "Clientes")
            cmbNombre.Items.Clear()
            cmbProvincia.Items.Clear()
            cmbProvincia.Items.Clear()

            For Each cat As DataRow In dsComboBox.Tables("Provincias").Rows
                cmbProvincia.Items.Add(cat(1))
            Next
            For Each cat As DataRow In dsComboBox.Tables("Pagos").Rows
                cmbTipoPago.Items.Add(cat(1))
            Next
            For Each cat As DataRow In dsComboBox.Tables("Clientes").Rows
                cmbNombre.Items.Add(cat(4))
            Next
        End Using


        'dsDetalle = Me.DataContext
        'dtgDetalle.DataContext = dsDetalle


        'dtDetalle.Columns.Add("Producto")
        'dtDetalle.Columns.Add("Cantidad")
        'dtDetalle.Columns.Add("Total")

        'dtDetalle.Rows.Add("Bolsa", "5", "50")

        'dtDetalle.Rows.Add("Cepillo", "2", "1.50")
        'dtDetalle.Rows.Add("Cartuchera", "1", "9.25")


        'dtgDetalle.DataContext = dsDetalle
        'txtSubtotal.Text = "20.40"
        'txtIva.Text = "12.25"
        'txtTotal.Text = "32.65"
        'txtDevolucion.Text = "5.10"
        'txtTotalPagar.Text = "27.55"
    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As RoutedEventArgs) Handles btnCalcular.Click
        Dim factura As New Factura
        Dim cliente As Cliente
        Dim provincia As Provincia
        Dim tipoDePago As Pagos

        Try
            For Each fila As DataRow In dsComboBox.Tables("Clientes").Rows
                If cmbNombre.SelectedValue = fila(4) Then
                    cliente = New Cliente(fila)
                    factura.Cliente = cliente
                    MessageBox.Show("lleno Cliente")
                    Exit For
                End If
            Next
            For Each fila As DataRow In dsComboBox.Tables("Provincias").Rows
                If cmbProvincia.SelectedValue = fila("Nombre") Then
                    provincia = New Provincia(fila)
                    factura.LugarEmision = provincia
                    MessageBox.Show("lleno Provincia")
                    Exit For
                End If
            Next
            For Each fila As DataRow In dsComboBox.Tables("Pagos").Rows
                If cmbTipoPago.SelectedValue = fila(1) Then
                    tipoDePago = New Pagos(fila)
                    factura.TipoPago = tipoDePago
                    MessageBox.Show("lleno Tipo de Pago")
                    Exit For
                End If
            Next
            For Each fila As DataRow In dsDetalle.Tables("Detalle").Rows
                'factura.Detalles.Add(New DetalleFactura(fila))
                Dim detalle As New DetalleFactura(fila)
                factura.agregarDetalle(detalle)
            Next
            For Each detalle As DetalleFactura In factura.Detalles
                MessageBox.Show(detalle.Item.Precio)

            Next

            txtSubtotal.Text = factura.Subtotal
            txtIva.Text = factura.IVA
            txtTotal.Text = factura.Total
            txtDevolucion.Text = factura.Devolucion
            txtTotalPagar.Text = factura.TotalPagar
        Catch ex As Exception
            MessageBox.Show("Llene todos lo campos")
        End Try
    End Sub
End Class
