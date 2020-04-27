Imports Oracle.DataAccess.Client
Public Class LOGIN
    Public StringCon As String
    Public OraCon As OracleConnection
    Public DS3 As DataSet
    Public index As Int16
    Dim pilih_hmatch As Integer
    Private Sub MENU_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        MAINMENU.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (MAINMENU.flag = 1) Then
            If (TextBox1.Text.ToUpper = "ADMIN") And TextBox2.Text.ToUpper = "123" Then
                MessageBox.Show("Selamat Datang Admin!")
                MASTER.Show()
            End If
        ElseIf (MAINMENU.flag = 2) Then
            Dim id_peg As String = TextBox1.Text.ToUpper

            Dim cekLogin As String = "select count(id_pegawai) from pegawai where id_pegawai = '" + id_peg + "' AND ID_JABATAN LIKE '%PT%'"
            Dim cmdcekLogin As OracleCommand = New OracleCommand
            cmdcekLogin.CommandText = cekLogin
            cmdcekLogin.Connection = Me.OraCon
            Dim cek As Integer = cmdcekLogin.ExecuteScalar()

            If (cek <> 0) Then
                If (id_peg = TextBox2.Text.ToUpper) Then
                    MessageBox.Show("Pegawai Tiket berhasil masuk")
                    PENGUNJUNG.Show()
                Else
                    MessageBox.Show("Password salah")
                End If
            Else
                MessageBox.Show("ID Pegawai Tiket tidak ditemukan")
            End If

        ElseIf (MAINMENU.flag = 3) Then
            Dim id_peg As String = TextBox1.Text.ToUpper

            Dim cekLogin As String = "select count(id_pegawai) from pegawai where id_pegawai = '" + id_peg + "' AND ID_JABATAN LIKE '%PW%'"
            Dim cmdcekLogin As OracleCommand = New OracleCommand
            cmdcekLogin.CommandText = cekLogin
            cmdcekLogin.Connection = OraCon
            Dim cek As Integer = cmdcekLogin.ExecuteScalar()

            If (cek <> 0) Then
                If (id_peg = TextBox2.Text.ToUpper) Then
                    MessageBox.Show("Pegawai Wahana berhasil masuk")
                    ID_WAHANA.Show()
                Else
                    MessageBox.Show("Password salah")
                End If
            Else
                MessageBox.Show("ID Pegawai Wahana tidak ditemukan")
            End If
        ElseIf (MAINMENU.flag = 4) Then
            Dim id_peg As String = TextBox1.Text.ToUpper

            Dim cekLogin As String = "select count(id_pegawai) from pegawai where id_pegawai = '" + id_peg + "' AND ID_JABATAN LIKE '%PP%'"
            Dim cmdcekLogin As OracleCommand = New OracleCommand
            cmdcekLogin.CommandText = cekLogin
            cmdcekLogin.Connection = Me.OraCon
            Dim cek As Integer = cmdcekLogin.ExecuteScalar()

            If (cek <> 0) Then
                If (id_peg = TextBox2.Text.ToUpper) Then
                    MessageBox.Show("Pegawai Pintu Masuk berhasil masuk")
                    GATEIN.Show()
                Else
                    MessageBox.Show("Password salah")
                End If
            Else
                MessageBox.Show("ID Pegawai Pintu Masuk tidak ditemukan")
            End If
        End If

        Me.Hide()
    End Sub

    Public Function cek_uang(uang)
        Dim nominal As Integer = uang
        Dim lengt As Integer = nominal.ToString.Length
        Dim cek_nominal As Integer = lengt
        Dim temp1 As String = ""
        Dim temp2 As String
        Do
            If cek_nominal - 3 > 0 Then
                If cek_nominal = lengt Then
                    temp2 = nominal.ToString.Substring(cek_nominal - 3, 3)
                    temp1 = temp2
                Else
                    temp2 = nominal.ToString.Substring(cek_nominal - 3, 3)
                    temp1 = temp2 + "." + temp1
                End If
            Else
                temp2 = nominal.ToString.Substring(0, cek_nominal)
                temp1 = temp2 + "." + temp1
            End If
            cek_nominal -= 3
        Loop While cek_nominal > 0
        Return temp1
    End Function

    Function kembalikan_cek_uang(nominal)
        Dim temp As String = ""
        Dim len As Integer = nominal.Length
        Dim i As Integer = 0
        If len > 0 Then
            Do
                Dim digit = nominal.Substring(i, 1)
                If digit <> "." Then
                    temp = temp + digit
                End If
                i += 1
            Loop While i < len
        End If
        Return temp
    End Function

End Class