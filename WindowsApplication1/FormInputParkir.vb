Imports Oracle.DataAccess.Client

Public Class FormInputParkir
    Public StringCon As String
    Public OraCon As OracleConnection

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PARKIR.Label2.Text = "gagal"

        Me.Hide()
        PARKIR.Show()
    End Sub
    Dim tarifparkir As Integer
    Dim KD_KENDARAAN As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedIndex = 0 Then
            tarifparkir = 3000
        ElseIf ComboBox1.SelectedIndex = 1 Then
            tarifparkir = 5000
        ElseIf ComboBox1.SelectedIndex = 2 Then

        End If

        If TextBox1.Text = "" Then
            MessageBox.Show("nama pemilik belum diisi")
        ElseIf TextBox2.Text = "" Then
            MessageBox.Show("nomor registrasi belum diisi")
        Else
            TextBox3.Text = "isi"
            Dim insertp As String = "INSERT INTO DPARKIR VALUES('" & Label4.Text & "',' " & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & tarifparkir & "')"
            Dim cmdinsert As OracleCommand = New OracleCommand()
            cmdinsert.Connection = LOGIN.OraCon

            cmdinsert.CommandText = insertp

            Try
                PARKIR.Label2.Text = "berhasil"
                cmdinsert.ExecuteNonQuery()
                MsgBox("insert berhasil")
                callkodeparkir()
                TextBox1.Text = ""
                TextBox2.Text = ""
                PARKIR.hasilcode = Me.Label4.Text
                Me.Close()
                PARKIR.Show()

            Catch ex As Exception
                PARKIR.Label2.Text = "gagal"

                MessageBox.Show(ex.ToString())
            End Try
        End If
    End Sub
    Public Sub ListTambah()
        Dim ctr As Integer = 0
        Dim cmd As New OracleCommand
        cmd.Connection = LOGIN.OraCon
        cmd.CommandText = "select nm_kendaraan,tarif_kendaraan from listkendaraan"
        Dim reader As OracleDataReader
        Try
            reader = cmd.ExecuteReader()
            While reader.Read
                'listnamakendaraan.Add(reader.GetValue(0).ToString)
                MasterJenisKendaraan.listnamakendaraan.Add(reader.GetValue(0).ToString)
                MasterJenisKendaraan.listtarifkendaraan.Add(reader.GetValue(1).ToString)
                'untuk menambahkan ke list namakendaraan dan tarif
                'ctrlistkendaraan = ctrlistkendaraan + 1
                'MessageBox.Show(reader.GetValue(0).ToString)
                'MessageBox.Show(reader.GetValue(1).ToString)
            End While
            reader.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub FormInputParkir_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'StringCon = "Data Source=XE; User Id=probis1; Password=probis1;"
        'OraCon = New OracleConnection(StringCon)
        'Try
        '    OraCon.Open()
        '    MessageBox.Show("Berhasil Log In Oracle")
        'Catch ex As Exception
        '    MessageBox.Show("Gagal Log In")
        'End Try
        callkodeparkir()
        ListTambah()

        For i = 0 To MasterJenisKendaraan.listnamakendaraan.Count - 1
            ComboBox1.Items.Add(MasterJenisKendaraan.listnamakendaraan(i))
            ComboBox2.Items.Add(MasterJenisKendaraan.listtarifkendaraan(i))
        Next
        'MasterJenisKendaraan.listtambah()
    End Sub
    Dim ctrkode As Integer

    Sub callkodeparkir()
        Dim kode As OracleCommand = New OracleCommand()
        kode.Connection = LOGIN.OraCon
        kode.CommandText = "GENKODEPARKIR"
        kode.CommandType = CommandType.StoredProcedure

        Dim hasil As New OracleParameter
        hasil.ParameterName = "hasil"
        hasil.OracleDbType = OracleDbType.Varchar2
        hasil.Direction = ParameterDirection.ReturnValue
        hasil.Size = 10

        Try
            kode.Parameters.Add(hasil)
            kode.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Label4.Text = hasil.Value.ToString

    End Sub
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub
    Dim ctrconnkendaran As Integer = 0
    'untuk mengkoneksikan otomatis tarif
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ctrconnkendaran = ComboBox1.SelectedIndex
        ComboBox2.SelectedIndex = ctrconnkendaran
    End Sub
End Class