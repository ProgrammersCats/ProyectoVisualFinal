Imports System.Data
Imports System.Data.OleDb

Public Class WinFactura
    Dim path As String = "..\..\..\BDEmpresa.accdb"
    Dim dbPath As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & path
    'Dim winVendedor As winVendedor = Me.Owner
    Public dsDetalle As DataSet
    Dim dsComboBox As DataSet
    Dim dsFactura As DataSet
    Dim factura As New Factura
    Private Sub Window_Closed(sender As Object, e As EventArgs)
        If TypeOf Me.Owner Is winAdmin Then
            Dim winAdmin As winAdmin = Me.Owner
            winAdmin.Show()
        ElseIf (TypeOf Me.Owner Is winVendedor) Then

            Dim winVendedor As winVendedor = Me.Owner
            winVendedor.Window_Loaded(Nothing, Nothing)
            winVendedor.Show()

        End If
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




        If (TypeOf Me.Owner Is winAdmin) OrElse (TypeOf Me.DataContext Is DataRowView) Then
            Dim fila As DataRowView = Me.DataContext

            txtNmrFact.Text = fila(0)
            txtFecha.Text = fila("Fecha")
            txtVendedor.Text = fila("Vendedor")
            cmbNombre.Items.Add(fila("Cliente"))
            cmbProvincia.Items.Add(fila("LugarEmision"))
            cmbTipoPago.Items.Add(fila("TipoPago"))
            cmbNombre.SelectedIndex = 0
            cmbProvincia.SelectedIndex = 0
            cmbTipoPago.SelectedIndex = 0

            txtRuc.Text = fila("Ruc")
            txtSubtotal.Text = fila("Subtotal")
            txtIva.Text = fila("Iva")
            txtTotal.Text = fila("Total")
            txtDevolucion.Text = fila("Devolucion")
            txtTotalPagar.Text = fila("TotalPagar")

            'Dim factura As Factura = Me.DataContext
            'txtNmrFact.Text = factura.NumeroFactura
            'txtFecha.Text = factura.Fecha
            'txtVendedor.Text = factura.Vendedor.Nombre
            'cmbNombre.Items.Add(factura.Cliente.Nombre)
            'cmbProvincia.Items.Add(factura.LugarEmision.Nombre)
            'cmbTipoPago.Items.Add(factura.TipoPago.Tipo)
            'cmbNombre.SelectedIndex = 0
            'cmbProvincia.SelectedIndex = 0
            'cmbTipoPago.SelectedIndex = 0

            'txtRuc.Text = factura.Cliente.Ruc
            'txtSubtotal.Text = factura.Subtotal
            'txtIva.Text = factura.IVA
            'txtTotal.Text = factura.Total
            'txtDevolucion.Text = factura.Devolucion
            'txtTotalPagar.Text = factura.TotalPagar


            txtNmrFact.IsEnabled = False
            txtFecha.IsEnabled = False
            txtVendedor.IsEnabled = False
            cmbNombre.IsEnabled = False
            txtRuc.IsEnabled = False
            txtSubtotal.IsEnabled = False
            txtIva.IsEnabled = False
            txtTotal.IsEnabled = False
            txtDevolucion.IsEnabled = False
            txtTotalPagar.IsEnabled = False
            btnAgregarCliente.IsEnabled = False
            btnCalcular.IsEnabled = False
            btnDetalle.IsEnabled = False

            btnGuardar.IsEnabled = False
            cmbProvincia.IsEnabled = False
            cmbTipoPago.IsEnabled = False

        ElseIf (TypeOf Me.Owner Is winVendedor) Then
            Dim winVendedor As winVendedor = Me.Owner
                Dim usuarioLogeado = Me.DataContext
                'txtCliente.Text = "Kimmy"
                txtFecha.Text = DateAndTime.Today
                txtNmrFact.Text = winVendedor.NroFactura
                'txtRuc.Text = "0987546855"
                txtVendedor.Text = Me.DataContext.Nombre
                factura.Vendedor = usuarioLogeado
                'factura.Vendedor = Me.DataContext

                dsDetalle = New DataSet()
                Dim dtDetalle As New DataTable("Detalle")
            dtDetalle.Columns.Add("Id")
            dtDetalle.Columns.Add("Producto")
            dtDetalle.Columns.Add("PrecioUnitario")
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
            btnGuardar.IsEnabled = False
        End If

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

        Dim cliente As Cliente
        Dim provincia As Provincia
        Dim tipoDePago As Pagos

        Try

            For Each fila As DataRow In dsComboBox.Tables("Clientes").Rows
                If cmbNombre.SelectedValue = fila(4) Then
                    cliente = New Cliente(fila)
                    factura.Cliente = cliente
                    'MessageBox.Show("lleno Cliente")
                    Exit For
                End If
            Next
            For Each fila As DataRow In dsComboBox.Tables("Provincias").Rows
                If cmbProvincia.SelectedValue = fila("Nombre") Then
                    provincia = New Provincia(fila)
                    factura.LugarEmision = provincia
                    ' MessageBox.Show("lleno Provincia")
                    Exit For
                End If
            Next
            For Each fila As DataRow In dsComboBox.Tables("Pagos").Rows
                If cmbTipoPago.SelectedValue = fila(1) Then
                    tipoDePago = New Pagos(fila)
                    factura.TipoPago = tipoDePago
                    'MessageBox.Show("lleno Tipo de Pago")
                    Exit For
                End If
            Next
            factura.limpiarDetalle()
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
            btnGuardar.IsEnabled = True
        Catch ex As Exception
        MessageBox.Show("Llene todos lo campos")
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardar.Click
        Using dbConexion As New OleDbConnection(dbPath)
            Dim flag As Boolean = False
            Dim dbConsulta As String = "Select * from Facturas"
            Dim dbAdapter As New OleDbDataAdapter(New OleDbCommand(dbConsulta, dbConexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(dbAdapter)
            dsFactura = New DataSet
            dbAdapter.Fill(dsFactura, "Facturas")
            For Each fila As DataRow In dsFactura.Tables("Facturas").Rows
                If fila(0) = txtNmrFact.Text Then
                    fila("Fecha") = txtFecha.Text
                    fila("Cliente") = CDbl(factura.Cliente.Id)
                    fila("idVendedor") = CDbl(factura.Vendedor.Id)
                    fila("Subtotal") = CDbl(txtSubtotal.Text)
                    fila("Iva") = CDbl(txtIva.Text)
                    fila("Total") = CDbl(txtTotal.Text)
                    fila("Devolucion") = CDbl(txtDevolucion.Text)
                    fila("TotalPagar") = CDbl(txtTotalPagar.Text)
                    flag = True
                    'MessageBox.Show("coincidencia")
                    Exit For
                End If
            Next
            Try
                If Not flag Then
                    dsFactura.Tables("Facturas").Rows.Add(txtNmrFact.Text, txtFecha.Text, factura.Cliente.Nombre, factura.Cliente.Ruc, factura.Vendedor.Nombre, factura.LugarEmision.Nombre, factura.TipoPago.Tipo, CDbl(txtSubtotal.Text), CDbl(txtIva.Text), CDbl(txtTotal.Text), CDbl(txtDevolucion.Text), CDbl(txtTotalPagar.Text))
                    MessageBox.Show("asfaqweqe")
                End If
            Catch ex As Exception
                MessageBox.Show("Llene todos los campos")
            End Try

            'MessageBox.Show(txtNmrFact.Text)
            'MessageBox.Show(txtFecha.Text)
            'MessageBox.Show(factura.Cliente.Id)
            'MessageBox.Show(factura.Cliente.Id)
            'MessageBox.Show(txtSubtotal.Text)
            'MessageBox.Show(txtIva.Text)
            'MessageBox.Show(txtTotal.Text)
            'MessageBox.Show(txtDevolucion.Text)
            'MessageBox.Show(txtTotalPagar.Text)
            'MessageBox.Show(flag)
            'dbAdapter.Update(dsFactura.Tables("Facturas"))
            Try
                dbAdapter.Update(dsFactura.Tables("Facturas"))
                MessageBox.Show("Guardado Exitoso")

                Me.Window_Closed(Nothing, Nothing)


            Catch ex As Exception
                MessageBox.Show("Guardado Falló")
            End Try
        End Using
    End Sub

    Private Sub dtgDetalle_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dtgDetalle.SelectionChanged
        Dim fila As DataRowView = sender.SelectedItem
        If fila IsNot Nothing Then
            Dim winDetalle As New WinDetalle
            winDetalle.Owner = Me

            winDetalle.DataContext = fila
            winDetalle.Show()
            Me.Hide()

        End If
    End Sub

    Private Sub cmbNombre_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cmbNombre.SelectionChanged
        Using dbconexion As New OleDbConnection(dbPath)
            Dim sentencia As String = "Select * from Clientes"
            Dim dbAdapter As New OleDbDataAdapter(sentencia, dbconexion)
            Dim dsCliente As New DataSet
            dbAdapter.Fill(dsCliente, "Cliente")
            For Each cli As DataRow In dsCliente.Tables("Cliente").Rows
                If (cli("Nombre").Equals(cmbNombre.SelectedValue)) Then
                    txtRuc.Text = cli("Ruc")
                End If
            Next
        End Using
    End Sub
End Class
