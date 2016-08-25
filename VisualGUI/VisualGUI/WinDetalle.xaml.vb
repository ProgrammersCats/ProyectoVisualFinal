Public Class WinDetalle
    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Dim winFactura As WinFactura = Me.Owner
        winFactura.Show()
        Me.Close()

    End Sub
End Class
