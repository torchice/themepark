Imports Oracle.DataAccess.Client

Public Class MasterJenisKendaraan
    Public listnamakendaraan As New ArrayList
    Public listtarifkendaraan As New ArrayList
    Public ctrlistkendaraan As Integer = 0
    Public StringCon As String
    Public OraCon As OracleConnection
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("nama kendaraan belum diisi")
        ElseIf TextBox2.Text = "" Then
            MessageBox.Show("tarif kendaraan belum diisi")
        Else
            'listnamakendaraan.Add(TextBox1.Text)
            'listtarifkendaraan.Add(TextBox2.Text)
            ''MessageBox.Show(listnamakendaraan(ctrlistkendaraan))
            'ctrlistkendaraan = ctrlistkendaraan + 1
            'INSERT INTO LISTKENDARAAN VALUES('LK','BECAK',1000);
            Dim insertp As String = "INSERT INTO LISTKENDARAAN VALUES('" & Label4.Text & "',' " & TextBox1.Text & "','" & TextBox2.Text & "')"
            Dim cmdinsert As OracleCommand = New OracleCommand()
            cmdinsert.Connection = LOGIN.OraCon
            cmdinsert.CommandText = insertp
            Try
                'FormInputParkir.TextBox3.Text = hargatotal.ToString
                cmdinsert.ExecuteNonQuery()
                MsgBox("insert berhasil")
                'untuk memberikan pengecekan bisa bayar atau tidak
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try

        End If

    End Sub


    Sub callkodelistkendaraan()
        Dim kode As OracleCommand = New OracleCommand()
        kode.Connection = LOGIN.OraCon
        kode.CommandText = "GENKODELISTKENDARAAN"
        kode.CommandType = CommandType.StoredProcedure

        Dim hasil As New OracleParameter
        hasil.ParameterName = "hasil"
        hasil.OracleDbType = OracleDbType.Varchar2
        hasil.Direction = ParameterDirection.ReturnValue
        hasil.Size = 10

        Try
            kode.Parameters.Add(hasil)
            kode.ExecuteNonQuery()
            'MessageBox.Show(hasil.Value.ToString)
        Catch ex As Exception '
            MsgBox(ex.ToString)
        End Try
        Label4.Text = hasil.Value.ToString

    End Sub

    Public Sub ListTambah()
        Dim ctr As Integer = 0
        Dim cmd As New OracleCommand
        cmd.Connection = LOGIN.OraCon
        'select nm_kendaraan,tarif_kendaraan from listkendaraan;
        cmd.CommandText = "select nm_kendaraan,tarif_kendaraan from listkendaraan"
        Dim reader As OracleDataReader
        Try
            reader = cmd.ExecuteReader()
            While reader.Read
                'listnamakendaraan.Add(reader.GetValue(0).ToString)
                listnamakendaraan.Add(reader.GetValue(0).ToString)
                listtarifkendaraan.Add(reader.GetValue(1).ToString)
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

    Private Sub MasterJenisKendaraan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'StringCon = "Data Source=XE; User Id=andy; Password=andy;"
        'OraCon = New OracleConnection(StringCon)
        'Try
        '    OraCon.Open()
        'Catch ex As Exception
        '    MessageBox.Show("Gagal Log In")
        'End Try
        ListTambah()
        'MessageBox.Show(listnamakendaraan.Count)

        callkodelistkendaraan()
        'For i = 0 To listnamakendaraan.Count - 1
        '    MessageBox.Show(listnamakendaraan(i))
        '    MessageBox.Show(listtarifkendaraan(i))
        'Next

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MASTER.Show()
        Me.Hide()

    End Sub
End Class