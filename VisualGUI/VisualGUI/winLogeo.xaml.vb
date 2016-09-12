Imports System.Data
Imports System.Data.OleDb
Class winLogeo
    Private Sub btnAceptar_Click(sender As Object, e As RoutedEventArgs) Handles btnAceptar.Click
        Dim path As String = "..\..\..\BDEmpresa.accdb"
        Dim dbPath As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & path
        Dim flag As String = ""
        Using dbConexion As New OleDbConnection(dbPath)
            Dim sentencia As String = "Select * from Usuarios"
            Dim dbAdapter As New OleDbDataAdapter(New OleDbCommand(sentencia, dbConexion))
            Dim dsUsuarios As New DataSet
            dbAdapter.Fill(dsUsuarios, "Usuarios")
            Dim userLogeado As Usuario
            For Each fila As DataRow In dsUsuarios.Tables("Usuarios").Rows
                If (Me.txtUser.Text.Equals(fila(1)) AndAlso Me.txtPass.Password.Equals(fila(2))) Then
                    If fila("Rol") = "Admin" Then
                        flag = "a"
                        userLogeado = New Usuario(fila)
                    End If
                    If fila("Rol") = "Vendedor" Then
                        flag = "v"
                        userLogeado = New Usuario(fila)
                    End If
                    Exit For
                End If
            Next

            If (flag.Equals("a")) Then
                Dim winAdmin As New winAdmin
                winAdmin.Owner = Me
                winAdmin.DataContext = userLogeado
                winAdmin.Show()
                Me.Hide()
            ElseIf (flag.Equals("v")) Then
                Dim winVendedor As New winVendedor
                winVendedor.Owner = Me
                winVendedor.DataContext = userLogeado
                winVendedor.Show()
                Me.Hide()
            Else
                userLogeado = Nothing
                MessageBox.Show("Usuario o contraseña incorrecta! TE AMO")
            End If
        End Using
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As RoutedEventArgs) Handles btnCerrar.Click
        End
    End Sub
End Class
