Imports System.Data
Imports System.Data.OleDb
Public Class WinUsuario


    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Dim winAdmin As winAdmin = Me.Owner
        winAdmin.btnUsuarios_Click(Nothing, Nothing)
        winAdmin.Show()
        Me.Close()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)


    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardar.Click
        Dim flag = False
        Dim winAdmin As winAdmin = Me.Owner
        Using dbConexion As New OleDbConnection(winAdmin.dbPath)
            Dim sentencia As String = "Select * from Usuarios"
            Dim dbAdapter As New OleDbDataAdapter(New OleDbCommand(sentencia, dbConexion))
            Dim personaCmdBuilder As New OleDbCommandBuilder(dbAdapter)
            Dim dsUsuarios As New DataSet
            dbAdapter.Fill(dsUsuarios, "Usuarios")
            For Each fila As DataRow In dsUsuarios.Tables("Usuarios").Rows
                If (fila(0) = txtId.Text) Then
                    fila("Usuario") = txtUser.Text
                    fila("Contraseña") = txtPass.Text
                    fila("Nombre") = txtNombre.Text
                    fila("Apellido") = txtApellido.Text
                    fila("Telefono") = txtTelefono.Text
                    fila("Direccion") = txtDireccion.Text
                    fila("Rol") = txtRol.Text
                    flag = True
                    Exit For
                End If
            Next
            If (Not flag) Then
                dsUsuarios.Tables("Usuarios").Rows.Add(txtId.Text, txtUser.Text, txtPass.Text, txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtDireccion.Text, txtRol.Text)
            End If
            Try
                dbAdapter.Update(dsUsuarios.Tables("Usuarios"))
                MessageBox.Show("Guardado Exitoso")
            Catch ex As Exception
                MessageBox.Show("Guardado Falló")
            End Try
        End Using
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As RoutedEventArgs) Handles btnEliminar.Click
        Dim flag = False
        Dim winAdmin As winAdmin = Me.Owner
        Using dbConexion As New OleDbConnection(winAdmin.dbPath)
            Dim sentencia As String = "Select * from Usuarios"
            Dim dbAdapter As New OleDbDataAdapter(New OleDbCommand(sentencia, dbConexion))
            Dim personaCmdBuilder As New OleDbCommandBuilder(dbAdapter)
            Dim dsUsuarios As New DataSet
            dbAdapter.Fill(dsUsuarios, "Usuarios")
            For Each fila As DataRow In dsUsuarios.Tables("Usuarios").Rows
                If (fila(0) = txtId.Text) Then
                    If MessageBox.Show("Seguro desea eliminar el usuario", "Eliminación",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) _
                     = MessageBoxResult.Yes Then
                        fila.Delete()
                        Try
                            dbAdapter.Update(dsUsuarios.Tables("Usuarios"))
                            MessageBox.Show("Eliminación Exitosa")
                        Catch ex As Exception
                            MessageBox.Show("Eliminación Falló")
                        End Try
                    End If
                    Exit For
                End If
            Next

        End Using
    End Sub
End Class
