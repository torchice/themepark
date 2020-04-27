Imports Oracle.DataAccess.Client
Imports System.Data.SqlClient

Module ModulProyek
    Dim jumlahslot As Integer = 50
    Public StringCon As String
    Public OraCon As OracleConnection

    Public Sub TampilPakir()
        'StringCon = "Data Source=XE; User Id=andy; Password=andy;"
        'OraCon = New OracleConnection(StringCon)

        'Try
        '    OraCon.Open()
        '    MessageBox.Show("Berhasil Log In Oracle")
        'Catch ex As Exception
        '    MessageBox.Show("Gagal Log In")
        'End Try
        'TIKET.ShowParkirAvailable()

        Dim ctrcek As Integer = TIKET.list.Count - 1
        If TIKET.list.Count = 0 Then
            For i As Integer = 1 To jumlahslot
                ' Set Button properties
                Dim dynamicButton As New Button
                Dim tambah As Integer = 20
                If i < 11 Then
                    dynamicButton.Location = New Point(10 * i * 5, 30 + tambah)
                ElseIf i > 10 And i <= 20 Then
                    dynamicButton.Location = New Point(10 * (i - 10) * 5, 100 + tambah)
                ElseIf i > 20 And i <= 30 Then
                    dynamicButton.Location = New Point(10 * (i - 20) * 5, 170 + tambah)
                ElseIf i > 30 And i <= 40 Then
                    dynamicButton.Location = New Point(10 * (i - 30) * 5, 240 + tambah)
                ElseIf i > 40 And i <= 50 Then
                    dynamicButton.Location = New Point(10 * (i - 40) * 5, 310 + tambah)
                End If
                dynamicButton.Text = i

                'Wait for two second
                dynamicButton.Height = 50
                dynamicButton.Width = 50
                ' Set background and foreground
                Application.DoEvents()
                dynamicButton.ForeColor = Color.Blue


                'Make sure backcolor is refreshed
                dynamicButton.BackColor = Color.Lime

                dynamicButton.Name = "Slot"
                dynamicButton.Font = New Font("Georgia", 16)
                ' Add Button to the Form. Placement of the Button
                ' will be based on the Location and Size of button
                AddHandler dynamicButton.Click, AddressOf TombolTekan_Click

                PARKIR.Controls.Add(dynamicButton)
            Next
        Else
            'MessageBox.Show(TIKET.list.Count)

            For i As Integer = 1 To jumlahslot
                ' Set Button properties
                Dim dynamicButton As New Button
                Dim tambah As Integer = 20
                If i < 11 Then
                    dynamicButton.Location = New Point(10 * i * 5, 30 + tambah)
                ElseIf i > 10 And i <= 20 Then
                    dynamicButton.Location = New Point(10 * (i - 10) * 5, 100 + tambah)
                ElseIf i > 20 And i <= 30 Then
                    dynamicButton.Location = New Point(10 * (i - 20) * 5, 170 + tambah)
                ElseIf i > 30 And i <= 40 Then
                    dynamicButton.Location = New Point(10 * (i - 30) * 5, 240 + tambah)
                ElseIf i > 40 And i <= 50 Then
                    dynamicButton.Location = New Point(10 * (i - 40) * 5, 310 + tambah)
                End If
                dynamicButton.Text = i

                'Untuk Check Slot
                dynamicButton.BackColor = Color.Lime

                For a = 0 To TIKET.list.Count - 1
                    If dynamicButton.Text = TIKET.list(a) Then
                        'MsgBox(dynamicButton.Text + TIKET.list(a))
                        ctravaible = ctravaible - 1
                        dynamicButton.BackColor = Color.Red
                        PARKIR.Label6.Text = ctravaible.ToString
                    End If
                Next

                dynamicButton.Height = 50
                dynamicButton.Width = 50
                ' Set background and foreground
                Application.DoEvents()
                dynamicButton.ForeColor = Color.Blue
                dynamicButton.Name = "Slot"
                dynamicButton.Font = New Font("Georgia", 16)
                AddHandler dynamicButton.Click, AddressOf TombolTekan_Click

                PARKIR.Controls.Add(dynamicButton)
            Next
        End If

        ' Create a Button object 

    End Sub

    Dim ctravaible As Integer = jumlahslot
    'viewparkir digunakan untuk mengecek apakah slot sudah terisi atau tidak
    'ketika sudah diisi maka load akan merah
    'ketika belum diisi maka load akan hijau
    Dim kodeviewparkir As String
    'untuk save genkodeparkir
    Sub callkodeviewparkir()
        Dim kode As OracleCommand = New OracleCommand()
        kode.Connection = LOGIN.OraCon
        kode.CommandText = "GENKODECHECKPARKIR"
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
        kodeviewparkir = hasil.Value.ToString

        'Label2.Text = hasil.Value.ToString

    End Sub
    Dim terisi As String
    'untuk memasukkan pada database isi , dgn value "sudah" jika terisi
    Dim blok As String
    'untuk save posisi yang sudah terisi
    Public DS As New DataSet
    Dim my_array() As String
    Dim ctrcheckparkir As Integer
    'deklarasi ctr untuk slot yang sudah kepakai diisi dari database
    Sub ShowData()
        ReDim my_array(jumlahslot)
        ' more code here
        my_array(0) = "aku"
        Dim stringdata As String = "select blok from viewparkir"

        ctrcheckparkir = ctrcheckparkir + 1
    End Sub
    Public Sub TombolTekan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShowData()
        'getListOfMotonum()
        Dim tombol As Button = CType(sender, Button)
        If tombol.BackColor = Color.Lime And PARKIR.hasilcode <> "" Then
            terisi = "sudah"
            callkodeviewparkir()
            If TypeOf sender Is Button Then
                tombol.BackColor = Color.Red
                ctravaible = ctravaible - 1
                PARKIR.Label6.Text = ctravaible.ToString
                blok = tombol.Text
                'MessageBox.Show(kodeviewparkir)
                Dim insertp As String = "INSERT INTO VIEWPARKIR VALUES('" & kodeviewparkir & "',' " & terisi & "','" & blok & "')"
                Dim cmdinsert As OracleCommand = New OracleCommand()
                cmdinsert.Connection = LOGIN.OraCon
                cmdinsert.CommandText = insertp

                Try
                    cmdinsert.ExecuteNonQuery()
                    MsgBox("insert berhasil")
                    callkodeviewparkir()

                Catch ex As Exception
                    PARKIR.Label2.Text = "gagal"

                    MessageBox.Show(ex.ToString())
                End Try
                PARKIR.hasilcode = ""
            End If
        ElseIf tombol.BackColor = Color.Red Then
            Select Case MsgBox("Confirmation Delete", MsgBoxStyle.YesNo, "Confirmation")
                Case MsgBoxResult.Yes
                    'MessageBox.Show("Yes button")
                    blok = tombol.Text
                    'MessageBox.Show(blok)
                    Dim delete As String = "DELETE FROM VIEWPARKIR WHERE BLOK='" & blok & "'"
                    Dim cmddelete As OracleCommand = New OracleCommand()
                    cmddelete.CommandText = delete
                    cmddelete.Connection = LOGIN.OraCon
                    Try
                        cmddelete.ExecuteNonQuery()
                        MsgBox("delete berhasil")
                        ctravaible = ctravaible + 1
                        PARKIR.Label6.Text = ctravaible.ToString
                        tombol.BackColor = Color.Lime
                        'callkodeviewparkir()

                    Catch ex As Exception
                        MessageBox.Show(ex.ToString())
                    End Try
                    'MessageBox.Show("sudah terisi")
                Case MsgBoxResult.No
                    'FormBayarTiket.Close()
                    PARKIR.Show()
            End Select

        ElseIf PARKIR.hasilcode = "" Then
            MessageBox.Show("Kode belum tergenerate")
        End If

    End Sub


End Module
