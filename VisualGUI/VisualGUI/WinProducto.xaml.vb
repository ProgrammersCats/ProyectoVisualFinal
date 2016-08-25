Public Class WinProducto
    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Dim winAdmin As winAdmin = Me.Owner
        winAdmin.Show()
        Me.Close()
    End Sub
End Class
