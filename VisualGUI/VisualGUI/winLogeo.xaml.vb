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
                txtPrueba.Text = "Holi"
            End If
        Next
        For Each filaV As DataRow In dsUsuarios.Tables("Vendedor").Rows
            If (Me.txtUser.Text.Equals(filaV(0)) AndAlso Me.txtPass.Password.Equals(filaV(1))) Then
                flag = "v"
                txtPrueba.Text = "Holi2"
            End If
        Next
        If (flag.Equals("a")) Then
            txtPrueba.Text = "Holi3"
            Dim winAdmin As New winAdmin
            winAdmin.Owner = Me
            winAdmin.Show()
            Me.Hide()

        ElseIf (flag.Equals("v")) Then
            txtPrueba.Text = "Holi4"
            Dim winVendedor As New winVendedor
            winVendedor.Owner = Me
            winVendedor.Show()
            Me.Hide()
        Else
            MessageBox.Show("Usuario o contraseña incorrecta! TE AMO")
        End If
    End Sub
End Class
