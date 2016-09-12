Imports System.Data
Imports System.Data.OleDb

Public Class winVendedor
    Public path As String = "..\..\..\BDEmpresa.accdb"
    Public dbPath As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & path
    Public NroFactura As Integer
    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Me.Hide()
        Me.Owner.Show()
    End Sub

    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        Dim winFactura As New WinFactura
        winFactura.Owner = Me
        winFactura.DataContext = Me.DataContext
        winFactura.Show()
        Me.Hide()
    End Sub

    Public Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim dsFactura As New DataSet
        Using dbConexion As New OleDbConnection(dbPath)
            Dim sentencia As String = "Select * from Facturas"
            Dim dbAdapter As New OleDbDataAdapter(New OleDbCommand(sentencia, dbConexion))
            dbAdapter.Fill(dsFactura, "Factura")
            dtgVendedor.DataContext = dsFactura
            If dsFactura.Tables("Factura").Rows.Count = 0 Then
                NroFactura = 1
            Else

                NroFactura = dsFactura.Tables("Factura").Rows(dsFactura.Tables("Factura").Rows.Count - 1)("Id") + 1
            End If

        End Using
    End Sub

    Private Sub dtgVendedor_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dtgVendedor.SelectionChanged
        Dim fila As DataRowView = sender.SelectedItem
        If Not (fila Is Nothing) Then
            Dim winFactura As New WinFactura
            winFactura.Owner = Me
            winFactura.DataContext = fila
            winFactura.Show()
            Me.Hide()
        End If
    End Sub
End Class
