Imports Oracle.DataAccess.Client
Public Class MASTER_MEMBER
    Dim pilih_member As Integer
    Private Sub ShowData()
        Dim Stringdata As String = "select ID_MEMBER, NO_KTP, NAMA, TO_CHAR(TGL_LAHIR,'DD MONTH YYYY'), ALAMAT from MEMBER"
        Dim ADP As New OracleDataAdapter(Stringdata, LOGIN.OraCon)
        Dim DS As New DataSet

        ADP.Fill(DS)
        DataGridView1.DataSource = DS.Tables(0)
    End Sub

    Private Sub autogenid()
        Dim cek As String = "select nvl(max(id_MEMBER),'M000') from MEMBER"
        Dim cmdcek As OracleCommand = New OracleCommand
        cmdcek.CommandText = cek
        cmdcek.Connection = LOGIN.OraCon
        Dim id As String = cmdcek.ExecuteScalar()
        Dim ctr As Integer = id.Substring(3)
        Label2.Text = "M" + (ctr + 1).ToString("d3")
    End Sub

    Private Sub MASTER_MEMBER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call autogenid()
        Call ShowData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim id_member As String = Label2.Text
        Dim no_ktp As String = TextBox1.Text
        Dim nama_member As String = TextBox2.Text
        Dim tanggal_lahir As String = DateTimePicker1.Value
        Dim alamat_member As String = TextBox3.Text
        Dim insert_member As String = "INSERT INTO MEMBER VALUES('" + id_member.ToUpper + "','" + no_ktp.ToUpper + "','" + nama_member.ToUpper + "',to_date('" + tanggal_lahir + "','DD-MM-YYYY'),'" + alamat_member.ToUpper + "')"
        Dim cmdinsert As OracleCommand = New OracleCommand
        cmdinsert.CommandText = insert_member
        cmdinsert.Connection = LOGIN.OraCon

        Try
            cmdinsert.ExecuteNonQuery()
            MessageBox.Show("Insert Member Berhasil!")
            Call ShowData()
            Call autogenid()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim update_member As String = "update MEMBER set NO_KTP='" + TextBox1.Text + "' ,NAMA = '" + TextBox2.Text.ToUpper + "' ,TGL_LAHIR = to_date('" + DateTimePicker1.Value + "', 'DD-MM-YYYY') ,ALAMAT= '" + TextBox3.Text.ToUpper + "' where ID_MEMBER = '" + Label2.Text.ToUpper + "'"
        Dim cmdupdate As OracleCommand = New OracleCommand
        cmdupdate.CommandText = update_member
        cmdupdate.Connection = LOGIN.OraCon

        Try
            cmdupdate.ExecuteNonQuery()
            MessageBox.Show("Update Member Berhasil!")
            Call ShowData()
            Call autogenid()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim id_member As String = DataGridView1.Rows(pilih_member).Cells(0).Value

        Dim delete_sponsor As String = "DELETE FROM MEMBER WHERE ID_MEMBER = '" + id_member + "'"
        Dim cmddelete As OracleCommand = New OracleCommand
        cmddelete.CommandText = delete_sponsor
        cmddelete.Connection = LOGIN.OraCon

        Try
            cmddelete.ExecuteNonQuery()
            MessageBox.Show("Delete Member Berhasil!")
            Call ShowData()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        pilih_member = e.RowIndex
        Label2.Text = DataGridView1.Rows(pilih_member).Cells(0).Value
        TextBox1.Text = DataGridView1.Rows(pilih_member).Cells(1).Value
        TextBox2.Text = DataGridView1.Rows(pilih_member).Cells(2).Value
        TextBox3.Text = DataGridView1.Rows(pilih_member).Cells(4).Value
        Dim tanggal As Integer = DataGridView1.Rows(pilih_member).Cells(3).Value.ToString.Substring(0, 2)
        Dim bulan As Integer = DataGridView1.Rows(pilih_member).Cells(3).Value.ToString.Substring(3, 2)
        Dim tahun As Integer = DataGridView1.Rows(pilih_member).Cells(3).Value.ToString.Substring(6)
        DateTimePicker1.Value = New Date(tahun, bulan, tanggal)
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        If TextBox1.Text = "" Then
            TextBox1.BackColor = Color.Pink
        Else
            TextBox1.BackColor = Color.White
        End If
    End Sub

    Private Sub TextBox2_Leave(sender As Object, e As EventArgs) Handles TextBox2.Leave
        If TextBox2.Text = "" Then
            TextBox2.BackColor = Color.Pink
        Else
            TextBox2.BackColor = Color.White
        End If
    End Sub

    Private Sub TextBox3_Leave(sender As Object, e As EventArgs) Handles TextBox3.Leave
        If TextBox3.Text = "" Then
            TextBox3.BackColor = Color.Pink
        Else
            TextBox3.BackColor = Color.White
        End If
    End Sub
End Class