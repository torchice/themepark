Imports Oracle.DataAccess.Client

Public Class PARKIR
    Public hasilcode As String = ""


    Private Sub PARKIR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TIKET.ShowParkirAvailable()
        TampilPakir()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'regkodeparkir.Show()
        FormInputParkir.Show()
    End Sub

    Private Sub Button86_Click(sender As Object, e As EventArgs) Handles Button86.Click
        Me.Hide()
        TIKET.Show()
    End Sub

    Private Sub Button85_Click(sender As Object, e As EventArgs) Handles Button85.Click
        FormInputParkir.Show()

    End Sub

End Class