Imports Oracle.DataAccess.Client
Public Class MASTER_SPONSOR
    Dim pilih_sponsor As Integer
    Dim harga_sponsor As Integer
    Private Sub ShowData()
        Dim Stringdata As String = "select ID_SPONSOR, ID_PEGAWAI, NAMA_SPONSOR, NAMA_PEMILIK, TO_CHAR(TGL_PASANG,'DD-MM-YYYY') AS TANGGAL_PASANG_SPONSOR, TO_CHAR(TGL_BERAKHIR,'DD-MM-YYYY') AS TANGGAL_BERAKHIR, HARGA_SPONSOR from SPONSOR"
        Dim ADP As New OracleDataAdapter(Stringdata, LOGIN.OraCon)
        Dim DS As New DataSet

        ADP.Fill(DS)
        DataGridView1.DataSource = DS.Tables(0)
    End Sub

    Private Sub autogenid()
        Dim cek As String = "select nvl(max(id_sponsor),'SP000') from sponsor"
        Dim cmdcek As OracleCommand = New OracleCommand
        cmdcek.CommandText = cek
        cmdcek.Connection = LOGIN.OraCon
        Dim id As String = cmdcek.ExecuteScalar()
        Dim ctr As Integer = id.Substring(3)
        Label2.Text = "SP" + (ctr + 1).ToString("d3")
    End Sub

    Private Sub MASTER_SPONSOR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ShowData()
        Call autogenid()
        Call show_pegawai()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim id_sponsor As String = Label2.Text.ToUpper
        Dim id_pegawai As String = ComboBox1.SelectedItem
        Dim nama_sponsor As String = TextBox2.Text.ToUpper
        Dim nama_pemilik As String = TextBox3.Text.ToUpper
        Dim tanggal_pasang As String = DateTimePicker1.Value
        Dim tanggal_akhir As String = DateTimePicker2.Value
        harga_sponsor = CInt(LOGIN.kembalikan_cek_uang(TextBox6.Text))
        Dim insert_sponsor As String = "INSERT INTO SPONSOR VALUES('" + id_sponsor + "','" + id_pegawai + "','" + nama_sponsor + "','" + nama_pemilik + "',to_date('" + tanggal_pasang + "','DD-MM-YYYY'),to_date('" + tanggal_akhir + "','DD-MM-YYYY'),:harga)"
        Dim cmdinsert As OracleCommand = New OracleCommand
        cmdinsert.CommandText = insert_sponsor
        cmdinsert.Connection = LOGIN.OraCon

        Dim harga As OracleParameter = New OracleParameter()
        harga.Value = harga_sponsor
        harga.ParameterName = "HARGA_SPONSOR"
        cmdinsert.Parameters.Add(harga)

        Try
            cmdinsert.ExecuteNonQuery()
            MessageBox.Show("Insert Sponsor Berhasil!")
            Call ShowData()
            Call autogenid()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Update As String = "update SPONSOR set NAMA_SPONSOR = '" + TextBox2.Text + "' ,TGL_PASANG = to_date('" + DateTimePicker1.Value + "', 'DD-MM-YYYY'),TGL_BERAKHIR = to_date('" + DateTimePicker2.Value + "', 'DD-MM-YYYY') ,NAMA_PEMILIK= '" + TextBox3.Text + "', HARGA_SPONSOR = :harga where ID_SPONSOR = '" + Label2.Text + "'"
        Dim cmdupdate As OracleCommand = New OracleCommand
        cmdupdate.CommandText = Update
        cmdupdate.Connection = LOGIN.OraCon

        harga_sponsor = CInt(LOGIN.kembalikan_cek_uang(TextBox6.Text))
        Dim harga As OracleParameter = New OracleParameter()
        harga.Value = harga_sponsor
        harga.ParameterName = "HARGA_SPONSOR"
        cmdupdate.Parameters.Add(harga)

        Try
            cmdupdate.ExecuteNonQuery()
            MessageBox.Show("Update Sponsor Berhasil!")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
        Call ShowData()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim id_sponsor As String = DataGridView1.Rows(pilih_sponsor).Cells(0).Value

        Dim delete_sponsor As String = "DELETE FROM SPONSOR WHERE ID_SPONSOR = '" + id_sponsor + "'"
        Dim cmddelete As OracleCommand = New OracleCommand
        cmddelete.CommandText = delete_sponsor
        cmddelete.Connection = LOGIN.OraCon

        Try
            cmddelete.ExecuteNonQuery()
            MessageBox.Show("Delete Sponsor Berhasil!")
            Call ShowData()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        pilih_sponsor = e.RowIndex
        Label2.Text = DataGridView1.Rows(pilih_sponsor).Cells(0).Value
        Dim i As Integer = 0
        Do
            ComboBox1.SelectedIndex = i
            If DataGridView1.Rows(pilih_sponsor).Cells(1).Value = ComboBox1.SelectedItem Then
                i = ComboBox1.Items.Count
            End If
            i += 1
        Loop While i < ComboBox1.Items.Count
        TextBox2.Text = DataGridView1.Rows(pilih_sponsor).Cells(2).Value
        TextBox3.Text = DataGridView1.Rows(pilih_sponsor).Cells(3).Value
        Dim tanggal_pasang As Integer = DataGridView1.Rows(pilih_sponsor).Cells(4).Value.ToString.Substring(0, 2)
        Dim bulan_pasang As Integer = DataGridView1.Rows(pilih_sponsor).Cells(4).Value.ToString.Substring(3, 2)
        Dim tahun_pasang As Integer = DataGridView1.Rows(pilih_sponsor).Cells(4).Value.ToString.Substring(6)
        DateTimePicker1.Value = New Date(tahun_pasang, bulan_pasang, tanggal_pasang)
        Dim tanggal_akhir As Integer = DataGridView1.Rows(pilih_sponsor).Cells(5).Value.ToString.Substring(0, 2)
        Dim bulan_akhir As Integer = DataGridView1.Rows(pilih_sponsor).Cells(5).Value.ToString.Substring(3, 2)
        Dim tahun_akhir As Integer = DataGridView1.Rows(pilih_sponsor).Cells(5).Value.ToString.Substring(6)
        DateTimePicker2.Value = New Date(tahun_akhir, bulan_akhir, tanggal_akhir)
        TextBox6.Text = LOGIN.cek_uang(CInt(DataGridView1.Rows(pilih_sponsor).Cells(6).Value))
    End Sub

    Private Sub show_pegawai()
        Dim Stringdata As String = "select ID_PEGAWAI FROM PEGAWAI WHERE ID_JABATAN = 'PS002'"
        Dim ADP As New OracleDataAdapter(Stringdata, LOGIN.OraCon)
        Dim DS As New DataSet

        ADP.Fill(DS)
        DataGridView2.DataSource = DS.Tables(0)
        Dim jumlah_row As Integer = DataGridView2.RowCount()
        For i As Integer = 0 To jumlah_row - 2
            ComboBox1.Items.Add(DataGridView2.Rows(i).Cells(0).Value)
        Next
    End Sub

    Private Sub TextBox6_Leave(sender As Object, e As EventArgs) Handles TextBox6.Leave
        If TextBox6.Text = "" Then
            TextBox6.BackColor = Color.Pink
        Else
            TextBox6.Text = LOGIN.cek_uang(CInt(TextBox6.Text))
            TextBox6.BackColor = Color.White
        End If
    End Sub

    Private Sub TextBox6_Enter(sender As Object, e As EventArgs) Handles TextBox6.Enter
        TextBox6.Text = LOGIN.kembalikan_cek_uang(TextBox6.Text)
    End Sub

    Private Sub ComboBox1_Leave(sender As Object, e As EventArgs) Handles ComboBox1.Leave
        If ComboBox1.SelectedIndex = -1 Then
            ComboBox1.BackColor = Color.Pink
        Else
            ComboBox1.BackColor = Color.White
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