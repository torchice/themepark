Public Class report1

    Private Sub report1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cr As New CrystalReport2
        cr.SetDatabaseLogon("andy", "andy")
    End Sub
End Class