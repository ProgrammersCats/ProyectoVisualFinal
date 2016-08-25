Imports System.Data

Class winLogeo
    Private Sub btnAceptar_Click(sender As Object, e As RoutedEventArgs) Handles btnAceptar.Click
        Dim path As String = "..\..\admin.xml"
        Dim flag As String = ""
        Dim dsUsuarios As New DataSet
        dsUsuarios.ReadXml(path)
        For Each fila As DataRow In dsUsuarios.Tables("Admin").Rows
            If (Me.txtUser.Text.Equals(fila(0)) AndAlso Me.txtPass.Password.Equals(fila(1))) Then
                flag = "a"

            End If
        Next
        For Each filaV As DataRow In dsUsuarios.Tables("Vendedor").Rows
            If (Me.txtUser.Text.Equals(filaV(0)) AndAlso Me.txtPass.Password.Equals(filaV(1))) Then
                flag = "v"

            End If
        Next
        If (flag.Equals("a")) Then

            Dim winAdmin As New winAdmin
            winAdmin.Owner = Me
            winAdmin.Show()
            Me.Hide()

        ElseIf (flag.Equals("v")) Then

            Dim winVendedor As New winVendedor
            winVendedor.Owner = Me
            winVendedor.Show()
            Me.Hide()
        Else
            MessageBox.Show("Usuario o contraseña incorrecta! TE AMO")
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As RoutedEventArgs) Handles btnCerrar.Click
        End
    End Sub
End Class
