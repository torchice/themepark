Imports Oracle.DataAccess.Client
Public Class CHECKIN_WAHANA

    Private Sub btnIn_Click(sender As Object, e As EventArgs) Handles btnIn.Click
        If (RichTextBox1.Text <> "") Then
            Dim regDate As String
            regDate = Format(Date.Now(), "dd-MM-yyyy")
            Dim id_wahana As String = Label3.Text.ToUpper

            Dim cek_DWAHANA As String = "SELECT COUNT(*) FROM D_WAHANA WHERE ID_WAHANA = '" + id_wahana + "'"
            Dim cmdcekDWAHANA As OracleCommand = New OracleCommand
            cmdcekDWAHANA.CommandText = cek_DWAHANA
            cmdcekDWAHANA.Connection = LOGIN.OraCon

            Dim id_pengunjung As String = RichTextBox1.Text.ToUpper

            Dim cek_CustMasuk As String = "SELECT COUNT(*) FROM D_WAHANA WHERE ID_WAHANA = '" + id_wahana + "' AND ID_PENGUNJUNG = '" + id_pengunjung + "' AND STATUS_MAIN = 'I'"
            Dim cmdcekCustMasuk As OracleCommand = New OracleCommand
            cmdcekCustMasuk.CommandText = cek_CustMasuk
            cmdcekCustMasuk.Connection = LOGIN.OraCon
            Dim cekCustMasuk As Integer = cmdcekCustMasuk.ExecuteScalar()

            If (cekCustMasuk <> 0) Then
                MessageBox.Show("Pengunjung Sudah Dalam Antrian")
                RichTextBox1.Text = ""
            ElseIf (cekCustMasuk = 0) Then
                Dim insert_dwahana As String = "INSERT INTO D_WAHANA VALUES('" + id_wahana + "','" + id_pengunjung + "',TO_DATE('" + regDate + "','dd-MM-yyyy'),'I')"
                Dim cmdinsert_dwahana As OracleCommand = New OracleCommand
                cmdinsert_dwahana.CommandText = insert_dwahana
                cmdinsert_dwahana.Connection = LOGIN.OraCon

                Try
                    cmdinsert_dwahana.ExecuteNonQuery()
                    MessageBox.Show("pengunjung " & id_pengunjung & " masuk antrian")
                    RichTextBox1.Text = ""
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString())
                End Try

            End If
        Else
            MessageBox.Show("ID Pengunjung belum terisi!")
        End If
    End Sub

    Private Sub btnOut_Click(sender As Object, e As EventArgs) Handles btnOut.Click
        Dim id_cust As String = RichTextBox1.Text.ToUpper
        Dim id_wahana As String = Label3.Text.ToUpper

        If (id_cust <> "") Then
            Dim cek_CustKeluar As String = "SELECT COUNT(*) FROM D_WAHANA WHERE ID_WAHANA = '" + id_wahana + "' AND ID_PENGUNJUNG = '" + id_cust + "' AND STATUS_MAIN = 'I'"
            Dim cmdcekCustKeluar As OracleCommand = New OracleCommand
            cmdcekCustKeluar.CommandText = cek_CustKeluar
            cmdcekCustKeluar.Connection = LOGIN.OraCon
            Dim cekCustKeluar As Integer = cmdcekCustKeluar.ExecuteScalar()

            If (cekCustKeluar = 0) Then
                MessageBox.Show("Pengunjung sudah keluar")
            ElseIf (cekCustKeluar > 0) Then
                Dim update_Out As String = "update D_WAHANA set STATUS_MAIN='O' WHERE ID_PENGUNJUNG = '" + id_cust + "' AND ID_WAHANA = '" + id_wahana + "'"
                Dim cmdupdate_Out As OracleCommand = New OracleCommand
                cmdupdate_Out.CommandText = update_Out
                cmdupdate_Out.Connection = LOGIN.OraCon

                Try
                    cmdupdate_Out.ExecuteNonQuery()
                    MessageBox.Show("pengunjung " & id_cust & " selesai main")
                    RichTextBox1.Text = ""
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString())
                End Try
            End If
        Else
            MessageBox.Show("ID Pengunjung belum terisi!")
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ID_WAHANA.Show()
        Me.Close()
    End Sub
End Class