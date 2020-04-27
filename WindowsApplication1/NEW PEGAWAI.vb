Imports Oracle.DataAccess.Client
Public Class NEW_PEGAWAI
    Private Sub autogenid()
        Dim cek As String = "select nvl(max(id_PEGAWAI),'M000') from PEGAWAI"
        Dim cmdcek As OracleCommand = New OracleCommand
        cmdcek.CommandText = cek
        cmdcek.Connection = LOGIN.OraCon
        Dim id As String = cmdcek.ExecuteScalar()
        Dim ctr As Integer = id.Substring(2)
        Label2.Text = "PE" + (ctr + 1).ToString("d4")
    End Sub

    Private Sub input_jabatan()
        Dim Stringdata As String = "select * from JABATAN"
        Dim ADP As New OracleDataAdapter(Stringdata, LOGIN.OraCon)
        Dim DS As New DataSet

        ADP.Fill(DS)
        DataGridView1.DataSource = DS.Tables(0)

        Dim conter As Integer = DataGridView1.RowCount
        For i As Integer = 0 To conter - 2
            ComboBox1.Items.Add(DataGridView1.Rows(i).Cells(0).Value)
        Next
    End Sub

    Public Sub input_manager()
        Dim Stringdata As String = "select ID_PEGAWAI from pegawai where id_JABATAN = 'MA001'"
        Dim ADP As New OracleDataAdapter(Stringdata, LOGIN.OraCon)
        Dim DS As New DataSet

        ADP.Fill(DS)
        DataGridView2.DataSource = DS.Tables(0)

        Dim conter As Integer = DataGridView2.RowCount
        For i As Integer = 0 To conter - 2
            ComboBox2.Items.Add(DataGridView2.Rows(i).Cells(0).Value)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" And TextBox2.Text = "" And TextBox5.Text = "" And ComboBox1.SelectedIndex = -1 And ComboBox3.SelectedIndex = -1 Then
            MessageBox.Show("Data Ada yang Belum Diisi", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If RadioButton1.Checked = False And RadioButton2.Checked = False Then
                MessageBox.Show("Data Menikah Belum Diisi", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                If Button1.Text = "UPDATE" Then
                    Dim status_nikah As String = ""
                    If RadioButton1.Checked Then
                        status_nikah = 1
                    Else
                        status_nikah = 0
                    End If
                    Dim update_member As String = "update PEGAWAI set NO_KTP='" + TextBox1.Text + "' ,NAMA_PEGAWAI = '" + TextBox2.Text.ToUpper + "' ,TGL_LAHIR = to_date('" + DateTimePicker1.Value + "', 'DD-MM-YYYY') ,AGAMA= '" + ComboBox3.SelectedItem.ToUpper + "', STATUS_MENIKAH = '" + status_nikah + "',ALAMAT_KTP='" + TextBox5.Text.ToUpper + "', ALAMAT_SKG='" + TextBox6.Text.ToUpper + "', ID_JABATAN='" + ComboBox1.SelectedItem + "', ID_MANAGER='" + ComboBox2.SelectedItem + "' where ID_PEGAWAI = '" + Label2.Text.ToUpper + "'"
                    Dim cmdupdate As OracleCommand = New OracleCommand
                    cmdupdate.CommandText = update_member
                    cmdupdate.Connection = LOGIN.OraCon

                    Try
                        cmdupdate.ExecuteNonQuery()
                        MessageBox.Show("Update Pegawai Berhasil!")
                    Catch ex As Exception
                        MessageBox.Show(ex.Message.ToString())
                    End Try
                    Me.Close()
                Else
                    Dim id_pegawai As String = Label2.Text
                    Dim no_ktp As String = TextBox1.Text
                    Dim nama_pegawai As String = TextBox2.Text
                    Dim tgl_lahir As String = DateTimePicker1.Value
                    Dim agama As String = ComboBox3.SelectedItem
                    Dim status_nikah As String = ""
                    If RadioButton1.Checked Then
                        status_nikah = 1
                    Else
                        status_nikah = 0
                    End If
                    Dim alamat_ktp As String = TextBox5.Text
                    Dim alamat_skg As String = TextBox6.Text
                    Dim jabatan As String = ComboBox1.SelectedItem
                    Dim id_manager As String = ComboBox2.SelectedItem
                    Dim insert_PEGAWAI As String = "INSERT INTO PEGAWAI VALUES('" + id_pegawai.ToUpper + "','" + no_ktp.ToUpper + "','" + nama_pegawai.ToUpper + "',to_date('" + tgl_lahir + "','DD-MM-YYYY'),'" + agama.ToUpper + "','" + status_nikah + "','" + alamat_ktp.ToUpper + "','" + alamat_skg.ToUpper + "','" + jabatan + "','" + id_manager + "')"
                    If id_manager = "" Then
                        insert_PEGAWAI = "INSERT INTO PEGAWAI VALUES('" + id_pegawai.ToUpper + "','" + no_ktp.ToUpper + "','" + nama_pegawai.ToUpper + "',to_date('" + tgl_lahir + "','DD-MM-YYYY'),'" + agama.ToUpper + "','" + status_nikah + "','" + alamat_ktp.ToUpper + "','" + alamat_skg.ToUpper + "','" + jabatan + "','NULL')"
                    End If
                    Dim cmdinsert As OracleCommand = New OracleCommand
                    cmdinsert.CommandText = insert_PEGAWAI
                    cmdinsert.Connection = LOGIN.OraCon

                    Try
                        cmdinsert.ExecuteNonQuery()
                        MessageBox.Show("Insert Pegawai Berhasil!")
                        Me.Close()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message.ToString())
                    End Try
                End If
            End If
        End If

        Label1.Text = DateTimePicker1.Value

    End Sub

    Private Sub NEW_PEGWAWAI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.CustomFormat = "dd-MM-yyyy"

        Call autogenid()
        Call input_jabatan()
        Call input_manager()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim id_jab As String = ComboBox1.SelectedItem
        Dim conter As Integer = DataGridView1.RowCount
        For i As Integer = 0 To conter - 2
            If ComboBox1.SelectedItem = DataGridView1.Rows(i).Cells(0).Value Then
                Label12.Text = DataGridView1.Rows(i).Cells(1).Value
            End If
        Next
    End Sub

    Public Sub tunjukkan_manager()
        If Master_Pegawai.DataGridView1.Rows(Master_Pegawai.PILIH_PEGAWAI).Cells(9).Value = "NULL" Then
            ComboBox2.SelectedIndex = -1
        Else
            Dim angka As Integer = Master_Pegawai.PILIH_PEGAWAI
            Dim conter As Integer = ComboBox2.Items.Count
            Dim i As Integer = 0
            Do
                    ComboBox2.SelectedIndex = i
                    If Master_Pegawai.DataGridView1.Rows(Master_Pegawai.PILIH_PEGAWAI).Cells(9).Value = ComboBox2.SelectedItem Then
                        i = ComboBox2.Items.Count()
                End If
                i += 1
            Loop While i < ComboBox2.Items.Count()
        End If
    End Sub

    Public Sub tunjukkan_agama()
        Dim angka As Integer = Master_Pegawai.PILIH_PEGAWAI
        Dim conter As Integer = ComboBox3.Items.Count
        Dim i As Integer = 0
        Do
            ComboBox3.SelectedIndex = i
            If Master_Pegawai.DataGridView1.Rows(Master_Pegawai.PILIH_PEGAWAI).Cells(4).Value = ComboBox3.SelectedItem Then
                i = ComboBox3.Items.Count()
            End If
            i += 1
        Loop While i < ComboBox3.Items.Count()
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

    Private Sub ComboBox3_Leave(sender As Object, e As EventArgs) Handles ComboBox3.Leave
        If ComboBox3.SelectedIndex = -1 Then
            ComboBox3.BackColor = Color.Pink
        Else
            ComboBox3.BackColor = Color.White
        End If
    End Sub

    Private Sub TextBox5_Leave(sender As Object, e As EventArgs) Handles TextBox5.Leave
        If TextBox5.Text = "" Then
            TextBox5.BackColor = Color.Pink
        Else
            TextBox5.BackColor = Color.White
        End If
    End Sub

    Private Sub TextBox6_Leave(sender As Object, e As EventArgs) Handles TextBox6.Leave
        If TextBox6.Text = "" Then
            TextBox6.BackColor = Color.Pink
        Else
            TextBox6.BackColor = Color.White
        End If
    End Sub

    Private Sub ComboBox1_Leave(sender As Object, e As EventArgs) Handles ComboBox1.Leave
        If ComboBox1.SelectedIndex = -1 Then
            ComboBox1.BackColor = Color.Pink
        Else
            ComboBox1.BackColor = Color.White
        End If
    End Sub

    Private Sub ComboBox2_Leave(sender As Object, e As EventArgs) Handles ComboBox2.Leave
        If ComboBox1.SelectedItem <> "MA001" Then
            If ComboBox2.SelectedIndex = -1 Then
                ComboBox2.BackColor = Color.Pink
            Else
                ComboBox2.BackColor = Color.White
            End If
        End If
    End Sub
End Class