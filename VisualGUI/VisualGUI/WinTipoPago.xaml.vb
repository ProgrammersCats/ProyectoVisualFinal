Imports System.Data
Imports System.Data.OleDb
Public Class WinTipoPago


    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Dim winAdmin As winAdmin = Me.Owner
        winAdmin.Show()
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardar.Click
        Dim winAdmin As winAdmin = Me.Owner
        Dim flag = False
        Using dbConexion As New OleDbConnection(winAdmin.dbPath)
            Dim sentencia As String = "Select * from Pagos"
            Dim dbAdapter As New OleDbDataAdapter(New OleDbCommand(sentencia, dbConexion))
            Dim personaCmdBuilder As New OleDbCommandBuilder(dbAdapter)
            Dim dsPagos As New DataSet
            dbAdapter.Fill(dsPagos, "Pagos")
            For Each fila As DataRow In dsPagos.Tables("Pagos").Rows
                If (fila(0) = txtId.Text) Then
                    fila(1) = txtTipo.Text
                    fila(2) = txtValor.Text
                    flag = True
                    Exit For
                End If
            Next
            Try
                dbAdapter.Update(dsPagos.Tables("Pagos"))
                MessageBox.Show("Guardado Exitoso")
            Catch ex As Exception
                MessageBox.Show("Guardado falló")
            End Try
        End Using
        Me.Window_Closed(Nothing, Nothing)
    End Sub
End Class
