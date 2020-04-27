Imports Oracle.DataAccess.Client
Public Class INSERT_SHOW
    Public StringCon As String
    Public OraCon As OracleConnection

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text = "" Then
            MessageBox.Show("Nama Jabatan Belum Diisi", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim id_show As String = Label5.Text
            Dim nama_show As String = TextBox2.Text.ToUpper
            Dim ket As String = TextBox3.Text.ToUpper
            Dim jam_aw As String = TextBox1.Text.ToUpper + ":" + TextBox4.Text.ToUpper
            Dim jam_ak As String = TextBox5.Text.ToUpper + ":" + TextBox6.Text.ToUpper
            Dim insert_jabatan As String = "INSERT INTO header_show VALUES('" + id_show + "','" + nama_show + "','" +
            ket + "','" + jam_aw + "','" + jam_ak + "')"
            Dim cmdinsert As OracleCommand = New OracleCommand
            cmdinsert.CommandText = insert_jabatan
            cmdinsert.Connection = MAINMENU.OraCon

            Try
                cmdinsert.ExecuteNonQuery()
                MessageBox.Show("Insert show Berhasil!")
                Call ShowData()
                Call autogen_id()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            End Try
        End If
    End Sub

    Private Sub INSERT_SHOW_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'StringCon = "Data Source=XE; User Id=andy; Password=andy;"
        'OraCon = New OracleConnection(StringCon)
        'Try
        '    OraCon.Open()
        '    MessageBox.Show("Berhasil Log In Oracle")
        'Catch ex As Exception
        '    MessageBox.Show("Gagal Log In")
        'End Try
        Call ShowData()
        Call autogen_id()
        Dim jam_skg As String = Format(Date.Now(), "hh:mm")
        TextBox1.Text = jam_skg.Substring(0, 2)
        TextBox4.Text = jam_skg.Substring(3, 2)
    End Sub

    Private Sub ShowData()
        Dim Stringdata As String = "select * from header_show"
        Dim ADP As New OracleDataAdapter(Stringdata, MAINMENU.OraCon)
        Dim DS As New DataSet

        ADP.Fill(DS)
        DataGridView1.DataSource = DS.Tables(0)
    End Sub

    Private Sub autogen_id()
        Dim cek As String = "select nvl(max(ID_SHOW),'SHOW-000') from HEADER_SHOW"
        Dim cmdcek As OracleCommand = New OracleCommand
        cmdcek.CommandText = cek
        cmdcek.Connection = MAINMENU.OraCon
        Dim id As String = cmdcek.ExecuteScalar()
        Dim ctr As Integer = id.Substring(5)
        Label5.Text = "SHOW-" + (ctr + 1).ToString("d3")
    End Sub
End Class