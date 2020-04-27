Imports Oracle.DataAccess.Client
Public Class TOTAL
    Private Sub MAP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tot_peng()

    End Sub
    Public Sub tot_peng()
        Dim cek As String = "select count(*) from pengunjung where status_pengunjung = 'I'"
        Dim cmdcek As OracleCommand = New OracleCommand
        cmdcek.CommandText = cek
        cmdcek.Connection = MAINMENU.OraCon
        Dim id As Integer = cmdcek.ExecuteScalar()
        If Label3.Text < 25 Then
            Label5.BackColor = Color.Green
        ElseIf Label3.Text > 25 And Label3.Text < 50 Then
            Label5.BackColor = Color.Yellow
        ElseIf Label3.Text > 50 Then
            Label5.BackColor = Color.Red
        End If
        Label3.Text = id.ToString("D4")
    End Sub

    Public Sub tot_park()
        Dim cek As String = "select count(*) from viewparkir"
        Dim cmdcek As OracleCommand = New OracleCommand
        cmdcek.CommandText = cek
        cmdcek.Connection = MAINMENU.OraCon
        Dim id As Integer = cmdcek.ExecuteScalar()
        If Label3.Text < 25 Then
            Label5.BackColor = Color.Green
        ElseIf Label3.Text > 25 And Label3.Text < 50 Then
            Label5.BackColor = Color.Yellow
        ElseIf Label3.Text > 50 Then
            Label5.BackColor = Color.Red
        End If
        Label4.Text = id.ToString("D3")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Call tot_peng()
        Call tot_park()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class