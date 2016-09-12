Imports System.Data
Imports System.Data.OleDb

Public Class WinCliente
    Public path As String = "..\..\..\BDEmpresa.accdb"
    Public dbPath As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & path
    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Dim winFactura As WinFactura = Me.Owner
        winFactura.Window_Loaded(Nothing, Nothing)
        winFactura.Show()
        Me.Close()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As RoutedEventArgs) Handles BtnGuardar.Click
        Try


            Dim flag = False
            Using dbconexion As New OleDbConnection(dbPath)
                Dim sentencia As String = "Select * from Clientes"
                Dim dbAdapter As New OleDbDataAdapter(New OleDbCommand(sentencia, dbconexion))
                Dim personaCmdBuilder = New OleDbCommandBuilder(dbAdapter)
                Dim dsClientes As New DataSet
                dbAdapter.Fill(dsClientes, "Clientes")

                For Each fila As DataRow In dsClientes.Tables("Clientes").Rows
                    If (fila(0) = txtId.Text) Then
                        fila("Nombre") = txtNombre.Text
                        fila("Apellido") = txtApellido.Text
                        fila("Direccion") = txtDireccion.Text
                        fila("Telefono") = txtTelefono.Text
                        fila("Ruc") = txtRuc.Text
                        flag = True
                        Exit For
                    End If
                Next
                If Not flag Then
                    dsClientes.Tables("Clientes").Rows.Add(txtId.Text, txtApellido.Text, txtDireccion.Text, txtTelefono.Text, txtNombre.Text, txtRuc.Text)
                End If
                Try
                    dbAdapter.Update(dsClientes.Tables("Clientes"))
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

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        If TypeOf Me.DataContext Is Integer Then
            txtId.Text = Me.DataContext
            txtId.IsEnabled = False
        End If
    End Sub
End Class
