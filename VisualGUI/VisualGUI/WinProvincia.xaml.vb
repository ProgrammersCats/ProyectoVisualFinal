Imports System.Data
Imports System.Data.OleDb
Public Class WinProvincia

    Dim path As String = "..\..\..\BDEmpresa.accdb"
    Dim dbPath As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & path
    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Dim winAdmin As winAdmin = Me.Owner
        winAdmin.btnProvinvias_Click(Nothing, Nothing)
        winAdmin.Show()
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardar.Click
        Dim flag = False
        Using dbconexion As New OleDbConnection(dbPath)
            Dim sentencia As String = "Select * from Provincias"
            Dim dbAdapter As New OleDbDataAdapter(New OleDbCommand(sentencia, dbconexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(dbAdapter)
            Dim dsProvinvia As New DataSet
            dbAdapter.Fill(dsProvinvia, "Provincia")
            For Each fila As DataRow In dsProvinvia.Tables("Provincia").Rows
                If (fila(0) = txtId.Text) Then
                    fila(1) = txtNombre.Text
                    fila(2) = txtCapital.Text
                    fila(3) = txtIva.Text
                    flag = True
                    Exit For
                End If
            Next
            If Not flag Then
                dsProvinvia.Tables("Provincia").Rows.Add(txtId.Text, txtNombre.Text, txtCapital.Text, txtIva.Text)
            End If
            Try
                dbAdapter.Update(dsProvinvia.Tables("Provincia"))
                MessageBox.Show("Guardado Exitoso")
            Catch ex As Exception
                MessageBox.Show("Guardado Falló")
            End Try

        End Using
        Me.Window_Closed(Nothing, Nothing)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As RoutedEventArgs) Handles btnEliminar.Click
        Using dbconexion As New OleDbConnection(dbPath)
            Dim sentencia As String = "Select * from Provincias"
            Dim dbAdapter As New OleDbDataAdapter(New OleDbCommand(sentencia, dbconexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(dbAdapter)
            Dim dsProvinvia As New DataSet
            dbAdapter.Fill(dsProvinvia, "Provincia")
            For Each fila As DataRow In dsProvinvia.Tables("Provincia").Rows
                If (fila(0) = txtId.Text) Then
                    If MessageBox.Show("Seguro desea eliminar la provincia", "Eliminación",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) _
                     = MessageBoxResult.Yes Then
                        fila.Delete()
                        Try
                            dbAdapter.Update(dsProvinvia.Tables("Provincia"))
                            MessageBox.Show("Eliminación Exitosa")
                        Catch ex As Exception
                            MessageBox.Show("Eliminación Falló")
                        End Try
                    End If

                    Exit For
                End If
            Next
        End Using
        Me.Window_Closed(Nothing, Nothing)
    End Sub

    Private Sub Window_LocationChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        txtId.IsEnabled = False
    End Sub
End Class
