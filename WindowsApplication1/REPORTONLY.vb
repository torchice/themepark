Public Class REPORTONLY

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MAINMENU.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        report3.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'reportpengeluaran.Show()
        'report2.Show()
        report1.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' reportpengunjung.Show()
        report2.Show()


    End Sub

    Private Sub REPORTONLY_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class