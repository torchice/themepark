Imports Oracle.DataAccess.Client
Public Class MASTER_PENGELUARAN
    Dim pilih_pengeluaran As Integer
    Dim jumlah_pengeluaran As Integer

    Private Sub ShowData()
        Dim Stringdata As String = "select ID_PENGELUARAN, ID_PEGAWAI, TO_CHAR(TGL_PENGELUARAN,'DD-MM-YYYY') AS TANGGAL, TIPE_PENGELUARAN, JUMLAH, KETERANGAN from PENGELUARAN"
        Dim ADP As New OracleDataAdapter(Stringdata, LOGIN.OraCon)
        Dim DS As New DataSet

        ADP.Fill(DS)
        DataGridView1.DataSource = DS.Tables(0)
    End Sub

    Private Sub autogenid()
        Dim cek As String = "select nvl(max(ID_PENGELUARAN),'L00000') from PENGELUARAN"
        Dim cmdcek As OracleCommand = New OracleCommand
        cmdcek.CommandText = cek
        cmdcek.Connection = LOGIN.OraCon
        Dim id As String = cmdcek.ExecuteScalar()
        Dim ctr As Integer = id.Substring(1)
        Label2.Text = "PL" + (ctr + 1).ToString("D4")
    End Sub

    Private Sub MASTER_SPONSOR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ShowData()
        Call autogenid()
        Call show_pegawai()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim id_pengeluaran As String = Label2.Text.ToUpper
        Dim id_pegawai As String = ComboBox1.SelectedItem
        Dim tanggal As String = DateTimePicker1.Value
        Dim tipe As String = ""
        If RadioButton1.Checked Then
            tipe = "1"
        ElseIf RadioButton2.Checked Then
            tipe = "2"
        Else
            tipe = "3"
        End If
        jumlah_pengeluaran = LOGIN.kembalikan_cek_uang(TextBox3.Text)
        Dim keterangan As String = RichTextBox1.Text
        Dim insert_pengeluaran As String = "INSERT INTO PENGELUARAN VALUES('" + id_pengeluaran + "','" + id_pegawai + "',to_date('" + tanggal + "','DD-MM-YYYY'),'" + tipe + "',:harga,'" + keterangan + "')"
        Dim cmdinsert As OracleCommand = New OracleCommand
        cmdinsert.CommandText = insert_pengeluaran
        cmdinsert.Connection = LOGIN.OraCon

        Dim jumlah As OracleParameter = New OracleParameter()
        jumlah.Value = Int(jumlah_pengeluaran)
        jumlah.ParameterName = "JUMLAH"
        cmdinsert.Parameters.Add(jumlah)

        Try
            cmdinsert.ExecuteNonQuery()
            MessageBox.Show("Insert Pengeluaran Berhasil!")
            Call ShowData()
            Call autogenid()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim tipe As String = ""
        If RadioButton1.Checked Then
            tipe = "1"
        ElseIf RadioButton2.Checked Then
            tipe = "2"
        Else
            tipe = "3"
        End If
        jumlah_pengeluaran = CInt(LOGIN.kembalikan_cek_uang(TextBox3.Text))
        Dim Update As String = "update PENGELUARAN set ID_PEGAWAI = '" + ComboBox1.SelectedItem + "' ,TGL_PENGELUARAN = to_date('" + DateTimePicker1.Value + "', 'DD-MM-YYYY'),TIPE_PENGELUARAN = '" + tipe + "',JUMLAH= :JUMLAH, KETERANGAN = '" + RichTextBox1.Text + "' where ID_PENGELUARAN = '" + Label2.Text + "'"
        Dim cmdupdate As OracleCommand = New OracleCommand
        cmdupdate.CommandText = Update
        cmdupdate.Connection = LOGIN.OraCon

        Dim jumlah As OracleParameter = New OracleParameter()
        jumlah.Value = Int(jumlah_pengeluaran)
        jumlah.ParameterName = "JUMLAH"
        cmdupdate.Parameters.Add(jumlah)

        Try
            cmdupdate.ExecuteNonQuery()
            MessageBox.Show("Update Pengeluaran Berhasil!")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
        Call ShowData()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ID_PENGELUARAN As String = DataGridView1.Rows(pilih_pengeluaran).Cells(0).Value

        Dim delete_pengeluaran As String = "DELETE FROM PENGELUARAN WHERE ID_PENGELUARAN = '" + ID_PENGELUARAN + "'"
        Dim cmddelete As OracleCommand = New OracleCommand
        cmddelete.CommandText = delete_pengeluaran
        cmddelete.Connection = LOGIN.OraCon

        Try
            cmddelete.ExecuteNonQuery()
            MessageBox.Show("Delete Pengeluaran Berhasil!")
            Call ShowData()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        pilih_pengeluaran = e.RowIndex
        Label2.Text = DataGridView1.Rows(pilih_pengeluaran).Cells(0).Value
        Dim i As Integer = 0
        Do
            ComboBox1.SelectedIndex = i
            If DataGridView1.Rows(pilih_pengeluaran).Cells(1).Value = ComboBox1.SelectedItem Then
                i = ComboBox1.Items.Count
            End If
            i += 1
        Loop While i < ComboBox1.Items.Count

        Dim tanggal As Integer = DataGridView1.Rows(pilih_pengeluaran).Cells(2).Value.ToString.Substring(0, 2)
        Dim bulan As Integer = DataGridView1.Rows(pilih_pengeluaran).Cells(2).Value.ToString.Substring(3, 2)
        Dim tahun As Integer = DataGridView1.Rows(pilih_pengeluaran).Cells(2).Value.ToString.Substring(6)
        DateTimePicker1.Value = New Date(tahun, bulan, tanggal)
        If DataGridView1.Rows(pilih_pengeluaran).Cells(3).Value = "1" Then
            RadioButton1.Checked = True
        ElseIf DataGridView1.Rows(pilih_pengeluaran).Cells(3).Value = "2" Then
            RadioButton2.Checked = True
        Else
            RadioButton3.Checked = True
        End If
        TextBox3.Text = LOGIN.cek_uang(CInt(DataGridView1.Rows(pilih_pengeluaran).Cells(4).Value))
        jumlah_pengeluaran = CInt(LOGIN.kembalikan_cek_uang(TextBox3.Text))
        RichTextBox1.Text = DataGridView1.Rows(pilih_pengeluaran).Cells(5).Value
    End Sub

    Private Sub show_pegawai()
        Dim Stringdata As String = "select ID_PEGAWAI FROM PEGAWAI WHERE ID_JABATAN = 'PK002'"
        Dim ADP As New OracleDataAdapter(Stringdata, LOGIN.OraCon)
        Dim DS As New DataSet

        ADP.Fill(DS)
        DataGridView2.DataSource = DS.Tables(0)

        Dim jumlah_row As Integer = DataGridView2.RowCount()
        For i As Integer = 0 To jumlah_row - 2
            ComboBox1.Items.Add(DataGridView2.Rows(i).Cells(0).Value)
        Next
    End Sub

    Private Sub TextBox3_Leave(sender As Object, e As EventArgs) Handles TextBox3.Leave
        If TextBox3.Text = "" Then
            TextBox3.BackColor = Color.Pink
        Else
            TextBox3.BackColor = Color.White
            TextBox3.Text = LOGIN.cek_uang(CInt(TextBox3.Text))
        End If
    End Sub

    Private Sub TextBox3_Enter(sender As Object, e As EventArgs) Handles TextBox3.Enter
        TextBox3.Text = LOGIN.kembalikan_cek_uang(TextBox3.Text)
    End Sub

    Private Sub ComboBox1_Leave(sender As Object, e As EventArgs) Handles ComboBox1.Leave
        If ComboBox1.SelectedIndex = -1 Then
            ComboBox1.BackColor = Color.Pink
        Else
            ComboBox1.BackColor = Color.White
        End If
    End Sub

    Private Sub RichTextBox1_Leave(sender As Object, e As EventArgs) Handles RichTextBox1.Leave
        If RichTextBox1.Text = "" Then
            RichTextBox1.BackColor = Color.Pink
        Else
            RichTextBox1.BackColor = Color.White
        End If
    End Sub
End Class