Public Class winVendedor
    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Me.Hide()
        Me.Owner.Show()
    End Sub

    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        Dim winFactura As New WinFactura
        winFactura.Owner = Me
        winFactura.Show()
        Me.Hide()
    End Sub
End Class
