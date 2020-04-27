Imports Oracle.DataAccess.Client
Public Class MAINMENU
    Public StringCon As String
    Public OraCon As OracleConnection

    Public flag As Integer = 0
    Private Sub btnMaster_Click(sender As Object, e As EventArgs) Handles Button3.Click
        flag = 0
        MAP.Show()
    End Sub

    Private Sub btnTransaksi_Click(sender As Object, e As EventArgs) Handles btnTransaksi.Click
        LOGIN.Show()
        flag = 2
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        flag = 0
        GATE.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        flag = 0
    End Sub

    Private Sub MAINMENU_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StringCon = "Data Source=XE; User Id=andy; Password=andy;"
        OraCon = New OracleConnection(StringCon)
        Try
            OraCon.Open()
            MessageBox.Show("Berhasil Log In Oracle")
        Catch ex As Exception
            Me.Close()
            MessageBox.Show("Gagal Log In")
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        TOTAL.Show()
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        LOGIN.Show()
        flag = 1
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        INSERT_SHOW.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        REPORTONLY.Show()

    End Sub
End Class