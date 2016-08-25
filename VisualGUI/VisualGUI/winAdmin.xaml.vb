Public Class winAdmin
    Private Sub winAdmin_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed, MyBase.Closed
        Me.Hide()
        Me.Owner.Show()
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)

    End Sub
End Class
