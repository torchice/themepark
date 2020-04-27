Imports Oracle.DataAccess.Client
Public Class master_jabatan
    Private Sub autogenid()
        Dim tulisan As String = TextBox1.Text.ToUpper
        Dim spasi As Integer = tulisan.IndexOf(" ")
        Dim huruf1 As String = tulisan.Substring(0, 1)
        Dim huruf2 As String
        If spasi > 0 Then
            huruf2 = tulisan.Substring(spasi + 1, 1)
        Else
            huruf2 = tulisan.Substring(1, 1)
        End If
        Dim cek As String = "select nvl(max(ID_JABATAN),'XX000') from JABATAN WHERE ID_JABATAN LIKE '" + huruf1 + huruf2 + "%'"
        Dim cmdcek As OracleCommand = New OracleCommand
        cmdcek.CommandText = cek
        cmdcek.Connection = LOGIN.OraCon
        Dim id As String = cmdcek.ExecuteScalar()
        Dim ctr As Integer = id.Substring(2) + 1
        Label4.Text = huruf1 + huruf2 + ctr.ToString("D3")
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If TextBox1.Text = "" Then
            TextBox1.BackColor = Color.Pink
        Else
            TextBox1.BackColor = Color.White
            Call autogenid()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Nama Jabatan Belum Diisi", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim id_jabatan As String = Label4.Text
            Dim nama_jabatan As String = TextBox1.Text.ToUpper
            Dim insert_jabatan As String = "INSERT INTO JABATAN VALUES('" + id_jabatan + "','" + nama_jabatan + "')"
            Dim cmdinsert As OracleCommand = New OracleCommand
            cmdinsert.CommandText = insert_jabatan
            cmdinsert.Connection = LOGIN.OraCon

            Try
                cmdinsert.ExecuteNonQuery()
                MessageBox.Show("Insert Jabatan Berhasil!")
                Call autogenid()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            End Try
        End If
    End Sub

    Private Sub master_jabatan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class