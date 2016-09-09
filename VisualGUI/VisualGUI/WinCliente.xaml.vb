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
        Dim flag = False
        Using dbconexion As New OleDbConnection(dbPath)
            Dim sentencia As String = "Select * from Clientes"
            Dim dbAdapter As New OleDbDataAdapter(New OleDbCommand(sentencia, dbconexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(dbAdapter)
            Dim dsClientes As New DataSet
            dbAdapter.Fill(dsClientes, "Clientes")
            For Each fila As DataRow In dsClientes.Tables("Clientes").Rows
                If (fila(0) = txtId.Text) Then
                    'fila(0) = txtId.Text
                    fila(4) = txtNombre.Text
                    fila(1) = txtApellido.Text
                    fila(2) = txtDireccion.Text
                    fila(3) = txtTelefono.Text
                    fila(5) = txtRuc.Text
                    flag = True
                    Exit For
                End If
            Next
            If Not flag Then
                dsClientes.Tables("Clientes").Rows.Add(txtNombre.Text, txtApellido.Text, txtRuc.Text, txtDireccion.Text, txtTelefono.Text)
            End If
            Try
                dbAdapter.Update(dsClientes.Tables("Clientes"))
                MessageBox.Show("Guardado Exitoso")
            Catch ex As Exception
                MessageBox.Show("Guardado Falló")
            End Try

        End Using

        Me.Window_Closed(Nothing, Nothing)
    End Sub
End Class
