Imports Oracle.DataAccess.Client
Public Class ID_WAHANA

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MAINMENU.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim id_wahana As String = TextBox1.Text.ToUpper

        If (id_wahana <> "") Then
            Dim cekLogin As String = "select count(id_wahana) FROM WAHANA where id_wahana = '" + id_wahana + "'"
            Dim cmdcekLogin As OracleCommand = New OracleCommand
            cmdcekLogin.CommandText = cekLogin
            cmdcekLogin.Connection = LOGIN.OraCon
            Dim cek As Integer = cmdcekLogin.ExecuteScalar()

            If (cek <> 0) Then
                MessageBox.Show("Login Wahana " + id_wahana)
                CHECKIN_WAHANA.Show()
                Me.Hide()
            Else
                MessageBox.Show("ID Wahana tidak ditemukan")
            End If

            CHECKIN_WAHANA.Label3.Text = id_wahana
        Else
            MessageBox.Show("ID Wahana belum diisi!")
        End If

    End Sub

    Private Sub ID_WAHANA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class