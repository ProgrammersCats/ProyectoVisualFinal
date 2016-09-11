Imports System.Data
Imports System.Data.OleDb

Public Class winAdmin
    Public path As String = "..\..\..\BDEmpresa.accdb"
    Public dbPath As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & path
    Private Sub winAdmin_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed, MyBase.Closed
        Me.Hide()
        Me.Owner.Show()
    End Sub

    Public Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
        Using dbConexion As New OleDbConnection(dbPath)
            Dim sentencia As String = "Select * from Pagos"
            Dim dbAdapter As New OleDbDataAdapter(New OleDbCommand(sentencia, dbConexion))
            Dim dsPagos As New DataSet
            dbAdapter.Fill(dsPagos, "Pagos")

            dtgPagos.DataContext = dsPagos
            ocultarDtg()
            dtgPagos.Visibility = Visibility.Visible
        End Using
    End Sub

    Public Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)


        Using dbConexion As New OleDbConnection(dbPath)
            Dim sentencia As String = "Select * from Productos"
            Dim dbAdapter As New OleDbDataAdapter(New OleDbCommand(sentencia, dbConexion))
            Dim dsProducto As New DataSet
            dbAdapter.Fill(dsProducto, "Productos")

            dtgProductos.DataContext = dsProducto
            ocultarDtg()
            dtgProductos.Visibility = Visibility.Visible
        End Using




    End Sub

    Private Sub dtgProductos_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dtgProductos.SelectionChanged
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

    Private Sub winAdmin_Loaded(sender As Object, e As RoutedEventArgs) Handles MyBase.Loaded, MyBase.Loaded
        ocultarDtg()
    End Sub

    Public Sub btnUsuarios_Click(sender As Object, e As RoutedEventArgs) Handles btnUsuarios.Click
        Using dbConexion As New OleDbConnection(dbPath)
            Dim sentencia As String = "Select * from Usuarios"
            Dim dbAdapter As New OleDbDataAdapter(New OleDbCommand(sentencia, dbConexion))
            Dim dsUsuario As New DataSet
            dbAdapter.Fill(dsUsuario, "Usuarios")

            dtgUsuarios.DataContext = dsUsuario
            ocultarDtg()
            dtgUsuarios.Visibility = Visibility.Visible

        End Using

    End Sub
    Sub ocultarDtg()
        dtgProvincias.Visibility = Visibility.Hidden
        dtgPagos.Visibility = Visibility.Hidden
        dtgUsuarios.Visibility = Visibility.Hidden
        dtgProductos.Visibility = Visibility.Hidden
        dtgFacturas.Visibility = Visibility.Hidden
    End Sub

    Public Sub btnProvinvias_Click(sender As Object, e As RoutedEventArgs) Handles btnProvinvias.Click
        Using dbConexion As New OleDbConnection(dbPath)
            Dim sentencia As String = "Select * from Provincias"
            Dim dbAdapter As New OleDbDataAdapter(New OleDbCommand(sentencia, dbConexion))
            Dim dsProvincias As New DataSet
            dbAdapter.Fill(dsProvincias, "Provincias")

            dtgProvincias.DataContext = dsProvincias
            ocultarDtg()
            dtgProvincias.Visibility = Visibility.Visible

        End Using

    End Sub

    Private Sub dtgUsuarios_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dtgUsuarios.SelectionChanged
        Dim fila As DataRowView = sender.SelectedItem
        If Not (fila Is Nothing) Then
            Dim usuario As New Usuario(fila(0), fila(1), fila(2), fila(3), fila(4), fila(5), fila(6), fila(7))
            Dim winUsuario As New WinUsuario
            winUsuario.Owner = Me
            winUsuario.DataContext = usuario
            winUsuario.Show()
            Me.Hide()

        End If
    End Sub

    Private Sub dtgProvincias_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dtgProvincias.SelectionChanged

        Dim fila As DataRowView = sender.SelectedItem
            If Not (fila Is Nothing) Then
                Dim provincia As New Provincia(fila(0), fila(1), fila(2), fila(3))
                Dim winProvincia As New WinProvincia
                winProvincia.Owner = Me
                winProvincia.DataContext = provincia
                winProvincia.Show()
                Me.Hide()

            End If

    End Sub

    Private Sub dtgPagos_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dtgPagos.SelectionChanged
        Dim fila As DataRowView = sender.SelectedItem
        If Not (fila Is Nothing) Then
            Dim pagos As New Pagos(fila(0), fila(1), fila(2))
            Dim winPagos As New WinTipoPago
            winPagos.Owner = Me
            winPagos.DataContext = pagos
            winPagos.Show()
            Me.Hide()

        End If
    End Sub

    Private Sub btnFacturas_Click(sender As Object, e As RoutedEventArgs) Handles btnFacturas.Click
        Using dbConexion As New OleDbConnection(dbPath)
            Dim sentencia As String = "Select * from Facturas"
            Dim dbAdapter As New OleDbDataAdapter(New OleDbCommand(sentencia, dbConexion))
            Dim dsFacturas As New DataSet
            dbAdapter.Fill(dsFacturas, "Facturas")

            dtgFacturas.DataContext = dsFacturas
            ocultarDtg()
            dtgFacturas.Visibility = Visibility.Visible

        End Using
    End Sub

    Private Sub dtgFacturas_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dtgFacturas.SelectionChanged
        Dim fila As DataRowView = sender.SelectedItem
        Dim cliente As Cliente
        Dim vendedor As Usuario
        Dim provincia As Provincia
        Dim pagos As Pagos

        If Not (fila Is Nothing) Then
            Using dbConexion As New OleDbConnection(dbPath)
                'CLIENTE
                Dim sentenciaC As String = "Select * from Clientes"
                Dim dbAdapter As New OleDbDataAdapter(sentenciaC, dbConexion)
                Dim dsCliente As New DataSet
                dbAdapter.Fill(dsCliente, "Cliente")
                For Each cli As DataRow In dsCliente.Tables("Cliente").Rows
                    If (cli(0) = fila(0)) Then
                        cliente = New Cliente(cli(0), cli("Nombre"), cli("Apellido"), cli("Direccion"), cli("Telefono"), cli("Ruc"))
                    End If

                Next
                'VENDEDOR
                Dim sentenciaU As String = "Select * from Usuarios where Rol='Vendedor'"
                Dim dbAdapterU As New OleDbDataAdapter(sentenciaU, dbConexion)
                Dim dsVendedor As New DataSet
                dbAdapterU.Fill(dsVendedor, "Vendedor")
                For Each ven As DataRow In dsVendedor.Tables("Vendedor").Rows
                    If (ven(0) = fila(0)) Then
                        vendedor = New Usuario(ven(0), ven("Usuario"), ven("Contraseña"), ven("Nombre"), ven("Apellido"), ven("Telefono"), ven("Direccion"), ven("Rol"))
                    End If

                Next
                'PROVINCIA
                Dim sentenciaP As String = "Select * from Provincias"
                Dim dbAdapterP As New OleDbDataAdapter(sentenciaP, dbConexion)
                Dim dsProvincia As New DataSet
                dbAdapterP.Fill(dsProvincia, "Provincia")
                For Each pro As DataRow In dsProvincia.Tables("Provincia").Rows
                    If (pro(0) = fila(0)) Then
                        provincia = New Provincia(pro(0), pro("Nombre"), pro("Capital"), pro("iva"))
                    End If

                Next
                'PAGOS
                Dim sentenciaPa As String = "Select * from Pagos"
                Dim dbAdapterPa As New OleDbDataAdapter(sentenciaPa, dbConexion)
                Dim dsPagos As New DataSet
                dbAdapterPa.Fill(dsPagos, "Pagos")
                For Each pago As DataRow In dsPagos.Tables("Pagos").Rows
                    If (pago(0) = fila(0)) Then
                        pagos = New Pagos(pago(0), pago("Tipo"), pago("Cantidad"))
                    End If

                Next
            End Using

            Dim factura As New Factura(fila(0), fila("Fecha"), cliente, vendedor, provincia, pagos)
            Dim winFactura As New WinFactura
            winFactura.Owner = Me
            winFactura.DataContext = factura
            winFactura.Show()
            Me.Hide()

        End If
    End Sub
End Class
