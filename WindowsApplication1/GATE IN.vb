Imports Oracle.DataAccess.Client
Public Class GATEIN
    Public StringCon As String
    Public OraCon As OracleConnection

    Private Sub btnIn_Click(sender As Object, e As EventArgs) Handles btnIn.Click
        If (RichTextBox1.Text <> "") Then
            Dim update_pengunjung As String = "update PENGUNJUNG set STATUS_PENGUNJUNG = 'I' where ID_PENGUNJUNG = '" + RichTextBox1.Text.ToUpper + "'"
            Dim cmdupdatepengunjung As OracleCommand = New OracleCommand
            cmdupdatepengunjung.CommandText = update_pengunjung
            cmdupdatepengunjung.Connection = LOGIN.OraCon

            Try
                cmdupdatepengunjung.ExecuteNonQuery()
                MessageBox.Show("pengunjung masuk")
                RichTextBox1.Text = ""
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            End Try
        End If
    End Sub

    Private Sub btnOut_Click(sender As Object, e As EventArgs) Handles btnOut.Click
        If (RichTextBox1.Text <> "") Then
            Dim update_pengunjung As String = "update PENGUNJUNG set STATUS_PENGUNJUNG = 'O' where ID_PENGUNJUNG = '" + RichTextBox1.Text.ToUpper + "'"
            Dim cmdupdatepengunjung As OracleCommand = New OracleCommand
            cmdupdatepengunjung.CommandText = update_pengunjung
            cmdupdatepengunjung.Connection = LOGIN.OraCon

            Try
                cmdupdatepengunjung.ExecuteNonQuery()
                MessageBox.Show("pengunjung keluar")
                RichTextBox1.Text = ""
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            End Try
        End If
    End Sub
End Class