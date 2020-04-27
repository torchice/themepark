Public Class GATE

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LOGIN.Show()
        Me.Hide()
        MAINMENU.flag = 4
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LOGIN.Show()
        Me.Hide()
        MAINMENU.flag = 3
    End Sub

    Private Sub GATE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TOTAL.Show()
    End Sub
End Class