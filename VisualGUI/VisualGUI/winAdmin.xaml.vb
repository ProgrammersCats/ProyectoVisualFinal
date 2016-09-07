Imports System.Data
Imports System.Data.OleDb

Public Class winAdmin
    Public path As String = "..\..\..\BDEmpresa.accdb"
    Public dbPath As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & path
    Private Sub winAdmin_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed, MyBase.Closed
        Me.Hide()
        Me.Owner.Show()
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
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

    Private Sub MenuItem_Click_1(sender As Object, e As RoutedEventArgs)


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

    Private Sub btnUsuarios_Click(sender As Object, e As RoutedEventArgs) Handles btnUsuarios.Click
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
    End Sub

    Private Sub btnProvinvias_Click(sender As Object, e As RoutedEventArgs) Handles btnProvinvias.Click
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
End Class
