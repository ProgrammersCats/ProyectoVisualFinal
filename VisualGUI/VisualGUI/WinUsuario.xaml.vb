Public Class WinUsuario


    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Dim winAdmin As winAdmin = Me.Owner
        winAdmin.Show()
        Me.Close()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)


    End Sub
End Class
