Public Class PENGUNJUNG
    Private Sub btnMember_Click(sender As Object, e As EventArgs) Handles btnMember.Click
        TIKET.Show()
        Me.Hide()
        TIKET.lbCust.Text = "ID MEMBER : "
    End Sub

    Private Sub btnCust_Click(sender As Object, e As EventArgs) Handles btnCust.Click
        TIKET.Show()
        Me.Hide()
        TIKET.lbCust.Text = "NAMA PENGUNJUNG : "
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        MAINMENU.Show()

    End Sub

    Private Sub PENGUNJUNG_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class