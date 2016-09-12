Imports System.Data.OleDb
Imports System.Data
Public Class WinProducto
    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Dim winAdmin As winAdmin = Me.Owner
        winAdmin.MenuItem_Click_1(Nothing, Nothing)
        winAdmin.Show()
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardar.Click

        Try
            Dim flag = False
            Dim winAdmin As winAdmin = Me.Owner
            Using dbConexion As New OleDbConnection(winAdmin.dbPath)
                Dim sentencia As String = "Select * from Productos"
                Dim dbAdapter As New OleDbDataAdapter(New OleDbCommand(sentencia, dbConexion))
                Dim personaCmdBuilder As New OleDbCommandBuilder(dbAdapter)
                Dim dsProductos As New DataSet
                dbAdapter.Fill(dsProductos, "Productos")
                For Each fila As DataRow In dsProductos.Tables("Productos").Rows
                    If fila(0) = txtId.Text Then
                        fila("Descripcion") = txtDesc.Text
                        fila("Costo") = CDbl(txtCosto.Text)
                        fila("Precio") = CDbl(txtPrecio.Text)
                        flag = True
                        Exit For
                    End If
                Next

                If Not flag Then
                    dsProductos.Tables("Productos").Rows.Add(txtId.Text, txtDesc.Text, CDbl(txtCosto.Text), CDbl(txtPrecio.Text))
                End If

                Try
                    dbAdapter.Update(dsProductos.Tables("Productos"))
                    MessageBox.Show("Guardado Exitoso")

                Catch ex As Exception
                    MessageBox.Show("Guardado Falló")
                End Try
            End Using

            Me.Window_Closed(Nothing, Nothing)
        Catch ex As Exception
            MessageBox.Show("Escriba correctamente")
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As RoutedEventArgs) Handles btnEliminar.Click
        Dim flag = False
        Dim winAdmin As winAdmin = Me.Owner
        Using dbConexion As New OleDbConnection(winAdmin.dbPath)
            Dim sentencia As String = "Select * from Productos"
            Dim dbAdapter As New OleDbDataAdapter(New OleDbCommand(sentencia, dbConexion))
            Dim personaCmdBuilder As New OleDbCommandBuilder(dbAdapter)
            Dim dsProductos As New DataSet
            dbAdapter.Fill(dsProductos, "Productos")
            For Each fila As DataRow In dsProductos.Tables("Productos").Rows
                If fila(0) = txtId.Text Then
                    If MessageBox.Show("Seguro desea eliminar el producto", "Eliminación",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) _
                     = MessageBoxResult.Yes Then
                        fila.Delete()
                        Try
                            dbAdapter.Update(dsProductos.Tables("Productos"))
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

End Class
