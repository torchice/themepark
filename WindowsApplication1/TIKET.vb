Imports Oracle.DataAccess.Client
Public Class TIKET
    Private Sub ShowData()
        Dim nmr_nota As String = lbNmrNota.Text

        Dim Stringdata As String = "select NOMOR_NOTA AS ""NO. NOTA"", JENIS_TIKET AS ""JENIS TIKET"", JUMLAH AS ""JUMLAH"", HARGA_SATUAN AS ""HARGA SATUAN"", TOTAL AS ""TOTAL"" FROM D_JUAL WHERE NOMOR_NOTA = '" & nmr_nota & "'"
        Dim ADP As New OracleDataAdapter(Stringdata, LOGIN.OraCon)
        Dim DS As New DataSet

        ADP.Fill(DS)
        DataGridView1.DataSource = DS.Tables(0)
    End Sub

    Private Sub autogenid()
        Dim regDate As String
        regDate = Format(Date.Now(), "ddMMyyyy")

        Dim cek_nmrNota As String = "SELECT COUNT(*) FROM H_JUAL"
        Dim cmdcekNota As OracleCommand = New OracleCommand
        cmdcekNota.CommandText = cek_nmrNota
        cmdcekNota.Connection = LOGIN.OraCon
        Dim notaMax As String = cmdcekNota.ExecuteScalar()

        If (notaMax <> 0) Then
            Dim cektgl As String = "SELECT SUBSTR(MAX(NOMOR_NOTA), 3, 8) FROM H_JUAL"
            Dim cmdcekTgl As OracleCommand = New OracleCommand
            cmdcekTgl.CommandText = cektgl
            cmdcekTgl.Connection = LOGIN.OraCon
            Dim tglmax As String = cmdcekTgl.ExecuteScalar()

            If (regDate = tglmax) Then
                Dim cekctr As String = "SELECT SUBSTR(MAX(NOMOR_NOTA), 11, 4) FROM H_JUAL"
                Dim cmdcekCtr As OracleCommand = New OracleCommand
                cmdcekCtr.CommandText = cekctr
                cmdcekCtr.Connection = LOGIN.OraCon
                Dim ctr As Integer = cmdcekCtr.ExecuteScalar()
                ctr += 1
                If (ctr < 10) Then
                    lbNmrNota.Text = "HJ" & regDate & "000" & ctr
                ElseIf (ctr >= 10) Then
                    lbNmrNota.Text = "HJ" & regDate & "00" & ctr
                ElseIf (ctr >= 100) Then
                    lbNmrNota.Text = "HJ" & regDate & "0" & ctr
                ElseIf (ctr >= 1000) Then
                    lbNmrNota.Text = "HJ" & regDate & ctr
                End If
            Else
                lbNmrNota.Text = "HJ" & regDate & "000" & "1"
            End If
        ElseIf (notaMax = 0) Then
            lbNmrNota.Text = "HJ" & regDate & "000" & "1"
        End If

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        Me.Hide()
        PENGUNJUNG.Show()
    End Sub

    Private Sub TIKET_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ShowData()
        Call autogenid()

        lbIdPeg.Text = LOGIN.TextBox1.Text

    End Sub

    Dim total As Integer = 0
    Dim temp_total As Integer = 0
    Dim grand_total As Integer = 0
    Dim total_jumtiket As Integer = 0

    Sub insert_HJual()
        Dim no_nota As String = lbNmrNota.Text
        Dim id_peg As String = lbIdPeg.Text
        Dim id_member As String = tbIdCust.Text
        Dim nama_pengunjung As String = tbIdCust.Text

        Dim jenis_tiket As String = cbJenisTiket.SelectedIndex

        Dim insert_hjual As String = ""
        If (lbCust.Text = "ID MEMBER : ") Then
            insert_hjual = "INSERT INTO H_JUAL VALUES('" + no_nota.ToUpper + "','" + id_member.ToUpper + "','','" + id_peg.ToUpper + "','')"
        ElseIf (lbCust.Text = "NAMA PENGUNJUNG : ") Then
            insert_hjual = "INSERT INTO H_JUAL VALUES('" + no_nota.ToUpper + "','','" + nama_pengunjung.ToUpper + "','" + id_peg.ToUpper + "','')"
        End If

        Dim cmdinsertHjual As OracleCommand = New OracleCommand
        cmdinsertHjual.CommandText = insert_hjual
        cmdinsertHjual.Connection = LOGIN.OraCon

        Try
            cmdinsertHjual.ExecuteNonQuery()
            'MessageBox.Show("Insert H_Jual Berhasil!")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub

    Private Sub btnBeli_Click(sender As Object, e As EventArgs) Handles btnBeli.Click
        Dim harga As Integer
        If (cbJenisTiket.SelectedIndex = "0") Then
            harga = 80000
        ElseIf (cbJenisTiket.SelectedIndex = "1") Then
            harga = 100000
        ElseIf (cbJenisTiket.SelectedIndex = "2") Then
            harga = 120000
        ElseIf (cbJenisTiket.SelectedIndex = "3") Then
            harga = 150000
        End If

        Dim jum_tiket As Integer = spJumTiket.Value
        total_jumtiket += jum_tiket
        total = harga * jum_tiket

        Dim diskon As Integer = 0
        If (lbCust.Text = "ID MEMBER : ") Then
            diskon = total * 0.15
            total -= diskon
        End If

        temp_total += total

        If (tbIdCust.Text <> "" And cbJenisTiket.SelectedIndex <> "-1" And jum_tiket <> "0") Then
            Dim cek_Nota As String = "SELECT COUNT(*) FROM H_JUAL"
            Dim cmdcekNota As OracleCommand = New OracleCommand
            cmdcekNota.CommandText = cek_Nota
            cmdcekNota.Connection = LOGIN.OraCon
            Dim notaMax As Integer = cmdcekNota.ExecuteScalar()

            If (notaMax > 0) Then
                Dim cek_nmrNota As String = "SELECT MAX(NOMOR_NOTA) FROM H_JUAL"
                Dim cmdcekNmrNota As OracleCommand = New OracleCommand
                cmdcekNmrNota.CommandText = cek_nmrNota
                cmdcekNmrNota.Connection = LOGIN.OraCon
                Dim nmrNotaMax As String = cmdcekNmrNota.ExecuteScalar()

                If (lbNmrNota.Text <> nmrNotaMax) Then
                    Call insert_HJual()
                End If
            Else
                Call insert_HJual()
            End If

            Dim insert_djual As String = "INSERT INTO D_JUAL VALUES('" + lbNmrNota.Text.ToUpper + "','" + cbJenisTiket.SelectedIndex.ToString.ToUpper + "','" + jum_tiket.ToString + "','" + harga.ToString + "','" + total.ToString + "')"
            Dim cmdinsert_Djual As OracleCommand = New OracleCommand
            cmdinsert_Djual.CommandText = insert_djual
            cmdinsert_Djual.Connection = LOGIN.OraCon

            Try
                cmdinsert_Djual.ExecuteNonQuery()
                'MessageBox.Show("Insert D_Jual Berhasil!")
                Call ShowData()

                lbHarga.Text = temp_total

                tbIdCust.Text = ""
                cbJenisTiket.SelectedIndex = -1
                spJumTiket.Value = "0"
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            End Try
        Else
            MessageBox.Show("Data belum terisi lengkap!")
        End If

    End Sub
    Public list As New ArrayList

    Sub ShowParkirAvailable()
        Dim ctr As Integer = 0

        Dim cmd As New OracleCommand
        cmd.Connection = LOGIN.OraCon

        cmd.CommandText = "SELECT BLOK FROM VIEWPARKIR"

        Dim reader As OracleDataReader
        reader = cmd.ExecuteReader

        While reader.Read
            list.Add(reader.GetValue(0).ToString)
        End While
        reader.Close()
    End Sub

    Private Sub btnBayar_Click(sender As Object, e As EventArgs) Handles btnBayar.Click
        Dim update_Final As String = "update H_JUAL set GRAND_TOTAL='" + temp_total.ToString + "' WHERE NOMOR_NOTA = '" + lbNmrNota.Text + "'"
        Dim cmdupdateFinal As OracleCommand = New OracleCommand
        cmdupdateFinal.CommandText = update_Final
        cmdupdateFinal.Connection = LOGIN.OraCon

        For i As Integer = 1 To total_jumtiket
            Dim regDate As String
            regDate = Format(Date.Now(), "ddMMyy")

            Dim cek_idpengunjung As String = "SELECT COUNT(*) FROM PENGUNJUNG"
            Dim cmdcekidpengunjung As OracleCommand = New OracleCommand
            cmdcekidpengunjung.CommandText = cek_idpengunjung
            cmdcekidpengunjung.Connection = LOGIN.OraCon
            Dim idpengunjungMax As String = cmdcekidpengunjung.ExecuteScalar()

            Dim id_pengunjung As String = ""
            If (idpengunjungMax <> 0) Then
                Dim cektgl As String = "SELECT SUBSTR(MAX(ID_PENGUNJUNG), 4, 6) FROM PENGUNJUNG"
                Dim cmdcekTgl As OracleCommand = New OracleCommand
                cmdcekTgl.CommandText = cektgl
                cmdcekTgl.Connection = LOGIN.OraCon
                Dim tglmax As String = cmdcekTgl.ExecuteScalar()

                If (regDate = tglmax) Then
                    Dim cekctr As String = "SELECT SUBSTR(MAX(ID_PENGUNJUNG), 10, 4) FROM PENGUNJUNG"
                    Dim cmdcekCtr As OracleCommand = New OracleCommand
                    cmdcekCtr.CommandText = cekctr
                    cmdcekCtr.Connection = LOGIN.OraCon
                    Dim ctr As Integer = cmdcekCtr.ExecuteScalar()
                    ctr += 1
                    If (ctr < 10) Then
                        id_pengunjung = "CST" & regDate & "000" & ctr
                    ElseIf (ctr >= 10) Then
                        id_pengunjung = "CST" & regDate & "00" & ctr
                    ElseIf (ctr >= 100) Then
                        id_pengunjung = "CST" & regDate & "0" & ctr
                    ElseIf (ctr >= 1000) Then
                        id_pengunjung = "CST" & regDate & ctr
                    End If
                Else
                    id_pengunjung = "CST" & regDate & "000" & "1"
                End If
            ElseIf (idpengunjungMax = 0) Then
                id_pengunjung = "CST" & regDate & "000" & "1"
            End If

            Dim insert_pengunjung As String = "INSERT INTO PENGUNJUNG VALUES('" + id_pengunjung + "','')"
            Dim cmdinsert_pengunjung As OracleCommand = New OracleCommand
            cmdinsert_pengunjung.CommandText = insert_pengunjung
            cmdinsert_pengunjung.Connection = LOGIN.OraCon

            Try
                cmdinsert_pengunjung.ExecuteNonQuery()
                'MessageBox.Show("Insert PENGUNJUNG BERHASIL!" & " - " & id_pengunjung)
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString() & " - " & id_pengunjung)
            End Try
        Next

        Try
            cmdupdateFinal.ExecuteNonQuery()
            MessageBox.Show("Transaksi Berhasil!")
            Call autogenid()
            Call ShowData()

            tbIdCust.Text = ""
            cbJenisTiket.SelectedIndex = -1
            spJumTiket.Value = "0"
            temp_total = 0
            total_jumtiket = 0
            lbHarga.Text = "0"
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim cek_HJUAL As String = "SELECT COUNT(*) FROM H_JUAL WHERE NOMOR_NOTA = '" + lbNmrNota.Text + "'"
        Dim cmdcekHJUAL As OracleCommand = New OracleCommand
        cmdcekHJUAL.CommandText = cek_HJUAL
        cmdcekHJUAL.Connection = LOGIN.OraCon
        Dim hjualMax As String = cmdcekHJUAL.ExecuteScalar()

        If (hjualMax <> 0) Then
            Dim delete_djual As String = "DELETE FROM D_JUAL WHERE NOMOR_NOTA = '" + lbNmrNota.Text + "'"
            Dim cmddelete_djual As OracleCommand = New OracleCommand
            cmddelete_djual.CommandText = delete_djual
            cmddelete_djual.Connection = LOGIN.OraCon

            Try
                cmddelete_djual.ExecuteNonQuery()
                MessageBox.Show("delete djual BERHASIL!")
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            End Try

            Dim delete_hjual As String = "DELETE FROM H_JUAL WHERE NOMOR_NOTA = '" + lbNmrNota.Text + "'"
            Dim cmddelete_hjual As OracleCommand = New OracleCommand
            cmddelete_hjual.CommandText = delete_hjual
            cmddelete_hjual.Connection = LOGIN.OraCon

            Try
                cmddelete_hjual.ExecuteNonQuery()
                MessageBox.Show("delete hjual BERHASIL!")
                Me.Hide()
                PENGUNJUNG.Show()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString())
            End Try
        ElseIf (hjualMax = 0) Then
            Me.Hide()
            PENGUNJUNG.Show()
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PARKIR.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        PENGUNJUNG.Show()

    End Sub
End Class