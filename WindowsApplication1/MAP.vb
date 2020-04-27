Imports Oracle.DataAccess.Client
Public Class MAP
    Public StringCon As String
    Public OraCon As OracleConnection

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub ShowData()
        Dim Stringdata As String = "select nama_show, keterangan, jam_mulai, jam_selesai from header_show"
        Dim ADP As New OracleDataAdapter(Stringdata, MAINMENU.OraCon)
        Dim DS As New DataSet

        ADP.Fill(DS)
        DataGridView2.DataSource = DS.Tables(0)
    End Sub

    Private Sub MAP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'StringCon = "Data Source=XE; User Id=andy; Password=andy;"
        'OraCon = New OracleConnection(StringCon)
        'Try
        '    OraCon.Open()
        '    MessageBox.Show("Berhasil Log In Oracle")
        'Catch ex As Exception
        '    MessageBox.Show("Gagal Log In")
        'End Try
        Call ShowData()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Call antrian_wahana1()
        Call antrian_wahana2()
        Call antrian_wahana3()
        Call antrian_wahana4()
        Call ShowData()
    End Sub

    Sub antrian_wahana1()
        Dim Stringdata As String = "select nvl(count(id_wahana),0) from d_wahana where id_wahana = 'WH001' and status_main = 'I'"
        Dim cmdinsert As OracleCommand = New OracleCommand

        cmdinsert.CommandText = Stringdata
        cmdinsert.Connection = MAINMENU.OraCon

        Try
            Dim angka As Integer = cmdinsert.ExecuteScalar()
            If angka > 15 Then
                Label10.BackColor = Color.Yellow
            ElseIf angka > 30 Then
                Label10.BackColor = Color.Red
            End If
            Label2.Text = angka.ToString("D3")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub

    Sub antrian_wahana2()
        Dim Stringdata As String = "select nvl(count(id_wahana),0) from d_wahana where id_wahana = 'WH002' and status_main = 'I'"
        Dim cmdinsert As OracleCommand = New OracleCommand

        cmdinsert.CommandText = Stringdata
        cmdinsert.Connection = MAINMENU.OraCon

        Try
            Dim angka As Integer = cmdinsert.ExecuteScalar()
            If angka > 15 Then
                Label7.BackColor = Color.Yellow
            ElseIf angka > 30 Then
                Label7.BackColor = Color.Red
            End If
            Label3.Text = angka.ToString("D3")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub

    Sub antrian_wahana3()
        Dim Stringdata As String = "select nvl(count(id_wahana),0) from d_wahana where id_wahana = 'WH003' and status_main = 'I'"
        Dim cmdinsert As OracleCommand = New OracleCommand

        cmdinsert.CommandText = Stringdata
        cmdinsert.Connection = MAINMENU.OraCon

        Try
            Dim angka As Integer = cmdinsert.ExecuteScalar()
            If angka > 15 Then
                Label8.BackColor = Color.Yellow
            ElseIf angka > 30 Then
                Label8.BackColor = Color.Red
            End If
            Label4.Text = angka.ToString("D3")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub

    Sub antrian_wahana4()
        Dim Stringdata As String = "select nvl(count(id_wahana),0) from d_wahana where id_wahana = 'WH004' and status_main = 'I'"
        Dim cmdinsert As OracleCommand = New OracleCommand

        cmdinsert.CommandText = Stringdata
        cmdinsert.Connection = MAINMENU.OraCon

        Try
            Dim angka As Integer = cmdinsert.ExecuteScalar()
            If angka > 15 Then
                Label9.BackColor = Color.Yellow
            ElseIf angka > 30 Then
                Label9.BackColor = Color.Red
            End If
            Label5.Text = angka.ToString("D3")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
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
