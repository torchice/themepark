Imports Oracle.DataAccess.Client
Public Class Master_Pegawai
    Public PILIH_PEGAWAI As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        NEW_PEGAWAI.Show()
    End Sub

    Private Sub Master_Pegawai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowData()
    End Sub

    Private Sub ShowData()
        Dim Stringdata As String = "select ID_PEGAWAI, NO_KTP, NAMA_PEGAWAI, TO_CHAR(TGL_LAHIR,'DD-MM-YYYY') AS TANGGAL_LAHIR, AGAMA, STATUS_MENIKAH, ALAMAT_KTP, ALAMAT_SKG, ID_JABATAN, NVL(ID_MANAGER,'NULL') AS ID_MANAGER from PEGAWAI"
        Dim ADP As New OracleDataAdapter(Stringdata, LOGIN.OraCon)
        Dim DS As New DataSet

        ADP.Fill(DS)
        DataGridView1.DataSource = DS.Tables(0)
    End Sub

    Private Sub Master_Pegawai_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Call ShowData()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        PILIH_PEGAWAI = e.RowIndex
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call ShowData()
        NEW_PEGAWAI.Show()
        NEW_PEGAWAI.Button1.Text = "UPDATE"
        NEW_PEGAWAI.Label2.Text = DataGridView1.Rows(PILIH_PEGAWAI).Cells(0).Value
        NEW_PEGAWAI.TextBox1.Text = DataGridView1.Rows(PILIH_PEGAWAI).Cells(1).Value
        NEW_PEGAWAI.TextBox2.Text = DataGridView1.Rows(PILIH_PEGAWAI).Cells(2).Value
        Dim tanggal As Integer = DataGridView1.Rows(PILIH_PEGAWAI).Cells(3).Value.ToString.Substring(0, 2)
        Dim bulan As Integer = DataGridView1.Rows(PILIH_PEGAWAI).Cells(3).Value.ToString.Substring(3, 2)
        Dim tahun As Integer = DataGridView1.Rows(PILIH_PEGAWAI).Cells(3).Value.ToString.Substring(6)
        NEW_PEGAWAI.DateTimePicker1.Value = New Date(tahun, bulan, tanggal)
        If DataGridView1.Rows(PILIH_PEGAWAI).Cells(5).Value = "1" Then
            NEW_PEGAWAI.RadioButton1.Checked = True
        Else
            NEW_PEGAWAI.RadioButton2.Checked = True
        End If
        NEW_PEGAWAI.TextBox5.Text = DataGridView1.Rows(PILIH_PEGAWAI).Cells(6).Value
        NEW_PEGAWAI.TextBox6.Text = DataGridView1.Rows(PILIH_PEGAWAI).Cells(7).Value
        NEW_PEGAWAI.ComboBox1.SelectedItem = DataGridView1.Rows(PILIH_PEGAWAI).Cells(8).Value
        NEW_PEGAWAI.tunjukkan_agama()
        NEW_PEGAWAI.tunjukkan_manager()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim id_PEGAWAI As String = DataGridView1.Rows(PILIH_PEGAWAI).Cells(0).Value

        Dim delete_PEGAWAI As String = "DELETE FROM PEGAWAI WHERE ID_PEGAWAI = '" + id_PEGAWAI + "'"
        Dim cmddelete As OracleCommand = New OracleCommand
        cmddelete.CommandText = delete_PEGAWAI
        cmddelete.Connection = LOGIN.OraCon

        Try
            cmddelete.ExecuteNonQuery()
            MessageBox.Show("Delete Pegawai Berhasil!")
            Call ShowData()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub
End Class